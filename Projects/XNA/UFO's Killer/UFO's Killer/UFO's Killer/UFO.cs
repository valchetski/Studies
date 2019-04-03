using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UFO_s_Killer
{
    class UFO : GameObject
    {
        public Vector2 velocityVector2;
        public UFOState state;

        private Vector2 ufoOriginalVector2;
        private Vector2 ufoPositionVector2;
        private float ufoRotation;
        public UFO(Texture2D _texture2D, Rectangle _rectangle, int speedX, float speedY)
        {
            texture2D = _texture2D;
            rectangle = _rectangle;
            velocityVector2 = new Vector2(speedX,speedY);
            state = UFOState.Fly;
        }

        public override void Update(int screenWidth, int screenHeigth)
        {
            if (state == UFOState.Fly)
            {
                if (rectangle.X <= screenWidth)
                {
                    rectangle.X -= Convert.ToInt32(velocityVector2.X);
                    rectangle.Y -= Convert.ToInt32(velocityVector2.Y);
                }
                else
                {
                    rectangle.X -= 2;
                }
            }
            else if (state == UFOState.Fall)
            {
                ufoPositionVector2 = new Vector2(rectangle.X, rectangle.Y);
                rectangle.X = (int) ufoPositionVector2.X;
                rectangle.Y = (int) (ufoPositionVector2.Y);
                ufoOriginalVector2 = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
                ufoRotation -= 0.1f;
                Fall();
                if (rectangle.Y > screenHeigth)
                {
                    state = UFOState.Stop;
                }
            }
        }

        private void Fall()
        {
            var fallSpeed = 5;
            velocityVector2 = new Vector2(fallSpeed,fallSpeed);
            rectangle.X -= Convert.ToInt32(velocityVector2.X);
            rectangle.Y += Convert.ToInt32(velocityVector2.Y);
        }

        public void DrawFall(SpriteBatch spriteBatch, float speedRotation)
        {
            ufoPositionVector2 = new Vector2(rectangle.X, rectangle.Y);
            rectangle.X = (int)ufoPositionVector2.X;
            rectangle.Y = (int)(ufoPositionVector2.Y);
            ufoOriginalVector2 = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            ufoRotation -= 0.2f;
            spriteBatch.Draw(texture2D, ufoPositionVector2, null, Color.White, ufoRotation, ufoOriginalVector2, 1f, SpriteEffects.None, 0);
        }
    }
}
