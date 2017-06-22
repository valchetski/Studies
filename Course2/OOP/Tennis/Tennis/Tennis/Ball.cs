using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tennis
{
    class Ball : GameObject
    {
        public Ball(Texture2D newTexture, Rectangle newRectangle, int _displayWidth, int _displayHeigth, int speed)
        {
            texture = newTexture;
            rectangle = newRectangle;
            displayWidth = _displayWidth;
            displayHeight = _displayHeigth;
            speedVector2 = new Vector2(speed, speed);
        }
        public void Update()
        {
            Move();   
            MoveLimit();
        }

        private void Move()
        {
            rectangle.X += Convert.ToInt32(speedVector2.X);
            rectangle.Y += Convert.ToInt32(speedVector2.Y);
        }
        private void MoveLimit()
        {
            if (rectangle.X <= 0)
            {
                speedVector2.X = -speedVector2.X;
            }
            if (rectangle.X + texture.Width >= displayWidth)
            {
                speedVector2.X = -speedVector2.X;
            }
        }

    }
}
