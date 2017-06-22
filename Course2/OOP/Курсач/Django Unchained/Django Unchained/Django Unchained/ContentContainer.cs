using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained
{
    public  class ContentContainer : DrawableGameComponent
    {
        public static Texture2D platformTexture2D;

        public static Texture2D healthBarTexture2D;
        public static Texture2D healthBonusTexture2D;
        public static SpriteFont font;

        public static Texture2D bulletTexture2D;
        public static Texture2D bulletsBarTexture2D;
        public static Texture2D bulletsBonusTexture2D;

        public static Texture2D speedBonusTexture2D;

        public static Texture2D djangoTexture2D;
        public static Texture2D enemyTexture2D;

        public static Texture2D grenadeTexture2D;

        public static Texture2D powderKegTexture2D;

        public static Texture2D cactusTexture2D;

        public static Texture2D explosionTexture2D;

        public static Texture2D mineTexture2D;

        public static Texture2D backgroundTexture2D;

        public static Texture2D youDiedTexture2D;
        public static Texture2D xSpeedTexture2D;
        public static Texture2D getHealthMessageTexture2D;
        public static Texture2D getBulletsMessageTexture2D;
        public static Texture2D gameWasSavedTexture2D;

        public static Texture2D newGameMenuTexture2D;
        public static Texture2D continueMenuTexture2D;
        public static Texture2D settingsMenuTexture2D;
        public static Texture2D howToPlayMenuTexture2D;
        public static Texture2D exitMenuTexture2D;
        public static Texture2D menuBackgroundTexture2D;
        public static Texture2D nameOfTheGameTexture2D;

        public static Texture2D screenResolutionSettingsTexture2D;
        public static Texture2D fullscreenSettingsTexture2D;
        public static Texture2D musicSettingsTexture2D;
        public static Texture2D soundsSettingsTexture2D;
        public static Texture2D r800X600SettingsTexture2D;
        public static Texture2D r1280X1024SettingsTexture2D;
        public static Texture2D r1366X768SettingsTexture2D;
        public static Texture2D onSettingsTexture2D;
        public static Texture2D offSettingsTexture2D;

        public static Texture2D howToPlayInstructionTexture2D;
        public static Texture2D howToPlayBackgroundTexture2D;

        public static Texture2D winBackgroundTexture2D;
        public static Texture2D winTextTexture2D;

        public static Song menuSong;
        public static Song gameSong;
        public static Song winSong;

        public static SoundEffect shotDjangoSoundEffect;
        public static SoundEffect shotEnemySoundEffect;
        public static SoundEffect powderKegExplosionSoundEffect;
        public static SoundEffect grenadeExplosionSoundEffect;
        public static SoundEffect gotBonusSoundEffect;
        public static SoundEffect hurtSoundEffect;
        public static SoundEffect emptySoundEffect;
        public static SoundEffect timerSoundEffect;

        private readonly ContentManager content;

        public ContentContainer(Game game) : base(game)
        {
            content = new ContentManager(Game.Services, "Content");
        }

        public new void LoadContent()
        {
            djangoTexture2D = content.Load<Texture2D>("Sprites\\sprite");
            platformTexture2D = content.Load<Texture2D>("Sprites\\ground");
            healthBarTexture2D = content.Load<Texture2D>("Sprites\\healthBar");
            healthBonusTexture2D = content.Load<Texture2D>("Sprites\\firstAidKit");
            enemyTexture2D = content.Load<Texture2D>("Sprites\\enemy");
            font = content.Load<SpriteFont>("Fonts\\SpriteFont1");
            bulletTexture2D = content.Load<Texture2D>("Sprites\\bullet");
            grenadeTexture2D = content.Load<Texture2D>("Sprites\\grenade");
            bulletsBarTexture2D = content.Load<Texture2D>("Sprites\\bulletsBar");
            bulletsBonusTexture2D = content.Load<Texture2D>("Sprites\\bulletsBonus");
            powderKegTexture2D = content.Load<Texture2D>("Sprites\\powderKeg");
            cactusTexture2D = content.Load<Texture2D>("Sprites\\cactus");
            explosionTexture2D = content.Load<Texture2D>("Sprites\\explosion");
            backgroundTexture2D = content.Load<Texture2D>("Sprites\\background");
            speedBonusTexture2D = content.Load<Texture2D>("Sprites\\speedBonus");
            youDiedTexture2D = content.Load<Texture2D>("Sprites\\youDied");
            xSpeedTexture2D = content.Load<Texture2D>("Sprites\\2xSpeed");
            getHealthMessageTexture2D = content.Load<Texture2D>("Sprites\\getHealthMessage");
            getBulletsMessageTexture2D = content.Load<Texture2D>("Sprites\\getBulletsMessage");
            newGameMenuTexture2D = content.Load<Texture2D>("Sprites\\newGameMenu");
            continueMenuTexture2D = content.Load<Texture2D>("Sprites\\continueMenu");
            exitMenuTexture2D = content.Load<Texture2D>("Sprites\\exitMenu");
            menuBackgroundTexture2D = content.Load<Texture2D>("Sprites\\menuBackground");
            nameOfTheGameTexture2D = content.Load<Texture2D>("Sprites\\nameOfTheGame");
            winBackgroundTexture2D = content.Load<Texture2D>("Sprites\\winBackground");
            winTextTexture2D = content.Load<Texture2D>("Sprites\\winText");
            menuSong = content.Load<Song>("Songs\\menuSong");
            gameSong = content.Load<Song>("Songs\\gameSong");
            winSong = content.Load<Song>("Songs\\winSong");
            shotDjangoSoundEffect = content.Load<SoundEffect>("SoundEffects\\shotDjango");
            shotEnemySoundEffect = content.Load<SoundEffect>("SoundEffects\\shotEnemy");
            powderKegExplosionSoundEffect = content.Load<SoundEffect>("SoundEffects\\powderKegExplosion");
            grenadeExplosionSoundEffect = content.Load<SoundEffect>("SoundEffects\\powderKegExplosion");
            gotBonusSoundEffect = content.Load<SoundEffect>("SoundEffects\\gotBonus");
            hurtSoundEffect = content.Load<SoundEffect>("SoundEffects\\hurt");
            emptySoundEffect = content.Load<SoundEffect>("SoundEffects\\empty");
            timerSoundEffect = content.Load<SoundEffect>("SoundEffects\\timer");
            mineTexture2D = content.Load<Texture2D>("Sprites\\mine");
            gameWasSavedTexture2D = content.Load<Texture2D>("Sprites\\gameWasSaved");
            settingsMenuTexture2D = content.Load<Texture2D>("Sprites\\settingsMenu");
            howToPlayMenuTexture2D = content.Load<Texture2D>("Sprites\\howToPlayMenu");
            howToPlayInstructionTexture2D = content.Load<Texture2D>("Sprites\\howToPlayInstruction");
            howToPlayBackgroundTexture2D = content.Load<Texture2D>("Sprites\\howToPlayBackground");
            screenResolutionSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\screenResolutionSettings");
            musicSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\musicSettings");
            soundsSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\soundsSettings");
            r800X600SettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\800X600Settings"); 
            r1280X1024SettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\1280X1024Settings"); 
            r1366X768SettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\1366X768Settings"); 
            onSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\onSettings"); 
            offSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\offSettings");
            fullscreenSettingsTexture2D = content.Load<Texture2D>("SettingsMenu\\fullscreenSettings"); 
        }
    }
}
