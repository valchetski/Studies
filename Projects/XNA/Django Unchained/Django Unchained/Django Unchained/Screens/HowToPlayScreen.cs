using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Django_Unchained.Screens
{
    public class HowToPlayScreen : Screen
    {
        private readonly Texture2D background;
        private readonly Rectangle backgroundRectangle;

        private readonly Texture2D howToPlayTexture2D;
        private readonly Rectangle howToPlayRectangle;

        private KeyboardState pastKey;
        public HowToPlayScreen(Game game)
            : base(game)
        {
            background = ContentContainer.howToPlayBackgroundTexture2D;
            backgroundRectangle = new Rectangle(0,0,Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            
            howToPlayTexture2D = ContentContainer.howToPlayInstructionTexture2D;
            howToPlayRectangle = new Rectangle((Game.GraphicsDevice.Viewport.Width - howToPlayTexture2D.Width) / 2, (Game.GraphicsDevice.Viewport.Height - howToPlayTexture2D.Height) / 2,
                howToPlayTexture2D.Width, howToPlayTexture2D.Height);
        }

        public override void Checked(){}

        public override void Update(GameTime gameTime)
        {
            var presentKey = Keyboard.GetState();
            if ((presentKey.IsKeyDown(Keys.Escape)) && (pastKey.IsKeyUp(Keys.Escape)))
            {
                ScreenManager.SetMenuScreen();
            }
            pastKey = presentKey;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(background, backgroundRectangle, Color.White);
            spriteBatch.Draw(howToPlayTexture2D, howToPlayRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
