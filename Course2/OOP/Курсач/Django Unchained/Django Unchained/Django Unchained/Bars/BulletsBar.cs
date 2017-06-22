using System;
using Django_Unchained.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Bars
{
    public class BulletsBar : Entity
    {
        public static int allBullets;
        public static int points;

        protected readonly SpriteFont font;
        protected string message;

        public BulletsBar(Game game, Texture2D texture2D, SpriteFont font, Point coordinatesPoint, int squareSize)
            : base(game, texture2D)
        {
            message = "Bullets";
            this.font = font;
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, 0, texture2D.Height);
            IsGravity = false;
            isScrolling = false;
        }

        public BulletsBar(Game game)
            : base(game, ContentContainer.bulletsBarTexture2D)
        {
            message = "Bullets";
            font = ContentContainer.font;
            IsGravity = false;
            isScrolling = false;
        }

        public override void Update(GameTime gameTime)
        {
            PositionRectangle = new Rectangle(PositionRectangle.Left, PositionRectangle.Top, points * 10, PositionRectangle.Bottom);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.DrawString(font, Convert.ToString(allBullets),
                new Vector2(PositionRectangle.Left + 100, PositionRectangle.Top), Color.Black);
            spriteBatch.DrawString(font, points + message, new Vector2(PositionRectangle.Left, PositionRectangle.Bottom), Color.Gold);
            base.Draw(gameTime);
        }
    }
}
