using System.Collections.Generic;
using System.Linq;
using Django_Unchained.Levels;
using Django_Unchained.SaveAndLoad;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained.Screens
{
    public class GameScreen : Screen
    {
        private readonly Level level;
        
        private readonly Saves saves;
        
        private readonly Song song;
        private KeyboardState pastKey;

        public static bool isNewGame;

        private List<Keys> pressedKeys;

        public GameScreen(Game game) : base(game)
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys().ToList();
            saves = new Saves(game);
            level = new Level(game);
            song = ContentContainer.gameSong;
        }

        public override void Checked()
        {
            pressedKeys = Keyboard.GetState().GetPressedKeys().ToList();
            MusicPlayer.StopMusic(song);
            MusicPlayer.ResumeSoundEffects();
            if (isNewGame)
            {
                isNewGame = false;
                level.NewGame();
            }
            else if ((Game.Components.Count == 0) && (saves.LoadSaves() == false))
            {
                level.NewGame();
            }
        }


        public override void Update(GameTime gameTime)
        {
            MusicPlayer.PlayMusic(song);
            if(!Message.isEndOfTheGame)
            {
                var presentKey = Keyboard.GetState();
                if ((presentKey.IsKeyDown(Keys.Escape)) && (pastKey.IsKeyUp(Keys.Escape)) && (!pressedKeys.Contains(Keys.Escape)))
                {
                    ScreenManager.SetMenuScreen();
                }
                else if (pressedKeys.Contains(Keys.Escape))
                {
                    pressedKeys.Remove(Keys.Escape);
                }
                pastKey = presentKey;
                base.Update(gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                level.NewGame();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            var rectangle = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            spriteBatch.Draw(ContentContainer.backgroundTexture2D, rectangle, Color.White);

            base.Draw(gameTime);
        }
    }
}
