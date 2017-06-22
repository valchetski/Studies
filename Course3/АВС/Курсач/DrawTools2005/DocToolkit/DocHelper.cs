#region Using directives

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Security;

#endregion

namespace DocToolkit
{
    #region Class DocManager

    public class DocHelper
    {
        #region Events

        public event SaveEventHandler SaveEvent;
        public event LoadEventHandler LoadEvent;
        public event OpenFileEventHandler OpenEvent;
        public event EventHandler ClearEvent;
        public event EventHandler DocChangedEvent;

        #endregion

        #region Members

        private string fileName = "";
        private bool dirty;

        private readonly Form frmOwner;
        private readonly string newDocName;
        private readonly string fileDlgFilter;
        private readonly string registryPath;
        private readonly bool updateTitle;

        private const string registryValue = "Path";
        private string fileDlgInitDir = "";         // file dialog initial directory

        #endregion

        #region Enum

        /// <summary>
        /// Enumeration used for Save function
        /// </summary>
        public enum SaveType
        {
            Save,
            SaveAs
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="data"></param>
        public DocHelper(DocManagerData data)
        {
            frmOwner = data.FormOwner;
            frmOwner.Closing += OnClosing;

            updateTitle = data.UpdateTitle;

            newDocName = data.NewDocName;

            fileDlgFilter = data.FileDialogFilter;

            registryPath = data.RegistryPath;

            if (!registryPath.EndsWith("\\"))
                registryPath += "\\";

            registryPath += "FileDir";

            // attempt to read initial directory from registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);

            if (key != null)
            {
                var s = (string)key.GetValue(registryValue);

                if (!Empty(s))
                    fileDlgInitDir = s;
            }
        }

        #endregion

        #region Public functions and Properties

        /// <summary>
        /// Dirty property (true when document has unsaved changes).
        /// </summary>
        public bool Dirty
        {
            get
            {
                return dirty;
            }
            set
            {
                dirty = value;
                SetCaption();
            }
        }

        /// <summary>
        /// Open new document
        /// </summary>
        /// <returns></returns>
        public bool NewDocument()
        {
            if (!CloseDocument())
                return false;

            SetFileName("");

            if (ClearEvent != null)
            {
                // raise event to clear document contents in memory
                // (this class has no idea how to do this)
                ClearEvent(this, new EventArgs());
            }

            Dirty = false;

            return true;
        }

        /// <summary>
        /// Close document
        /// </summary>
        /// <returns></returns>
        public bool CloseDocument()
        {
            if (!dirty)
                return true;

            DialogResult res = MessageBox.Show(
                frmOwner,
                "Save changes?",
                Application.ProductName,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation);

            switch (res)
            {
                case DialogResult.Yes: return SaveDocument(SaveType.Save);
                case DialogResult.No: return true;
                case DialogResult.Cancel: return false;
                default: Debug.Assert(false); return false;
            }
        }

        /// <summary>
        /// Open document
        /// </summary>
        /// <param name="newFileName">
        /// Document file name. Empty - function shows Open File dialog.
        /// </param>
        /// <returns></returns>
        public bool OpenDocument(string newFileName)
        {
            // Check if we can close current file
            if (!CloseDocument())
                return false;

            // Get the file to open
            if (Empty(newFileName))
            {
                var openFileDialog1 = new OpenFileDialog {Filter = fileDlgFilter, InitialDirectory = fileDlgInitDir};

                DialogResult res = openFileDialog1.ShowDialog(frmOwner);

                if (res != DialogResult.OK)
                    return false;

                newFileName = openFileDialog1.FileName;
                fileDlgInitDir = new FileInfo(newFileName).DirectoryName;
            }

            // Read the data
            try
            {
                using (Stream stream = new FileStream(
                           newFileName, FileMode.Open, FileAccess.Read))
                {
                    // Deserialize object from text format
                    IFormatter formatter = new BinaryFormatter();

                    if (LoadEvent != null)        // if caller subscribed to this event
                    {
                        var args = new SerializationEventArgs(formatter, stream, newFileName);

                        // raise event to load document from file
                        LoadEvent(this, args);

                        if (args.Error)
                        {
                            // report failure
                            if (OpenEvent != null)
                            {
                                OpenEvent(this,
                                    new OpenFileEventArgs(newFileName, false));
                            }

                            return false;
                        }

                        // raise event to show document in the window
                        if (DocChangedEvent != null)
                        {
                            DocChangedEvent(this, new EventArgs());
                        }
                    }
                }
            }
            // Catch all exceptions which may be raised from this code.
            // Caller is responsible to handle all other exceptions 
            // in the functions invoked by LoadEvent and DocChangedEvent.
            catch (ArgumentNullException ex) { return HandleOpenException(ex, newFileName); }
            catch (ArgumentOutOfRangeException ex) { return HandleOpenException(ex, newFileName); }
            catch (ArgumentException ex) { return HandleOpenException(ex, newFileName); }
            catch (SecurityException ex) { return HandleOpenException(ex, newFileName); }
            catch (FileNotFoundException ex) { return HandleOpenException(ex, newFileName); }
            catch (DirectoryNotFoundException ex) { return HandleOpenException(ex, newFileName); }
            catch (PathTooLongException ex) { return HandleOpenException(ex, newFileName); }
            catch (IOException ex) { return HandleOpenException(ex, newFileName); }

            // Clear dirty bit, cache the file name and set the caption
            Dirty = false;
            SetFileName(newFileName);

            if (OpenEvent != null)
            {
                // report success
                OpenEvent(this, new OpenFileEventArgs(newFileName, true));
            }

            // Success
            return true;
        }

