using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace DrawTools
{
	/// <summary>
	/// Base class for all draw objects
	/// </summary>
	abstract class DrawObject
	{
        #region Members

        // Object properties

	    // Allows to write Undo - Redo functions and don't care about
        // objects order in the list.

	    // Last used property values (may be kept in the Registry)

	    // Entry names for serialization
        private const string entryColor = "Color";
        private const string entryPenWidth = "PenWidth";

        #endregion

	    protected DrawObject()
        {
            Id = GetHashCode();
        }

	    static DrawObject()
	    {
	        LastUsedPenWidth = 1;
	        LastUsedColor = Color.Black;
	    }

	    #region Properties

	    /// <summary>
	    /// Selection flag
	    /// </summary>
	    public bool Selected { get; set; }

	    /// <summary>
	    /// Color
	    /// </summary>
	    public Color Color { get; set; }

	    /// <summary>
	    /// Pen width
	    /// </summary>
	    public int PenWidth { get; set; }

	    /// <summary>
        /// Number of handles
        /// </summary>
        public virtual int HandleCount
        {
            get
            {
                return 0;
            }
        }

	    /// <summary>
	    /// Object ID
	    /// </summary>
	    public int Id { get; set; }


	    /// <summary>
	    /// Last used color
	    /// </summary>
	    public static Color LastUsedColor { get; set; }

	    /// <summary>
	    /// Last used pen width
	    /// </summary>
	    public static int LastUsedPenWidth { get; set; }

	    #endregion

        #region Virtual Functions

        /// <summary>
        /// Clone this instance.
        /// </summary>
        public abstract DrawObject Clone();

        /// <summary>
        /// Draw object
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// Draw tracker for selected object
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            if ( ! Selected )
                return;

            var brush = new SolidBrush(Color.Black);

            for ( int i = 1; i <= HandleCount; i++ )
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }

            brush.Dispose();
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }


        /// <summary>
        /// Test whether point is inside of the object
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }
        

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// Test whether object intersects with rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// Move handle to the point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Dump (for debugging)
        /// </summary>
        public virtual void Dump()
        {
            Trace.WriteLine(GetType().Name);
            Trace.WriteLine("Selected = " + 
                Selected.ToString(CultureInfo.InvariantCulture)
                + " ID = " + Id.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Normalize object.
        /// Call this function in the end of object resizing.
        /// </summary>
        public virtual void Normalize()
        {
        }


        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public virtual void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                    "{0}{1}",
                    entryColor, orderNumber),
                Color.ToArgb());

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                "{0}{1}",
                entryPenWidth, orderNumber),
                PenWidth);
        }

        /// <summary>
        /// Load object from serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public virtual void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            int n = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                    "{0}{1}",
                    entryColor, orderNumber));

            Color = Color.FromArgb(n);

            PenWidth = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                "{0}{1}",
                entryPenWidth, orderNumber));

            Id = GetHashCode();
        }

        #endregion

        #region Other functions

        /// <summary>
        /// Initialization
        /// </summary>
        protected void Initialize()
        {
            Color = LastUsedColor;
            PenWidth = LastUsedPenWidth;
        }

        /// <summary>
        /// Copy fields from this instance to cloned instance drawObject.
        /// Called from Clone functions of derived classes.
        /// </summary>
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.Selected = Selected;
            drawObject.Color = Color;
            drawObject.PenWidth = PenWidth;
            drawObject.Id = Id;
        }

        #endregion
    }
}
