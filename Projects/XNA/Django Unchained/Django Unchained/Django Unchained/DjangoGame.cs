using Django_Unchained.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained
{
    public class DjangoGame : Game
    {
        SpriteBatch spriteBatch;
        private readonly ScreenManager screenManager;
        public GraphicsDeviceManager Graphics { get; set; }
        private readonly ContentContainer contentContainer;


        public DjangoGame()
        {
            Settings.LoadAll();
            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Settings.ScreenWidth,
                PreferredBackBufferHeight = Settings.ScreenHeight,
                IsFullScreen = Settings.IsFullscreen
            };
            //Graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            screenManager = new ScreenManager(this);
            contentContainer = new ContentContainer(this);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (Services.GetService(spriteBatch.GetType()) == null)
            {
                Services.AddService(typeof(SpriteBatch), spriteBatch);
            }
            contentContainer.LoadContent();
            if(screenManager.isInitialize == false)
                screenManager.Initialize();
            base.LoadContent();
        }

        protected override void UnloadContent(){}

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            screenManager.Draw(gameTime);
            if(screenManager.IsCurrentGameScreen())
                base.Draw(gameTime);
            spriteBatch.End();
        }

        protected override void Update(GameTime gameTime)
        {
            screenManager.Update(gameTime);
            if (Settings.isChanged)
            {
                Graphics.PreferredBackBufferWidth = Settings.ScreenWidth;
                Graphics.PreferredBackBufferHeight = Settings.ScreenHeight;
                Graphics.IsFullScreen = Settings.IsFullscreen;
                Graphics.ApplyChanges();
                screenManager.Initialize();
                Settings.isChanged = false;
            }
            if (screenManager.IsCurrentGameScreen())
            {
                base.Update(gameTime);
            }
        }
    }
}
