using Django_Unchained.Entities.Immovable_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities.Bonuses
{
    public class HealthBonus : ImmovableObject
    {
        private readonly int addingHealthPoints;
        private readonly SoundEffect gotBonusSoundEffect;
        public HealthBonus(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize, SoundEffect gotBonusSoundEffect)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            addingHealthPoints = 20;
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, texture2D.Width, texture2D.Height);
            this.gotBonusSoundEffect = gotBonusSoundEffect;
        }

        public HealthBonus(Game game) : base(game, ContentContainer.healthBonusTexture2D, new Point(0, 0), 0)
        {
            addingHealthPoints = 20;
            gotBonusSoundEffect = ContentContainer.gotBonusSoundEffect;
        }

        public int GetBonus()
        {
            MusicPlayer.PlaySoundEffect(gotBonusSoundEffect);
            Game.Components.Add(new Message(Game, ContentContainer.getHealthMessageTexture2D));
            Game.Components.Remove(this);
            return addingHealthPoints;
        }
    }
}
