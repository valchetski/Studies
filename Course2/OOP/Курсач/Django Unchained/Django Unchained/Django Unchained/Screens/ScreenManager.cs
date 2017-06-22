using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Django_Unchained.Screens
{
    public class ScreenManager : DrawableGameComponent
    {
        private static List<Screen> screens;
        private static Screen currentScreen;

        public bool isInitialize;

        public ScreenManager(Game game) :base(game){}

        public override void Initialize()
        {
            screens = new List<Screen> {new MenuScreen(Game), new GameScreen(Game), new SettingsScreen(Game), new HowToPlayScreen(Game), new WinScreen(Game)};
            currentScreen = screens.FirstOrDefault();
            isInitialize = true;
            base.Initialize();
        }

        public bool IsCurrentGameScreen()
        {
            return currentScreen is GameScreen;
        }


        public static void SetGameScreen()
        {
            SetScreen<GameScreen>();
        }

        public static void SetMenuScreen()
        {
            SetScreen<MenuScreen>();
        }

        public static void SetSettingsScreen()
        {
            SetScreen<SettingsScreen>();
        }

        public static void SetHowToPlayScreen()
        {
            SetScreen<HowToPlayScreen>();
        }

        public static void SetWinScreen()
        {
            SetScreen<WinScreen>();
        }

        private static void SetScreen<T>()
        {
            screens.Remove(screens.FirstOrDefault(s => s.GetType() == currentScreen.GetType()));
            screens.Add(currentScreen);
            currentScreen = screens.FirstOrDefault(s => s is T);
            if (currentScreen != null)
            {
                currentScreen.Checked();
            }
        }

        public override void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            currentScreen.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
