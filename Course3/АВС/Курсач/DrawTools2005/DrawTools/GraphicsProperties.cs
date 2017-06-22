using System.Drawing;

namespace DrawTools
{
    /// <summary>
    /// Helper class used to show properties
    /// for one or more graphic objects
    /// </summary>
    class GraphicsProperties
    {
        public GraphicsProperties()
        {
            Color = null;
            PenWidth = null;
        }

        public Color? Color { get; set; }

        public int? PenWidth { get; set; }
    }
}
