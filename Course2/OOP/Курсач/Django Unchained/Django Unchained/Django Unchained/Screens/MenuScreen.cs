using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained.Screens
{
    public class MenuScreen : Screen
    {
        private readonly Texture2D background;
        private readonly Rectangle backgroundRectangle;
        
        private readonly Texture2D nameOfTheGame;
        private readonly Rectangle nameOfTheGameRectangle;

        private readonly Texture2D continueMenuItem;
        private readonly Rectangle continueMenuItemRectangle;

        private readonly Texture2D newGameMenuItem;
        private readonly Rectangle newGameMenuItemRectangle;

        private readonly Texture2D settingsMenuItem;
        private readonly Rectangle settingsMenuItemRectangle;

        private readonly Texture2D howToPlayMenuItem;
        private readonly Rectangle howToPlayMenuItemRectangle;

        private readonly Texture2D exitMenuItem;
        private readonly Rectangle exitMenuItemRectangle;

        private readonly Song mainTheme;

        private int selectedItem;
        private readonly int itemsCount;

        private KeyboardState pastKey;
        private List<Keys> pressedKeys;

        public MenuScreen(Game game) 
            : base(game)
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys().ToList();
            selectedItem = 0;
            itemsCount = 5;
            int offset = Game.GraphicsDevice.Viewport.Height/10;
            int startY = Game.GraphicsDevice.Viewport.Height/50;

            mainTheme = ContentContainer.menuSong;

            background = ContentContainer.menuBackgroundTexture2D;
            backgroundRectangle = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);

            nameOfTheGame = ContentContainer.nameOfTheGameTexture2D;
            nameOfTheGameRectangle = new Rectangle(GetX(nameOfTheGame), startY, nameOfTheGame.Width,
                nameOfTheGame.Height);

            continueMenuItem = ContentContainer.continueMenuTexture2D;
            continueMenuItemRectangle = new Rectangle(GetX(continueMenuItem),
                nameOfTheGameRectangle.Bottom + offset, continueMenuItem.Width, continueMenuItem.Height);

            newGameMenuItem = ContentContainer.newGameMenuTexture2D;
            newGameMenuItemRectangle = new Rectangle(GetX(newGameMenuItem),
                continueMenuItemRectangle.Y + offset, newGameMenuItem.Width, newGameMenuItem.Height);

            settingsMenuItem = ContentContainer.settingsMenuTexture2D;
            settingsMenuItemRectangle = new Rectangle(GetX(settingsMenuItem),
                newGameMenuItemRectangle.Y + offset, settingsMenuItem.Width, settingsMenuItem.Height);

            howToPlayMenuItem = ContentContainer.howToPlayMenuTexture2D;
            howToPlayMenuItemRectangle = new Rectangle(GetX(howToPlayMenuItem),
                settingsMenuItemRectangle.Y + offset, howToPlayMenuItem.Width, howToPlayMenuItem.Height);

            exitMenuItem = ContentContainer.exitMenuTexture2D;
            exitMenuItemRectangle = new Rectangle(GetX(exitMenuItem),
                howToPlayMenuItemRectangle.Y + offset, exitMenuItem.Width, exitMenuItem.Height);
        }

        public override void Checked()
        {
            MusicPlayer.StopMusic(mainTheme);
            MusicPlayer.PauseSoundEffects();

            selectedItem = 0;
            pastKey = new KeyboardState();
            pressedKeys = Keyboard.GetState().GetPressedKeys().ToList();
        }

        /// <summary>
        /// Возвращает крайнюю левую координату Х, при которой текстурка
        /// будет находится по центру экрана
        /// </summary>
        private int GetX(Texture2D texture)
        {
            return (Game.GraphicsDevice.Viewport.Width - texture.Width)/2;
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

            if ((presentKey.IsKeyDown(Keys.Enter)) && (pastKey.IsKeyUp(Keys.Enter)))
            {
                switch (selectedItem)
                {
                    case 0:
                        GameScreen.isNewGame = false;
                        ScreenManager.SetGameScreen();
                        break;
                    case 1:
                        GameScreen.isNewGame = true;
                        ScreenManager.SetGameScreen();
                        break;
                    case 2:
                        ScreenManager.SetSettingsScreen();
                        break;
                    case 3:
                        ScreenManager.SetHowToPlayScreen();
                        break;
                    case 4:
                        Game.Exit();
                        break;
                }
            }

            if ((presentKey.IsKeyDown(Keys.Escape)) && (pastKey.IsKeyUp(Keys.Escape)) && (!pressedKeys.Contains(Keys.Escape)))
            {
                if (Game.Components.Count > 0)
                {
                    GameScreen.isNewGame = false;
                    ScreenManager.SetGameScreen();
                }
            }
            else if(pressedKeys.Contains(Keys.Escape))
            {
                pressedKeys.Remove(Keys.Escape);
            }
            pastKey = presentKey;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            spriteBatch.Draw(background, backgroundRectangle, Color.White);
            spriteBatch.Draw(nameOfTheGame, nameOfTheGameRectangle, Color.White);
            var selectionColor = Color.DarkViolet;
            switch (selectedItem)
            {
                case 0:
                    spriteBatch.Draw(continueMenuItem, continueMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(newGameMenuItem, newGameMenuItemRectangle, Color.White);
                    spriteBatch.Draw(settingsMenuItem, settingsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(howToPlayMenuItem, howToPlayMenuItemRectangle, Color.White);
                    spriteBatch.Draw(exitMenuItem, exitMenuItemRectangle, Color.White);
                    break;
                case 1:
                    spriteBatch.Draw(continueMenuItem, continueMenuItemRectangle, Color.White);
                    spriteBatch.Draw(newGameMenuItem, newGameMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(settingsMenuItem, settingsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(howToPlayMenuItem, howToPlayMenuItemRectangle, Color.White);
                    spriteBatch.Draw(exitMenuItem, exitMenuItemRectangle, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(continueMenuItem, continueMenuItemRectangle, Color.White);
                    spriteBatch.Draw(newGameMenuItem, newGameMenuItemRectangle, Color.White);
                    spriteBatch.Draw(settingsMenuItem, settingsMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(howToPlayMenuItem, howToPlayMenuItemRectangle, Color.White);
                    spriteBatch.Draw(exitMenuItem, exitMenuItemRectangle, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(continueMenuItem, continueMenuItemRectangle, Color.White);
                    spriteBatch.Draw(newGameMenuItem, newGameMenuItemRectangle, Color.White);
                    spriteBatch.Draw(settingsMenuItem, settingsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(howToPlayMenuItem, howToPlayMenuItemRectangle, selectionColor);
                    spriteBatch.Draw(exitMenuItem, exitMenuItemRectangle, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(continueMenuItem, continueMenuItemRectangle, Color.White);
                    spriteBatch.Draw(newGameMenuItem, newGameMenuItemRectangle, Color.White);
                    spriteBatch.Draw(settingsMenuItem, settingsMenuItemRectangle, Color.White);
                    spriteBatch.Draw(howToPlayMenuItem, howToPlayMenuItemRectangle, Color.White);
                    spriteBatch.Draw(exitMenuItem, exitMenuItemRectangle, selectionColor);
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
