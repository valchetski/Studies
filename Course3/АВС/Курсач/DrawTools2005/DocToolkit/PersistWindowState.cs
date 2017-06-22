#region Using directives

using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

#endregion

namespace DocToolkit
{
    /// <summary>
    /// Class allows to keep last window state in Registry
    /// and restore it when form is loaded.
    /// 
    /// Source: Saving and Restoring the Location, Size and 
    ///         Windows State of a .NET Form
    ///         By Joel Matthias 
    ///         
    ///  Downloaded from http://www.codeproject.com
    ///  
    ///  Using:
    ///  1. Add class member to the owner form:
    ///  
    ///  private PersistWindowState persistState;
    ///  
    ///  2. Create it in the form constructor:
    ///  
    ///  persistState = new PersistWindowState("Software\\MyCompany\\MyProgram", this);
    ///  
    /// </summary>
    public class PersistWindowState
    {
        #region Members

        private readonly Form ownerForm;          // reference to owner form
        private readonly string registryPath;       // path in Registry where state information is kept

        // Form state parameters:
        private int normalLeft;
        private int normalTop;
        private int normalWidth;
        private int normalHeight;

        // FormWindowState is enumeration from System.Windows.Forms Namespace
        // Contains 3 members: Maximized, Minimized and Normal.
        private FormWindowState windowState = FormWindowState.Normal;

        // if allowSaveMinimized is true, form closed in minimal state
        // is loaded next time in minimal state.

        #endregion

        #region Constructor

        /// <summary>
        /// Initialization
        /// </summary>
        public PersistWindowState(string path, Form owner)
        {
            AllowSaveMinimized = false;
            registryPath = string.IsNullOrEmpty(path) ? "Software\\Unknown" : path;

            if (!registryPath.EndsWith("\\"))
                registryPath += "\\";

            registryPath += "MainForm";

            ownerForm = owner;

            // subscribe to parent form's events

            ownerForm.Closing += OnClosing;
            ownerForm.Resize += OnResize;
            ownerForm.Move += OnMove;
            ownerForm.Load += OnLoad;

            // get initial width and height in case form is never resized
            normalWidth = ownerForm.Width;
            normalHeight = ownerForm.Height;
        }

        #endregion

        #region Properties

        /// <summary>
        /// AllowSaveMinimized property (default value false) 
        /// </summary>
        public bool AllowSaveMinimized { get; set; }

        #endregion

        #region Event Handlers


        /// <summary>
        /// Parent form is resized.
        /// Keep current size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, System.EventArgs e)
        {
            // save width and height
            if (ownerForm.WindowState == FormWindowState.Normal)
            {
                normalWidth = ownerForm.Width;
                normalHeight = ownerForm.Height;
            }
        }

        /// <summary>
        /// Parent form is moved.
        /// Keep current window position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMove(object sender, System.EventArgs e)
        {
            // save position
            if (ownerForm.WindowState == FormWindowState.Normal)
            {
                normalLeft = ownerForm.Left;
                normalTop = ownerForm.Top;
            }

            // save state
            windowState = ownerForm.WindowState;
        }

        /// <summary>
        /// Parent form is closing.
        /// Keep last state in Registry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // save position, size and state
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
            if (key != null)
            {
                key.SetValue("Left", normalLeft);
                key.SetValue("Top", normalTop);
                key.SetValue("Width", normalWidth);
                key.SetValue("Height", normalHeight);

                // check if we are allowed to save the state as minimized (not normally)
                if (!AllowSaveMinimized)
                {
                    if (windowState == FormWindowState.Minimized)
                        windowState = FormWindowState.Normal;
                }

                key.SetValue("WindowState", (int)windowState);
            }
        }

        /// <summary>
        /// Parent form is loaded.
        /// Read last state from Registry and set it to form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, System.EventArgs e)
        {
            // attempt to read state from registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);
            if (key != null)
            {
                int left = (int)key.GetValue("Left", ownerForm.Left);
                int top = (int)key.GetValue("Top", ownerForm.Top);
                int width = (int)key.GetValue("Width", ownerForm.Width);
                int height = (int)key.GetValue("Height", ownerForm.Height);
                var windowState = (FormWindowState)key.GetValue("WindowState", (int)ownerForm.WindowState);

                ownerForm.Location = new Point(left, top);
                ownerForm.Size = new Size(width, height);
                ownerForm.WindowState = windowState;
            }
        }

        #endregion

    }
}