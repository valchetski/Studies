using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tennis
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Ball ball;
        private Racket racket1;
        private RacketComputer racketComputer;
        private Action action;

        private Texture2D backgroundTexture2D;
        private Rectangle backgroundRectangle;

        int displayWidth;
        int displayHeight;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366; 
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            NewGame();
        }

        void NewGame()
        {
            displayWidth = graphics.PreferredBackBufferWidth;
            displayHeight = graphics.PreferredBackBufferHeight;
            var displayCentreX = displayWidth / 2;
            var displayCentreY = displayHeight / 2;

            ball = new Ball(Content.Load<Texture2D>("round"), new Rectangle(displayCentreX - 250, displayCentreY, 50, 50),
                displayWidth, displayHeight, 6);
            racket1 = new Racket(Content.Load<Texture2D>("palka"), new Rectangle(displayCentreX, displayHeight - 20, 250, 20),
                displayWidth, displayHeight, 5);
            racketComputer = new RacketComputer(Content.Load<Texture2D>("palka2"), new Rectangle(displayCentreX, 0, 250, 20),
                displayWidth, displayHeight, 5);
            action = new Action();

            backgroundTexture2D = Content.Load<Texture2D>("thebestbackground");
            backgroundRectangle = new Rectangle(0, 0, 1366, 768);
        }

        void Pause()
        {
        }
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                NewGame();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Pause();
            }
            ball.Update();
            racket1.Update();
            var ballCentre = ball.rectangle.X + ball.texture.Width/2;
            racketComputer.Update(ballCentre, Convert.ToInt32(ball.speedVector2.X));
            action.Collision(ref ball, ref racket1);
            action.Collision(ref ball, ref racketComputer);
            if (action.isEndGame(ball, displayHeight))
            {
                NewGame();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture2D, backgroundRectangle, Color.White);
            ball.Draw(spriteBatch);
            racket1.Draw(spriteBatch);
            racketComputer.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
