using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tennis
{
    class Racket : GameObject
    {
        public Racket(Texture2D newTexture, Rectangle newRectangle, int _displayWidth, int _displayHeigth, int speed)
        {
            texture = newTexture;
            rectangle = newRectangle;
            displayWidth = _displayWidth;
            displayHeight = _displayHeigth;
            speedVector2 = new Vector2(speed,speed);
        }
        public void Update()
        {
            Move();   
            MoveLimit();
        }

        private void Move()
        {
            var keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Right))
            {
                rectangle.X += Convert.ToInt32(speedVector2.X);
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                rectangle.X -= Convert.ToInt32(speedVector2.X);
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
