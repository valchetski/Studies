using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    public class Bullets : List<Bullet>
    {
        /// <summary>
        /// Количество всех пуль
        /// </summary>
        public int Number
        {
            get { return Count; }
            set
            {
                if (value > Count)
                {
                    AddMore(value - Count);
                }
            }
        }

        private readonly Game game;
        private readonly Texture2D texture2D;
        public Bullets(Game game, Texture2D texture2D, int allBullets)
        {
            this.game = game;
            this.texture2D = texture2D;
            AddMore(allBullets);
        }

        private void AddMore(int countOfNewElements)
        {
            for (int i = 0; i < countOfNewElements; i++)
            {
                Add(new Bullet(game, texture2D));
            }
        }
    }
}
