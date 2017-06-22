using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained
{
    public class Message : DrawableGameComponent
    {
        private readonly Texture2D texture2D;
        public static bool isEndOfTheGame;
        private TimeSpan lifeTimeSpan;
        public Message(Game game, Texture2D texture2D) : base(game)
        {
            this.texture2D = texture2D;
            isEndOfTheGame = texture2D == ContentContainer.youDiedTexture2D;
            lifeTimeSpan = new TimeSpan(0,0,1);
        }

        public override void Update(GameTime gameTime)
        {
            if (!isEndOfTheGame)
            {
                if (lifeTimeSpan > TimeSpan.Zero)
                {
                    lifeTimeSpan -= gameTime.ElapsedGameTime;
                }
                else
                {
                    Game.Components.Remove(this);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            if (!isEndOfTheGame)
            {

                spriteBatch.Draw(texture2D,
                    new Rectangle(5,
                        Game.GraphicsDevice.Viewport.Height / 10, texture2D.Width, texture2D.Height),
                    Color.White);
            }
            else
            {
                spriteBatch.Draw(texture2D,
                    new Rectangle((Game.GraphicsDevice.Viewport.Width - (int)(1.5 * texture2D.Width)) / 2,
                        Game.GraphicsDevice.Viewport.Height/2 - texture2D.Height/2, (int) (1.5*texture2D.Width),
                        (int) (1.5*texture2D.Height)),
                    Color.White);
            }
            base.Draw(gameTime);
        }
    }
}
