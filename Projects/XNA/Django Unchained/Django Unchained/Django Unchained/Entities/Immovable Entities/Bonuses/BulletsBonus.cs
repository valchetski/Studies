using Django_Unchained.Entities.Immovable_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities.Bonuses
{
    class BulletsBonus : ImmovableObject
    {
        private readonly int addingBullets;
        private readonly SoundEffect gotBonusSoundEffect;
        public BulletsBonus(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize, SoundEffect gotBonusSoundEffect)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            addingBullets = 10;
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, texture2D.Width, texture2D.Height);
            this.gotBonusSoundEffect = gotBonusSoundEffect;
        }

        /// <summary>
        /// Персонаж берет бонус и бонус удаляется с уровня
        /// </summary>
        /// <returns>Количество очков здоровья</returns>
        public int GetBonus()
        {
            MusicPlayer.PlaySoundEffect(gotBonusSoundEffect);
            Game.Components.Add(new Message(Game, ContentContainer.getBulletsMessageTexture2D));
            Game.Components.Remove(this);
            return addingBullets;
        }
    }
}
