using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using UFO_s_Killer.Enums;

namespace UFO_s_Killer
{
    class Menu
    {
        public Texture2D menuTexture;
        public Rectangle menuRectangle;

        public Texture2D menuLogo;
        public Rectangle menuLocoRectangle;

        public Texture2D cursorGame;
        public Vector2 cursorPositionGame;

        public Texture2D cursorExit;
        public Vector2 cursorPositionExit;

        private MenuState menuState = MenuState.Open;
        private CursorState cursorState = CursorState.Play;

        private Song mainThemeSong;

        private int choosePointMenuX;
        private int notChoosePointMenuX;
        private int higherPointMenuY;
        private int stepY;

        private KeyboardState pastKey;

        public Menu()
        {
            menuRectangle = new Rectangle(0, 0, 1366, 768);
            choosePointMenuX = 500;
            notChoosePointMenuX = 550;
            higherPointMenuY = 300;
            stepY = 150;
            cursorPositionGame = new Vector2(choosePointMenuX, higherPointMenuY);
            cursorPositionExit = new Vector2(notChoosePointMenuX, higherPointMenuY + stepY);
            pastKey = Keyboard.GetState();
        }

        public void Load(Texture2D menuLogo, Texture2D _menuTexture2D, Texture2D _cursorGameTexture2D, Texture2D _cursorExitTexture2D, Song _mainThemeSong)
        {
            this.menuLogo = menuLogo;
            menuLocoRectangle = new Rectangle(350, 30, menuLogo.Width, menuLogo.Height);
            menuTexture = _menuTexture2D;
            cursorGame = _cursorGameTexture2D;
            cursorExit = _cursorExitTexture2D;
            mainThemeSong = _mainThemeSong;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuTexture, menuRectangle, Color.White);
            spriteBatch.Draw(menuLogo, menuLocoRectangle, Color.White);

            switch (cursorState)
            {
                case CursorState.Play:

                    spriteBatch.Draw(cursorGame, cursorPositionGame, Color.Yellow);
                    spriteBatch.Draw(cursorExit, cursorPositionExit, Color.White);
                    break;

                case CursorState.Exit:

                    spriteBatch.Draw(cursorGame, cursorPositionGame, Color.White);
                    spriteBatch.Draw(cursorExit, cursorPositionExit, Color.Yellow);
                    break;
            }
        }

        public GameState Update()
        {
            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(mainThemeSong);
            }
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                cursorPositionGame = new Vector2(choosePointMenuX, higherPointMenuY);
                cursorPositionExit = new Vector2(notChoosePointMenuX, higherPointMenuY + stepY);
                cursorState = CursorState.Play;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                cursorPositionGame = new Vector2(notChoosePointMenuX, higherPointMenuY);
                cursorPositionExit = new Vector2(choosePointMenuX, higherPointMenuY + stepY);
                cursorState = CursorState.Exit;
            }

            var gameState = GameState.ContinuePlay;
            if (keyboardState.IsKeyDown(Keys.Enter) && cursorState == CursorState.Play)
            {
                gameState = GameState.NewGame;
                menuState = MenuState.Closed;
                MediaPlayer.Stop();
            }
            else if (keyboardState.IsKeyDown(Keys.Enter) && cursorState == CursorState.Exit)
            {
                gameState = GameState.Exit;
            }
            return gameState;
        }

        public MenuState GetState
        {
            get
            {
                var presentKey = Keyboard.GetState();
                if ((presentKey.IsKeyDown(Keys.Escape)) && pastKey.IsKeyUp(Keys.Escape))
                {
                    menuState = menuState == MenuState.Open ? MenuState.Closed : MenuState.Open;
                    MediaPlayer.Stop();
                }
                pastKey = presentKey;
                return menuState;
            }
        }
    }
}
