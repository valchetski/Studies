using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    class Explosion : Entity
    {
        private Point frameSizePoint;

        public Explosion(Game game, Texture2D explosionTexture2D, Rectangle bangRectangle, Point frameSizePoint)
            : base(game, explosionTexture2D)
        {
            IsAnimate = true;
            IsGravity = false;
            this.frameSizePoint = frameSizePoint;
            PositionRectangle = bangRectangle;
        }

        public override void Update(GameTime gameTime)
        {
            Animation(gameTime, 0, 8);
            rectangle = new Rectangle(frameSizePoint.X * currentFrame.X, frameSizePoint.Y * currentFrame.Y,
                frameSizePoint.X, frameSizePoint.Y);
            if (currentFrame.X == 8)
            {
                Game.Components.Remove(this);
            }
            base.Update(gameTime);
        }
    }
}
