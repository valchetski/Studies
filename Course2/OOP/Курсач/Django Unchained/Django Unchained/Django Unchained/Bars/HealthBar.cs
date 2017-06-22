using Django_Unchained.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Bars
{
    public class HealthBar : Entity
    {
        public static int points;

        private SpriteFont font;
        private string message;

        public HealthBar(Game game, Texture2D texture2D, SpriteFont font, Point coordinatesPoint, int squareSize)
            : base(game, texture2D)
        {
            Initialization(font, coordinatesPoint, squareSize);
        }

        public HealthBar(Game game)
            : base(game, ContentContainer.healthBarTexture2D)
        {
            message = "HP";
            font = ContentContainer.font;
            IsGravity = false;
            isScrolling = false;
        }

        private void Initialization(SpriteFont newFont, Point coordinatesPoint, int squareSize)
        {
            message = "HP";
            font = newFont;
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, 0, texture2D.Height);
            IsGravity = false;
            isScrolling = false;
        }

        public override void Update(GameTime gameTime)
        {
            PositionRectangle = new Rectangle(PositionRectangle.Left, PositionRectangle.Top, points, PositionRectangle.Bottom);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.DrawString(font, points + message, new Vector2(PositionRectangle.Left, PositionRectangle.Bottom), Color.Gold);
            base.Draw(gameTime);
        }
    }
}
