using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained.Screens
{
    public class SettingsScreen : Screen
    {
        private readonly Texture2D background;
        private readonly Rectangle backgroundRectangle;

        private readonly Texture2D nameOfTheMenu;
        private readonly Rectangle nameOfTheMenuRectangle;

        private readonly Texture2D screenResolutionMenuItem;
        private readonly Rectangle screenResolutionMenuItemRectangle;
        private readonly List<Texture2D> resolutionsList;
        private int currentResolutionIndex;

        private readonly Texture2D fullscreenMenuItem;
        private readonly Rectangle fullscreenMenuItemRectangle;
        private bool isFullscreen;

        private readonly Texture2D musicMenuItem;
        private readonly Rectangle musicMenuItemRectangle;
        private bool isMusicOn;

        private readonly Texture2D soundsMenuItem;
        private readonly Rectangle soundsMenuItemRectangle;
        private bool isSoundsOn;

        private readonly List<Texture2D> onOffList;
 
        private readonly Song mainTheme;

        private int selectedItem;
        private KeyboardState pastKey;
        private readonly int itemsCount;

        public SettingsScreen(Game game)
            : base(game)
        {
            selectedItem = 0;
            switch (Settings.ScreenWidth)
            {
                case 800:
                    currentResolutionIndex = 0;
                    break;
                case 1280:
                    currentResolutionIndex = 1;
                    break;
                case 1366:
                    currentResolutionIndex = 2;
                    break;
            }
            isFullscreen = Settings.IsFullscreen;
            isMusicOn = Settings.IsMusicOn;
            isSoundsOn = Settings.IsSoundsOn;
            itemsCount = 4;
            const int offset = 70;
            int startY = Game.GraphicsDevice.Viewport.Height / 10;
            

            mainTheme = ContentContainer.menuSong;

            background = ContentContainer.menuBackgroundTexture2D;
            backgroundRectangle = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);

            nameOfTheMenu = ContentContainer.settingsMenuTexture2D;
            nameOfTheMenuRectangle = new Rectangle(GetX(nameOfTheMenu), startY, nameOfTheMenu.Width,
                nameOfTheMenu.Height);

            int offsetX = nameOfTheMenuRectangle.X - Game.GraphicsDevice.Viewport.Width / 30;
            screenResolutionMenuItem = ContentContainer.screenResolutionSettingsTexture2D;
            screenResolutionMenuItemRectangle = new Rectangle(offsetX,
                (int)(nameOfTheMenuRectangle.Bottom + 1.2 * offset), screenResolutionMenuItem.Width, screenResolutionMenuItem.Height);
            resolutionsList = new List<Texture2D>
            {
                ContentContainer.r800X600SettingsTexture2D,
                ContentContainer.r1280X1024SettingsTexture2D,
                ContentContainer.r1366X768SettingsTexture2D
            };

            fullscreenMenuItem = ContentContainer.fullscreenSettingsTexture2D;
            fullscreenMenuItemRectangle = new Rectangle(offsetX, screenResolutionMenuItemRectangle.Y + offset,
                fullscreenMenuItem.Width, fullscreenMenuItem.Height);

            musicMenuItem = ContentContainer.musicSettingsTexture2D;
            musicMenuItemRectangle = new Rectangle(offsetX,
                fullscreenMenuItemRectangle.Y + offset, musicMenuItem.Width, musicMenuItem.Height);

            soundsMenuItem = ContentContainer.soundsSettingsTexture2D;
            soundsMenuItemRectangle = new Rectangle(offsetX,
                musicMenuItemRectangle.Y + offset, soundsMenuItem.Width, soundsMenuItem.Height);

            onOffList = new List<Texture2D>
            {
                ContentContainer.offSettingsTexture2D,
                ContentContainer.onSettingsTexture2D
            };
        }

        public override void Checked()
        {
            selectedItem = 0;
            pastKey = Keyboard.GetState();
            MusicPlayer.StopMusic(mainTheme);
        }

        /// <summary>
        /// Возвращает крайнюю левую координату Х, при которой текстурка
        /// будет находится по центру экрана
        /// </summary>
        private int GetX(Texture2D texture)
        {
            return (Game.GraphicsDevice.Viewport.Width - texture.Width) / 2;
        }

        public override void Update(GameTime gameTime)
        {
            MusicPlayer.PlayMusic(mainTheme);
            var presentKey = Keyboard.GetState();
            if ((presentKey.IsKeyDown(Keys.Down)) && (pastKey.IsKeyUp(Keys.Down)))
            {
                selectedItem = (selectedItem < itemsCount - 1) ? selectedItem + 1 : 0;
            }
            if ((presentKey.IsKeyDown(Keys.Up)) && (pastKey.IsKeyUp(Keys.Up)))
            {
                selectedItem = (selectedItem > 0) ? selectedItem - 1 : itemsCount - 1;
            }

            if ((presentKey.IsKeyDown(Keys.Left)) && (pastKey.IsKeyUp(Keys.Left)))
            {
                switch (selectedItem)
                {
                    case 0:
                        currentResolutionIndex = (currentResolutionIndex > 0) ? currentResolutionIndex - 1 : resolutionsList.Count - 1;
                        break;
                    case 1:
                        isFullscreen = !isFullscreen;
                        break;
                    case 2:
                        isMusicOn = !isMusicOn;
                        break;
                    case 3:
                        isSoundsOn = !isSoundsOn;
                        break;
                }
            }

            if ((presentKey.IsKeyDown(Keys.Right)) && (pastKey.IsKeyUp(Keys.Right)))
            {
                switch (selectedItem)
                {
                    case 0:
                        currentResolutionIndex = (currentResolutionIndex < resolutionsList.Count - 1) ? currentResolutionIndex + 1 : 0;
                        break;
                    case 1:
                        isFullscreen = !isFullscreen;
                        break;
                    case 2:
                        isMusicOn = !isMusicOn;
                        break;
                    case 3:
                        isSoundsOn = !isSoundsOn;
                        break;
                }
            }

            if ((presentKey.IsKeyDown(Keys.Escape)) && (pastKey.IsKeyUp(Keys.Escape)))
            {
                switch (currentResolutionIndex)
                {
                    case 0:
                        Settings.ScreenWidth = 800;
                        Settings.ScreenHeight = 600;
                        break;
                    case 1:
                        Settings.ScreenWidth = 1280;
                        Settings.ScreenHeight = 1024;
                        break;
                    case 2:
                        Settings.ScreenWidth = 1366;
                        Settings.ScreenHeight = 768;
                        break;
                }
                Settings.IsFullscreen = isFullscreen;
                Settings.IsMusicOn = isMusicOn;
                Settings.IsSoundsOn = isSoundsOn;
                Settings.isChanged = true;
                Settings.Save();
            }
            pastKey = presentKey;
            if (Settings.isChanged)
            {
                ScreenManager.SetMenuScreen();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(background, backgroundRectangle, Color.White);
            spriteBatch.Draw(nameOfTheMenu, nameOfTheMenuRectangle, Color.White);
            var selectionColor = Color.DarkViolet;
            var resolutionRectangle = new Rectangle(screenResolutionMenuItemRectangle.Right + 40,
                screenResolutionMenuItemRectangle.Y, resolutionsList[currentResolutionIndex].Width,
                resolutionsList[currentResolutionIndex].Height);

            var fullscreenOnOffRectangle = new Rectangle(resolutionRectangle.X, fullscreenMenuItemRectangle.Y,
                onOffList[Convert.ToInt32(isFullscreen)].Width, onOffList[Convert.ToInt32(isFullscreen)].Height);
            var musicOnOffRectangle = new Rectangle(resolutionRectangle.X, musicMenuItemRectangle.Y,
                onOffList[Convert.ToInt32(isMusicOn)].Width, onOffList[Convert.ToInt32(isMusicOn)].Height);
            var soundsOnOffRectangle = new Rectangle(resolutionRectangle.X, soundsMenuItemRectangle.Y,
                onOffList[Convert.ToInt32(isSoundsOn)].Width, onOffList[Convert.ToInt32(isSoundsOn)].Height);

            switch (selectedItem)
            {
                case 0:
                    spriteBatch.Draw(screenResolutionMenuItem, screenResolutionMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(resolutionsList[currentResolutionIndex], resolutionRectangle, selectionColor);

                    spriteBatch.Draw(fullscreenMenuItem, fullscreenMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isFullscreen)], fullscreenOnOffRectangle, Color.White);

                    spriteBatch.Draw(musicMenuItem, musicMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isMusicOn)], musicOnOffRectangle, Color.White);

                    spriteBatch.Draw(soundsMenuItem, soundsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isSoundsOn)], soundsOnOffRectangle, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(screenResolutionMenuItem, screenResolutionMenuItemRectangle, Color.White);
                    spriteBatch.Draw(resolutionsList[currentResolutionIndex], resolutionRectangle, Color.White);

                    spriteBatch.Draw(fullscreenMenuItem, fullscreenMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isFullscreen)], fullscreenOnOffRectangle, selectionColor);

                    spriteBatch.Draw(musicMenuItem, musicMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isMusicOn)], musicOnOffRectangle, Color.White);

                    spriteBatch.Draw(soundsMenuItem, soundsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isSoundsOn)], soundsOnOffRectangle, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(screenResolutionMenuItem, screenResolutionMenuItemRectangle, Color.White);
                    spriteBatch.Draw(resolutionsList[currentResolutionIndex], resolutionRectangle, Color.White);

                    spriteBatch.Draw(fullscreenMenuItem, fullscreenMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isFullscreen)], fullscreenOnOffRectangle, Color.White);

                    spriteBatch.Draw(musicMenuItem, musicMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isMusicOn)], musicOnOffRectangle, selectionColor);

                    spriteBatch.Draw(soundsMenuItem, soundsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isSoundsOn)], soundsOnOffRectangle, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(screenResolutionMenuItem, screenResolutionMenuItemRectangle, Color.White);
                    spriteBatch.Draw(resolutionsList[currentResolutionIndex], resolutionRectangle, Color.White);

                    spriteBatch.Draw(fullscreenMenuItem, fullscreenMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isFullscreen)], fullscreenOnOffRectangle, Color.White);

                    spriteBatch.Draw(musicMenuItem, musicMenuItemRectangle, Color.White);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isMusicOn)], musicOnOffRectangle, Color.White);

                    spriteBatch.Draw(soundsMenuItem, soundsMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(onOffList[Convert.ToInt32(isSoundsOn)], soundsOnOffRectangle, selectionColor);
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
