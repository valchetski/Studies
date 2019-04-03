using System.Linq;
using Django_Unchained.Entities.Immovable_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    /// <summary>
    /// Пороховая бочка
    /// </summary>
    public class PowderKeg : ImmovableObject
    {
        /// <summary>
        /// Зона поражения взрывом
        /// </summary>
        private Rectangle bangRectangle;
        private readonly int radiusExplosion;
        private readonly int damage;
        private readonly SoundEffect explosionEffect;
        public PowderKeg(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize, SoundEffect explosionEffect)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            radiusExplosion = 100;
            damage = 50;
            this.explosionEffect = explosionEffect;
        }

        public void Bang()
        {
            MusicPlayer.PlaySoundEffect(explosionEffect);
            bangRectangle = new Rectangle(PositionRectangle.Center.X - radiusExplosion, PositionRectangle.Center.Y - radiusExplosion,
                    2 * radiusExplosion, 2 * radiusExplosion);
            for (int i = 0; i < Game.Components.Count(); i++)
            {
                if ((Game.Components[i] is Enemy) &&
                    (bangRectangle.Intersects(((Enemy) Game.Components[i]).PositionRectangle)))
                {
                    ((Enemy) (Game.Components[i])).HealthPoints -= damage;
                }
                else if ((Game.Components[i] is Django) &&
                         (bangRectangle.Intersects(((Django) Game.Components[i]).PositionRectangle)))
                {
                    ((Django) (Game.Components[i])).HealthPoints -= damage;
                }
            }
            Game.Components.Remove(this);
            Game.Components.Add(new Explosion(Game, ContentContainer.explosionTexture2D, bangRectangle, new Point(80, 80)));
        }
    }
}
