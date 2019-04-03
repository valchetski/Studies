using Django_Unchained.Bars;
using Django_Unchained.Entities;
using Django_Unchained.Entities.Bonuses;
using Django_Unchained.Levels;
using Django_Unchained.Weapons;
using Microsoft.Xna.Framework;

namespace Django_Unchained.SaveAndLoad
{
    public class ConvertTo : GameComponent
    {
        public ConvertTo(Game game) : base(game){}

        #region Convert to SavingObject
        public static SavingObject SavingObject(Django django)
        {
            return
                (new SavingObject(django.HealthPoints, django.AllBullets, django.PositionRectangle,
                    -1, -1, -1, django.FrameSizePoint, django.GetType()));
        }
        public static SavingObject SavingObject(Enemy enemy)
        {
            return
                (new SavingObject(enemy.HealthPoints, enemy.AllBullets, enemy.PositionRectangle,
                    -1, -1, -1, enemy.FrameSizePoint, enemy.GetType()));
        }

        public static SavingObject SavingObject(HealthBonus healthBonus)
        {
            return
                (new SavingObject(-1, -1, healthBonus.PositionRectangle,
                    -1, -1, -1, new Point(-1,-1), healthBonus.GetType()));
        }
        public static SavingObject SavingObject(Platform platform)
        {
            return
                (new SavingObject(-1, -1, platform.PositionRectangle,
                    -1, -1, -1, new Point(-1, -1), platform.GetType()));
        }
        public static SavingObject SavingObject(Level level)
        {
            return
                (new SavingObject(-1, -1, default(Rectangle),
                    Level.screenLeftX, Level.Length, Level.currentLevel, new Point(-1, -1), level.GetType()));
        }
        public static SavingObject SavingObject(HealthBar healthBar)
        {
            return
                (new SavingObject(-1, -1, healthBar.PositionRectangle,
                    -1, -1, -1, new Point(-1, -1), healthBar.GetType()));
        }
        public static SavingObject SavingObject(BulletsBar bulletsBar)
        {
            return
                (new SavingObject(-1, -1, bulletsBar.PositionRectangle,
                    -1, -1, -1, new Point(-1, -1), bulletsBar.GetType()));
        }
        #endregion

        public Django Django(SavingObject savingObject)
        {
            return new Django(Game, new GrenadeWeapon(Game, ContentContainer.grenadeTexture2D))
            {
                AllBullets = savingObject.allBullets,
                HealthPoints = savingObject.healthPoints,
                PositionRectangle = savingObject.positionRectangle,
                FrameSizePoint = savingObject.frameSizePoint
            };
        }

        public Platform Platform(SavingObject savingObject)
        {
            return new Platform(Game) { PositionRectangle = savingObject.positionRectangle };
        }

        public HealthBar HealthBar(SavingObject savingObject)
        {
            return new HealthBar(Game) { PositionRectangle = savingObject.positionRectangle};
        }

        public BulletsBar BulletsBar(SavingObject savingObject)
        {
            return new BulletsBar(Game) { PositionRectangle = savingObject.positionRectangle };
        }

        public HealthBonus HealthBonus(SavingObject savingObject)
        {
            return new HealthBonus(Game) { PositionRectangle = savingObject.positionRectangle };
        }

        public Enemy Enemy(SavingObject savingObject)
        {
            return new Enemy(Game)
            {
                AllBullets = savingObject.allBullets,
                HealthPoints = savingObject.healthPoints,
                PositionRectangle = savingObject.positionRectangle,
                FrameSizePoint = savingObject.frameSizePoint
            };
        }

        public Level Level1(SavingObject savingObject)
        {
            Level.screenLeftX = savingObject.leftScreenX;
            Level.Length = savingObject.length;
            Level.currentLevel = savingObject.currentLevel;
            return new Level(Game);
        }
    }
}