        /// <summary>
        /// Save file.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool SaveDocument(SaveType type)
        {
            // Get the file name
            string newFileName = fileName;

            var saveFileDialog1 = new SaveFileDialog {Filter = fileDlgFilter};

            if ((type == SaveType.SaveAs) ||
                Empty(newFileName))
            {

                if (!Empty(newFileName))
                {
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName(newFileName);
                    saveFileDialog1.FileName = Path.GetFileName(newFileName);
                }
                else
                {
                    saveFileDialog1.InitialDirectory = fileDlgInitDir;
                    saveFileDialog1.FileName = newDocName;
                }

                DialogResult res = saveFileDialog1.ShowDialog(frmOwner);

                if (res != DialogResult.OK)
                    return false;

                newFileName = saveFileDialog1.FileName;
                fileDlgInitDir = new FileInfo(newFileName).DirectoryName;
            }

            // Write the data
            try
            {
                using (Stream stream = new FileStream(
                           newFileName, FileMode.Create, FileAccess.Write))
                {
                    // Serialize object to text format
                    IFormatter formatter = new BinaryFormatter();

                    if (SaveEvent != null)        // if caller subscribed to this event
                    {
                        var args = new SerializationEventArgs(formatter, stream, newFileName);

                        // raise event
                        SaveEvent(this, args);

                        if (args.Error)
                            return false;
                    }

                }
            }
            catch (ArgumentNullException ex) { return HandleSaveException(ex, newFileName); }
            catch (ArgumentOutOfRangeException ex) { return HandleSaveException(ex, newFileName); }
            catch (ArgumentException ex) { return HandleSaveException(ex, newFileName); }
            catch (SecurityException ex) { return HandleSaveException(ex, newFileName); }
            catch (FileNotFoundException ex) { return HandleSaveException(ex, newFileName); }
            catch (DirectoryNotFoundException ex) { return HandleSaveException(ex, newFileName); }
            catch (PathTooLongException ex) { return HandleSaveException(ex, newFileName); }
            catch (IOException ex) { return HandleSaveException(ex, newFileName); }

            // Clear the dirty bit, cache the new file name
            // and the caption is set automatically
            Dirty = false;
            SetFileName(newFileName);

            // Success
            return true;
        }

        /// <summary>
        /// Assosciate file type with this program in the Registry
        /// </summary>
        /// <returns>true - OK, false - failed</returns>
        public bool RegisterFileType(string fileExtension, string progId, string typeDisplayName)
        {
            try
            {
                string s = String.Format(CultureInfo.InvariantCulture, ".{0}", fileExtension);

                // Register custom extension with the shell
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(s))
                {
                    // Map custom  extension to a ProgID
                    if (key != null) key.SetValue(null, progId);
                }

                // create ProgID key with display name
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progId))
                {
                    key.SetValue(null, typeDisplayName);
                }

                // register icon
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(progId + @"\DefaultIcon"))
                {
                    key.SetValue(null, Application.ExecutablePath + ",0");
                }

