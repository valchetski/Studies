using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Django_Unchained.Bars;
using Django_Unchained.Entities;
using Django_Unchained.Entities.Bonuses;
using Django_Unchained.Entities.Immovable_Entities;
using Django_Unchained.Entities.Immovable_Entities.Bonuses;
using Django_Unchained.SaveAndLoad;
using Django_Unchained.Screens;
using Django_Unchained.Weapons;
using Microsoft.Xna.Framework;

namespace Django_Unchained.Levels
{
    public class Level : GameComponent
    {
        private static int length;
        public static int Length 
        {
            get { return length; }
            set
            {
                length = value;
                SetCheckPoints();
            }
        }
        public static int screenLeftX;
        public static int currentLevel;
        private static bool isNextLevel;
        private static int levelCount;

        /// <summary>
        /// Хранятся координаты каждой точки сохранения по оси X
        /// </summary>
        private static List<int> checkPoints;
        
        public Level(Game game) : base(game)
        {
            levelCount = 2;
            currentLevel = 1;
        }

        private string[,] Load(string fileName)
        {
            fileName = Directory.GetCurrentDirectory() +"\\Levels\\" + fileName;
            var map = default (string[,]);
            try
            {
                var allLines = File.ReadAllLines(fileName);
                map = new string[allLines.Length, allLines[0].Length];
                for (int x = 0; x < allLines.Length; x++)
                {
                    var line = allLines[x];
                    for (int y = 0; y < line.Length; y++)
                    {
                        if (y < allLines[0].Length) //чтобы y не вышел за пределы массива
                        {
                            map[x, y] = Convert.ToString(line[y]);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                currentLevel = 1;
                MakeLevel();
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(fileName);
            }
            return map;
        }

        private  string[,] Create(int numberOfLevel)
        {
            screenLeftX = 0;
            string fileName = String.Format("Level{0}.txt", numberOfLevel);
            return (Load(fileName));
        }

        public static void CheckForNextLevel(Django django, int countOfEnemies)
        {
            //убил всех врагов и дошел до конца уровня
            if ((currentLevel < levelCount) && (django != null) && (countOfEnemies == 0) &&
                (django.PositionRectangle.Right >= Length))
            {
                currentLevel++;
                isNextLevel = true;
            }
            else if ((currentLevel == levelCount) && (django != null) && (countOfEnemies == 0) &&
                     (django.PositionRectangle.Right >= Length))
            {
                ScreenManager.SetWinScreen();
            }
        }

        public void NewGame()
        {
            currentLevel = 1;
            Saves.DeleteSaves();
            MakeLevel();
        }

        private static void SetCheckPoints()
        {
            checkPoints = new List<int>();
            const int countOfCheckpoints = 5;
            int distanceForOneCheckpoint = Length/(countOfCheckpoints + 1);
            for (int i = 0; i < countOfCheckpoints; i++)
            {
                checkPoints.Add((i + 1) * distanceForOneCheckpoint);
            }
        }

        private void MakeLevel()
        {
            //0 - Пусто
            //p - Платформа
            //d - Джанго
            //1 - Индикатор здоровья
            //2 - Индикатор количества пуль
            //h - Бонус на здоровье
            //b - Бонус на пули
            //e - Вражына
            //k - пороховая бочка
            //c - кактус
            //s - бонус на скорость
            try
            {
                var map = Create(currentLevel);
                int squareSize = Game.GraphicsDevice.Viewport.Height/map.GetLength(0);
                    //высота и ширина квадрата на карте
                Length = squareSize*map.GetLength(1);
                Game.Components.Clear();
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        switch (map[y, x])
                        {
                            case "m":
                                Game.Components.Add(new Mine(Game, ContentContainer.mineTexture2D, new Point(x, y), squareSize,
                                    ContentContainer.powderKegExplosionSoundEffect, ContentContainer.timerSoundEffect));
                                break;
                            case "p":
                                Game.Components.Add(new Platform(Game, ContentContainer.platformTexture2D, squareSize,
                                    new Point(x, y)));
                                break;
                            case "d":
                                Game.Components.Add(new Django(Game, ContentContainer.djangoTexture2D,
                                    new Point(70, ContentContainer.djangoTexture2D.Height),
                                    new Point(x, y), squareSize, ContentContainer.shotDjangoSoundEffect, ContentContainer.hurtSoundEffect,
                                    new DesertEagle(Game, ContentContainer.bulletTexture2D), new GrenadeWeapon(Game, ContentContainer.grenadeTexture2D)));
                                break;
                            case "e":
                                Game.Components.Add(new Enemy(Game, ContentContainer.enemyTexture2D, new Point(52, ContentContainer.enemyTexture2D.Height),
                                    new Point(x, y), squareSize, ContentContainer.shotEnemySoundEffect, ContentContainer.hurtSoundEffect, new DesertEagle(Game, ContentContainer.bulletTexture2D)));
                                break;
                            case "1":
                                Game.Components.Add(new HealthBar(Game, ContentContainer.healthBarTexture2D,
                                    ContentContainer.font, new Point(x, y),
                                    squareSize));
                                break;
                            case "2":
                                Game.Components.Add(new BulletsBar(Game, ContentContainer.bulletsBarTexture2D,
                                    ContentContainer.font, new Point(x, y),
                                    squareSize));
                                break;
                            case "h":
                                Game.Components.Add(new HealthBonus(Game, ContentContainer.healthBonusTexture2D,
                                    new Point(x, y), squareSize, ContentContainer.gotBonusSoundEffect));
                                break;
                            case "b":
                                Game.Components.Add(new BulletsBonus(Game, ContentContainer.bulletsBonusTexture2D,
                                    new Point(x, y), squareSize, ContentContainer.gotBonusSoundEffect));
                                break;
                            case "s":
                                Game.Components.Add(new SpeedBonus(Game, ContentContainer.speedBonusTexture2D,
                                    new Point(x, y), squareSize, ContentContainer.gotBonusSoundEffect));
                                break;
                            case "k":
                                Game.Components.Add(new PowderKeg(Game, ContentContainer.powderKegTexture2D,
                                    new Point(x, y), squareSize, ContentContainer.powderKegExplosionSoundEffect));
                                break;
                            case "c":
                                Game.Components.Add(new Cactus(Game, ContentContainer.cactusTexture2D, new Point(x,y), squareSize));
                                break;
                        }
                    }
                }
                Game.Components.Add(this);
            }
            catch (NullReferenceException) { }
        }

        public override void Update(GameTime gameTime)
        {
            Scroll();
            Save();
            if (isNextLevel)
            {
                isNextLevel = false;
                MakeLevel();
            }

            base.Update(gameTime);
        }

        private void Scroll()
        {
            var width = Game.GraphicsDevice.Viewport.Width;
            var django = (Django)Game.Components.FirstOrDefault(dj => dj.GetType() == typeof (Django));
            if (django != null)
            {
                //прокрутка вправо
                if ((django.PositionRectangle.X - screenLeftX > width/2) &&
                    (django.PositionRectangle.X <= Length - width/2))
                {
                    screenLeftX += (django.PositionRectangle.X - screenLeftX) - width/2;
                }
                //прокрутка влево
                else if ((django.PositionRectangle.X - screenLeftX < width/2) && (django.PositionRectangle.X >= width/2))
                {
                    screenLeftX -= width/2 - (django.PositionRectangle.X - screenLeftX);
                }
            }
        }

        private void Save()
        {
            var django = (Django)Game.Components.FirstOrDefault(dj => dj.GetType() == typeof(Django));
            int checkpoint = checkPoints.FirstOrDefault();
            if ((django != null) && (checkpoint != 0) && (!django.IsInAir) && (django.PositionRectangle.X > checkpoint))
            {
                checkPoints.Remove(checkpoint);
                Saves.SaveAll(Game.Components);
                Game.Components.Add(new Message(Game, ContentContainer.gameWasSavedTexture2D));
            }
        }
    }
}
