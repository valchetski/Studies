using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using UFO_s_Killer.Enums;

namespace UFO_s_Killer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D backgroundTexture2D;
        private Rectangle backgroundRectangle;
        private Texture2D backgroundForWinnerTexture2D;
        private Texture2D backgroundForLoserTexture2D;

        private Sight sight;
        private UFOList ufoList;
        private Texture2D textureForUFO;
        private Action action;

        private int screenWidth;
        private int screenHeight;

        private User user;
        private SpriteFont spriteFont;

        private SoundEffect shotSongEffect;
        private SoundEffectInstance shotSongInstance;
        private SoundEffect flyAwaySound;
        private SoundEffectInstance flyAwaySoundInstance;

        private Song mainSong;

        private Menu menu;
        private GameState gameState;
        private Levels levels;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            backgroundRectangle = new Rectangle(0, 0, 1366, 768);
            action = new Action();
            user = new User(3);
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;
            graphics.IsFullScreen = true;
            menu = new Menu();
            MediaPlayer.Stop();//инициализация
            levels = new Levels();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sight = new Sight(Content.Load<Texture2D>("sight"), new Rectangle(0, 0, 50, 50));
            textureForUFO = Content.Load<Texture2D>("ufo");
            var currentLevel = levels.currentLevel;
            ufoList = new UFOList(currentLevel.ufoCount, currentLevel.minSpeed, currentLevel.maxSpeed,
                        textureForUFO, screenWidth, screenHeight);
            backgroundTexture2D = Content.Load<Texture2D>("background");
            backgroundForWinnerTexture2D = Content.Load<Texture2D>("forWinner");
            backgroundForLoserTexture2D = Content.Load<Texture2D>("forLoser");
            shotSongEffect = Content.Load<SoundEffect>("shot");
            shotSongInstance = shotSongEffect.CreateInstance();
            flyAwaySound = Content.Load<SoundEffect>("homer");
            flyAwaySoundInstance = flyAwaySound.CreateInstance();
            mainSong = Content.Load<Song>("mainSong");
            spriteFont = Content.Load<SpriteFont>("font1");
            menu.Load(Content.Load<Texture2D>("logo"), Content.Load<Texture2D>("menuBackground"), Content.Load<Texture2D>("newGame"),
                Content.Load<Texture2D>("exit"), Content.Load<Song>("x-files"));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (menu.GetState == MenuState.Closed)
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(mainSong);
                }
                if (levels.isEndGame == false)
                {
                    if (ufoList.Count == 0)
                    {
                        levels.NextLevel();
                        var currentLevel = levels.currentLevel;
                        if (currentLevel != null)
                        {
                            ufoList = new UFOList(currentLevel.ufoCount, currentLevel.minSpeed, currentLevel.maxSpeed,
                                textureForUFO, screenWidth, screenHeight);
                        }
                    }
                    if ((user.lives > 0) && (ufoList.Count > 0))
                    {
                        if (action.IsPause == false)
                        {
                            sight.Update(screenWidth, screenHeight);
                            ufoList.Update(screenWidth, screenHeight);
                            user.points += action.Shot(ref sight, ref ufoList);
                            user.lives -= action.FlyAway(ref ufoList, flyAwaySoundInstance);
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                shotSongInstance.Play();
                            }
                        }
                    }
                }
            }
            else
            {
                gameState = menu.Update(); 
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.R)) || (gameState == GameState.NewGame))
            {
                NewGame();
                gameState = GameState.ContinuePlay;
            }
            else if (gameState == GameState.Exit)
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (menu.GetState == MenuState.Closed)
            {
                spriteBatch.Draw(backgroundTexture2D, backgroundRectangle, Color.White);
                if ((levels.isEndGame) && (user.lives > 0))
                {
                    WinGameDrow();
                }
                else if(user.lives == 0)
                {
                    LostGameDrow();
                }
                else if (((user.lives > 0) && (ufoList.Count > 0)) || (levels.isEndGame == false))
                {
                    ufoList.Draw(spriteBatch);
                    sight.Draw(spriteBatch);
                    spriteBatch.DrawString(spriteFont, "Lives: " + user.lives, new Vector2(10, 10), Color.DarkRed);
                    spriteBatch.DrawString(spriteFont, "Points: " + user.points, new Vector2(10, 40), Color.DarkRed);
                    spriteBatch.DrawString(spriteFont, "Level: " + levels.currentLevel.number, new Vector2(10, 70),
                        Color.DarkRed);
                }
                
            }
            else if (menu.GetState == MenuState.Open)
            {
                menu.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void NewGame()
        {
            levels.NewGame();
            var currentLevel = levels.currentLevel;
            ufoList = new UFOList(currentLevel.ufoCount, currentLevel.minSpeed, currentLevel.maxSpeed,
                                textureForUFO, screenWidth, screenHeight);
            user.lives = 3;
            user.points = 0;
        }

        void LostGameDrow()
        {
            spriteBatch.Draw(backgroundForLoserTexture2D, backgroundRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, "You are loser!", new Vector2(screenWidth/2 - 100, screenHeight/2 - 50), Color.Gold);
            spriteBatch.DrawString(spriteFont, "Press \"R\" to restart!", new Vector2(screenWidth / 2 - 100 - 40, screenHeight / 2 - 50 + 50), Color.Gold);
        }

        void WinGameDrow()
        {
            spriteBatch.Draw(backgroundForWinnerTexture2D, backgroundRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, "You are winner!", new Vector2(screenWidth / 2 - 100, screenHeight / 2 - 50), Color.Gold);
            spriteBatch.DrawString(spriteFont, "Press \"R\" to restart!", new Vector2(screenWidth / 2 - 100 - 40, screenHeight / 2 - 50 + 50), Color.Gold);
        }
    }
}