                // Register open command with the shell
                string cmdkey = progId + @"\shell\open\command";
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(cmdkey))
                {
                    // Map ProgID to an Open action for the shell
                    key.SetValue(null, Application.ExecutablePath + " \"%1\"");
                }

                // Register application for "Open With" dialog
                string appkey = "Applications\\" +
                    new FileInfo(Application.ExecutablePath).Name +
                    "\\shell";
                using (RegistryKey key =
                           Registry.ClassesRoot.CreateSubKey(appkey))
                {
                    key.SetValue("FriendlyCache", Application.ProductName);
                }
            }
            catch (ArgumentNullException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (SecurityException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (ArgumentException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (ObjectDisposedException ex)
            {
                return HandleRegistryException(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                return HandleRegistryException(ex);
            }

            return true;
        }

        #endregion

        #region Other Functions


        /// <summary>
        /// Hanfle exception from RegisterFileType function
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private bool HandleRegistryException(Exception ex)
        {
            Trace.WriteLine("Registry operation failed: " + ex.Message);
            return false;
        }

        /// <summary>
        /// Save initial directory to the Registry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
            key.SetValue(registryValue, fileDlgInitDir);
        }


        /// <summary>
        /// Set file name and change owner's caption
        /// </summary>
        /// <param name="fileName"></param>
        private void SetFileName(string fileName)
        {
            this.fileName = fileName;
            SetCaption();
        }

        /// <summary>
        /// Set owner form caption
        /// </summary>
        private void SetCaption()
        {
            if (!updateTitle)
                return;

            frmOwner.Text = string.Format(
                CultureInfo.InvariantCulture,
                "{0} - {1}{2}",
                Application.ProductName,
                Empty(fileName) ? newDocName : Path.GetFileName(fileName),
                dirty ? "*" : "");
        }

        /// <summary>
        /// Handle exception in OpenDocument function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool HandleOpenException(Exception ex, string fileName)
        {
            MessageBox.Show(frmOwner,
                "Open File operation failed. File name: " + fileName + "\n" +
                "Reason: " + ex.Message,
                Application.ProductName);

            if (OpenEvent != null)
            {
                // report failure
                OpenEvent(this, new OpenFileEventArgs(fileName, false));
            }

            return false;
        }

        /// <summary>
        /// Handle exception in SaveDocument function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool HandleSaveException(Exception ex, string fileName)
        {
            MessageBox.Show(frmOwner,
                "Save File operation failed. File name: " + fileName + "\n" +
                "Reason: " + ex.Message,
                Application.ProductName);

            return false;
        }


        /// <summary>
        /// Helper function - test if string is empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool Empty(string s)
        {
            return string.IsNullOrEmpty(s);
        }

        #endregion

    }

    #endregion

    #region Delegates

    public delegate void SaveEventHandler(object sender, SerializationEventArgs e);
    public delegate void LoadEventHandler(object sender, SerializationEventArgs e);
    public delegate void OpenFileEventHandler(object sender, OpenFileEventArgs e);

    #endregion

    #region Class SerializationEventArgs

    /// <summary>
    /// Serialization event arguments.
    /// Used in events raised from DocManager class.
    /// Class contains information required to load/save file.
    /// </summary>
    public class SerializationEventArgs : EventArgs
    {
        public SerializationEventArgs(IFormatter formatter, Stream stream,
            string fileName)
        {
            Formatter = formatter;
            SerializationStream = stream;
            FileName = fileName;
            Error = false;
        }

        public bool Error { get; set; }

        public IFormatter Formatter { get; private set; }

        public Stream SerializationStream { get; private set; }

        public string FileName { get; private set; }
    }

    #endregion

    #region Class OpenFileEventArgs

    /// <summary>
    /// Open file event arguments.
    /// Used in events raised from DocManager class.
    /// Class contains name of file and result of Open operation.
    /// </summary>
    public class OpenFileEventArgs : EventArgs
    {
        public OpenFileEventArgs(string fileName, bool success)
        {
            FileName = fileName;
            Succeeded = success;
        }

        public string FileName { get; private set; }

        public bool Succeeded { get; private set; }
    }

    #endregion

    #region class DocManagerData

    /// <summary>
    /// Class used for DocManager class initialization
    /// </summary>
    public class DocManagerData
    {
        public DocManagerData()
        {
            FormOwner = null;
            UpdateTitle = true;
            NewDocName = "Untitled";
            FileDialogFilter = "All Files (*.*)|*.*";
            RegistryPath = "Software\\Unknown";
        }

        public Form FormOwner { get; set; }

        public bool UpdateTitle { get; set; }

        public string NewDocName { get; set; }

        public string FileDialogFilter { get; set; }

        public string RegistryPath { get; set; }
    };

    #endregion
}