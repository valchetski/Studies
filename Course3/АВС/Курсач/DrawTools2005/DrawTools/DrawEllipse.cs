using System.Drawing;

namespace DrawTools
{
	/// <summary>
	/// Ellipse graphic object
	/// </summary>
	class DrawEllipse : DrawRectangle
	{
		public DrawEllipse() : this(0, 0, 1, 1)
		{
		}

        public DrawEllipse(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize();
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            var drawEllipse = new DrawEllipse {Rectangle = Rectangle};

            FillDrawObjectFields(drawEllipse);
            return drawEllipse;
        }


        public override void Draw(Graphics g)
        {
            var pen = new Pen(Color, PenWidth);

            g.DrawEllipse(pen, GetNormalizedRectangle(Rectangle));

            pen.Dispose();
        }


	}
}
