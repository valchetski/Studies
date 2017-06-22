using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities.Immovable_Entities
{
    /// <summary>
    /// Базовый класс для всех недвиживых объектов в игре
    /// </summary>
    public abstract class ImmovableObject : Entity
    {
        protected ImmovableObject(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize)
            : base(game, texture2D)
        {
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, texture2D.Width, texture2D.Height);
        }

        public override void Update(GameTime gameTime)
        {
            CollisionWithPlatform();
            base.Update(gameTime);
        }

        protected void CollisionWithPlatform()
        {
            var collidedEntities = CollisionWithEntities();
            foreach (var entity in  collidedEntities)
            {
                EntityHigherThanOtherEntity(entity.Key);
            }
        }
    }
}
