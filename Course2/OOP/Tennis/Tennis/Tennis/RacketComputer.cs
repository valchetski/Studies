using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tennis
{
    class RacketComputer :GameObject
    {
        public RacketComputer(Texture2D newTexture, Rectangle newRectangle, int _displayWidth, int _displayHeigth, int speed)
        {
            texture = newTexture;
            rectangle = newRectangle;
            displayWidth = _displayWidth;
            displayHeight = _displayHeigth;
            speedVector2 = new Vector2(speed,speed);
        }
        public void Update(int ballCentre, int ballSpeedX)
        {
            Move(ballCentre, ballSpeedX);   
            MoveLimit();
        }

        private void Move(int ballCentre, int ballSpeedX)
        {
            var random = new Random();
            var number = random.Next(-1, 1);
            if ((ballCentre > rectangle.X) && (ballSpeedX < 0))
            {
                rectangle.X -= Convert.ToInt32(speedVector2.X) + number;
            }
            else if (ballCentre > rectangle.X)
            {
                rectangle.X += Convert.ToInt32(speedVector2.X) + number;
            }
            else
            {
                rectangle.X -= Convert.ToInt32(speedVector2.X) + number;
            }
        }

        private void MoveLimit()
        {
            if (rectangle.X <= 0)
            {
                rectangle.X = 0;
            }
            if (rectangle.X + texture.Width >= displayWidth)
            {
                rectangle.X = displayWidth - texture.Width;
            }
        }
    }
}
