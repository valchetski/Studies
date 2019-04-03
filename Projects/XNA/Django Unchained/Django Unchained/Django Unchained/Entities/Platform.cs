using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    /// <summary>
    /// Кусок платформы или земли в игре 
    /// </summary>
    public class Platform : Entity
    {
        public Platform(Game game, Texture2D texture2D, int squareSize, Point coordinatesPoint) : base(game, texture2D)
        {
            PositionRectangle = new Rectangle(squareSize*coordinatesPoint.X, squareSize*coordinatesPoint.Y, squareSize,
                squareSize);
            IsGravity = false;
        }

        public Platform(Game game) : base(game, ContentContainer.platformTexture2D)
        {
            IsGravity = false;
        }
    }
}
