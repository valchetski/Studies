using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities.Immovable_Entities.Bonuses
{
    public class SpeedBonus : ImmovableObject
    {
        private readonly TimeSpan lifeTime;
        private readonly int xSpeed;//увеличит скорость в столько то раз
        private readonly SoundEffect gotBonusSoundEffect;
        public SpeedBonus(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize, SoundEffect gotBonusSoundEffect)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            xSpeed = 2;
            lifeTime = new TimeSpan(0,0,5);
            PositionRectangle = new Rectangle(coordinatesPoint.X * squareSize, coordinatesPoint.Y * squareSize, texture2D.Width, texture2D.Height);
            this.gotBonusSoundEffect = gotBonusSoundEffect;
        }

        public KeyValuePair<int, TimeSpan> GetBonus()
        {
            MusicPlayer.PlaySoundEffect(gotBonusSoundEffect);
            Game.Components.Remove(this);
            Game.Components.Add(new Message(Game, ContentContainer.xSpeedTexture2D));
            return new KeyValuePair<int, TimeSpan>(xSpeed, lifeTime);
        }
    }
}
