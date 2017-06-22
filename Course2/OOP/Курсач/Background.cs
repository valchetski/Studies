using Django_Unchained.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained
{
    class Background : DrawableGameComponent
    {
        private readonly Texture2D texture2D;
        private Rectangle rectangle1;
        private Rectangle rectangle2;
        private int previousCameraPosition;
        
        public Background(Game game, Texture2D texture2D) : base(game)
        {
            this.texture2D = texture2D;
            rectangle1 = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            rectangle2 = new Rectangle(rectangle1.Width, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (rectangle1.X + rectangle1.Width <= 0)
            {
                rectangle1.X = rectangle2.X + rectangle1.Width;
            }
            if (rectangle2.X + rectangle1.Width <= 0)
            {
                rectangle2.X = rectangle1.X + rectangle1.Width;
            }

            if ((rectangle1.X > rectangle2.X) && (rectangle2.X > 0))
            {
                rectangle1.X = rectangle2.X - rectangle1.Width;
            }
            else if (rectangle1.X > 0)
            {
                rectangle2.X = rectangle1.X - rectangle1.Width;
            }

            rectangle1.X -= Level.screenLeftX - previousCameraPosition;
            rectangle2.X -= Level.screenLeftX - previousCameraPosition;
            previousCameraPosition = Level.screenLeftX;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(texture2D, rectangle1, Color.White);
            spriteBatch.Draw(texture2D, rectangle2, Color.White);
            base.Draw(gameTime);
        }
    }
}
