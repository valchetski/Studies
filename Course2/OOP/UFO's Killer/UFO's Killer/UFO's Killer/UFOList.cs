using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UFO_s_Killer
{
    class UFOList :List<UFO>
    {
        private Texture2D mainTexture2D;

        public UFOList(int numberOfUFOes, int minSpeed, int maxSpeed, Texture2D _texture2D, int screenWidth, int screenHeight)
        {
            LoadContent(_texture2D);
            var previousX = 0;
            var random = new Random();
            for (var i = 0; i < numberOfUFOes; i++)
            {
                var ufo = RandomUFO(minSpeed, maxSpeed, screenWidth, screenHeight, random);
                ufo.rectangle.X += previousX;
                previousX += ufo.rectangle.Width;
                Add(ufo);
            }
        }
        public UFOList() { }
        public void LoadContent(Texture2D _texture2D)
        {
            mainTexture2D = _texture2D;
        }

        private UFO RandomUFO(int minSpeedX, int maxSpeedX, int screenWidth, int screenHeight, Random random)
        {
            var ufoSizeVector2 = new Vector2(70,50);
            var speedX = random.Next(minSpeedX, maxSpeedX) + 1;
            var speedY = (float)random.NextDouble() + 0.1f;

            var startPositionY = random.Next(screenHeight/4, (3*screenHeight)/4);
            return (new UFO(mainTexture2D, new Rectangle(screenWidth, startPositionY, Convert.ToInt32(ufoSizeVector2.X), Convert.ToInt32(ufoSizeVector2.Y)), speedX, speedY));
        }

        public void Update(int screenWidth, int screenHeigth)
        {
            var deletedElements = new UFOList();
            foreach (var ufo in this)
            {
                if (ufo.state != UFOState.Stop)
                {
                    ufo.Update(screenWidth, screenHeigth);
                }
                else
                {
                    deletedElements.Add(ufo);
                }
            }
            foreach (var deletedElement in deletedElements)
            {
                Remove(deletedElement);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ufo in this)
            {
                if (ufo.state != UFOState.Fall)
                {
                    ufo.Draw(spriteBatch);
                }
                else
                {
                    ufo.DrawFall(spriteBatch, 0.1f);
                }
            }
        }
    }
}
