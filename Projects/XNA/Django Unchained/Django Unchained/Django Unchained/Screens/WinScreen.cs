using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained.Screens
{
    public class WinScreen : Screen
    {
        private readonly Texture2D winText;
        private readonly Rectangle winTextRectangle;

        private readonly Song winTheme;

        private KeyboardState pastKey;

        private readonly Texture2D background;
        private readonly Rectangle backgroundRectangle;


        public WinScreen(Game game)
            : base(game)
        {
            int offsetY = Game.GraphicsDevice.Viewport.Height / 3;

            winTheme = ContentContainer.winSong;
            MusicPlayer.StopMusic(winTheme);

            background = ContentContainer.winBackgroundTexture2D;
            backgroundRectangle = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);

            winText = ContentContainer.winTextTexture2D;
            winTextRectangle = new Rectangle((Game.GraphicsDevice.Viewport.Width - winText.Width)/2, offsetY, winText.Width, winText.Height);
        }

        public override void Checked()
        {
            MusicPlayer.StopMusic(winTheme);
        }

        public override void Update(GameTime gameTime)
        {
            MusicPlayer.PlayMusic(winTheme);
            var presentKey = Keyboard.GetState();

            if ((presentKey.IsKeyDown(Keys.Space)) && (pastKey.IsKeyUp(Keys.Space)))
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
            spriteBatch.Draw(winText, winTextRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
