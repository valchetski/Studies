using System;
using System.Collections.Generic;
using System.Linq;
using Django_Unchained.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    /// <summary>
    /// Базовый класс для всех объектов в игре
    /// </summary>
    public abstract class Entity : DrawableGameComponent
    {
        #region Fields
        protected Texture2D texture2D;
        protected Rectangle rectangle;



        protected bool isScrolling;
        /// <summary>
        /// период, на который персонаж окрашивается красным во время ранения
        /// </summary>
        private readonly TimeSpan timeHeat;
        /// <summary>
        /// время, которое прошло с тех пор как персонаж был окрашен в красное
        /// </summary>
        private TimeSpan currentTimeHeat;

        /// <summary>
        /// true -- если в персонажа попала пуля, задело взрывом гранаты или бочки с порохом или уколол кактус
        /// </summary>
        protected bool isHeat;

        protected Point currentFrame;
        private TimeSpan timerMove;
        private readonly TimeSpan timeForOneFrame;

        /// <summary>
        /// Координаты земли по Y.
        /// Когда Y-координата объекта равна координатам земли, он перестает падать
        /// </summary>
        private int groundCoordinateY;
        #endregion

        #region Properties
        protected int ScreenHeight { get; set; }
        protected int FallSpeed { get; set; }
        /// <summary>
        /// Переменная равна true, если объект
        /// находится в воздухе
        /// </summary>
        public bool IsInAir { get; protected set; }
        protected bool IsJump { get; set; }

        protected bool IsGravity { get; set; }
        protected bool IsAnimate { get; set; }
        /// <summary>
        /// Позиция объекта в игре
        /// </summary>
        public Rectangle PositionRectangle { get; set; }
        public MoveDirection CurrentMoveDirection { get; protected set; }
        #endregion

        protected Entity(Game game, Texture2D texture2D)
            : base(game)
        {
            FallSpeed = 8;
            groundCoordinateY = ScreenHeight = Game.GraphicsDevice.Viewport.Height;
            this.texture2D = texture2D;
            IsGravity = true;
            IsAnimate = false;
            isScrolling = true;
            isHeat = false;
            timeHeat = new TimeSpan(0, 0, 0, 0, 400);
            currentFrame = new Point(0, 0);
            timeForOneFrame = TimeSpan.FromMilliseconds(100);
        }
        public override void Update(GameTime gameTime)
        {
            Gravity();
            if (isHeat)
            {
                if (currentTimeHeat <= timeHeat)
                {
                    currentTimeHeat += gameTime.ElapsedGameTime;
                }
                else
                {
                    isHeat = false;
                    currentTimeHeat = TimeSpan.Zero;
                }
            }
            if (PositionRectangle.Y > ScreenHeight)
            {
                var django = this as Django;
                if (django != null)
                {
                    django.HealthPoints = 0;
                }
                Game.Components.Remove(this);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            var positionRectangleWithScrolling =
                new Rectangle(isScrolling ? PositionRectangle.X - Level.screenLeftX : PositionRectangle.X,
                    PositionRectangle.Y, PositionRectangle.Width, PositionRectangle.Height);
            var screenRectangle = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width,
                Game.GraphicsDevice.Viewport.Height);
            if (positionRectangleWithScrolling.Intersects(screenRectangle))
            {
                if (IsAnimate)
                {
                    spriteBatch.Draw(texture2D, positionRectangleWithScrolling, rectangle,
                        isHeat ? Color.Red : Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture2D, positionRectangleWithScrolling,
                        isHeat ? Color.Red : Color.White);
                }
            }
            base.Draw(gameTime);
        }


        protected void Animation(GameTime gameTime, int firstFrame, int lastFrame)
        {
            timerMove += TimeSpan.FromMilliseconds(gameTime.ElapsedGameTime.Milliseconds);
            if (timerMove > timeForOneFrame)
            {
                timerMove = TimeSpan.Zero;

                if ((currentFrame.X >= lastFrame) || (currentFrame.X < firstFrame) || IsInAir)
                //в воздухе анимации не будет
                {
                    currentFrame.X = firstFrame;
                }
                else
                {
                    currentFrame.X++;
                }
            }
        }
        /// <summary>
        /// Гравитация в игре.
        /// Если предмет находится в воздухе, то он упадет
        /// </summary>
        private void Gravity()
        {
            if ((PositionRectangle.Bottom < groundCoordinateY) && (IsGravity))
            {
                PositionRectangle = new Rectangle(PositionRectangle.X, PositionRectangle.Y + FallSpeed,
                   PositionRectangle.Width, PositionRectangle.Height);
                IsInAir = true;
            }
            else
            {
                IsInAir = false;
            }
        }

        protected void EntityHigherThanOtherEntity<T>(T otherEntity) where T : Entity
        {
            //Entity находится сверху
            if (((PositionRectangle.Bottom <= otherEntity.PositionRectangle.Top) ||
                 ((PositionRectangle.Bottom - FallSpeed) <= otherEntity.PositionRectangle.Top)) &&
                (PositionRectangle.Top < otherEntity.PositionRectangle.Top))
            {
                groundCoordinateY = otherEntity.PositionRectangle.Y; //Entity перестает падать
                PositionRectangle = new Rectangle(PositionRectangle.X,
                    groundCoordinateY - PositionRectangle.Height, PositionRectangle.Width, PositionRectangle.Height);
            }
        }

        /// <summary>
        /// Столкновения с объектом в игре.
        /// Возвращает словарь, в котором ключ--объект с которым происходит взаимодействие, 
        /// значение--информация, как именно предмет  взаимодействует с объектом: 
        /// находится сверху, снизу, слева или справа
        /// </summary>
        /// <returns></returns>
        protected Dictionary<Entity,KindOfCollision> CollisionWithEntities()
        {
            var dictionary = new Dictionary<Entity, KindOfCollision>();
            Entity entity;
            foreach (var gameComponent in Game.Components)
            {
                if ((gameComponent is Entity) && (gameComponent != this))
                {
                    entity = (Entity) gameComponent;
                    if ((PositionRectangle.Intersects(entity.PositionRectangle)) ||
                        (new Rectangle(PositionRectangle.X, PositionRectangle.Y + 1, PositionRectangle.Width,
                            PositionRectangle.Height).Intersects(entity.PositionRectangle)))
                    {
                        //перс находится сверху
                        if (((PositionRectangle.Bottom <= entity.PositionRectangle.Top) ||
                             ((PositionRectangle.Bottom - FallSpeed) <= entity.PositionRectangle.Top)) &&
                            (PositionRectangle.Top < entity.PositionRectangle.Top))
                        {
                            dictionary.Add(entity, KindOfCollision.Top);
                        }
                            //джанго находится снизу
                        else if ((entity.PositionRectangle.Bottom >= PositionRectangle.Top) &&
                                 (PositionRectangle.Center.Y > entity.PositionRectangle.Bottom))
                        {
                            dictionary.Add(entity, KindOfCollision.Bottom);
                        }
                            //джанго слева и двигается вправо
                        else if ((PositionRectangle.Right >= entity.PositionRectangle.Left) &&
                                 (PositionRectangle.Left <= entity.PositionRectangle.Left) &&
                                 (CurrentMoveDirection == MoveDirection.Right))
                        {
                            dictionary.Add(entity, KindOfCollision.Left);
                        }
                            //джанго справа и двигается влево
                        else if (((PositionRectangle.Left <= entity.PositionRectangle.Right) &&
                                  (PositionRectangle.Right >= entity.PositionRectangle.Right) &&
                                  (CurrentMoveDirection == MoveDirection.Left)))
                        {
                            dictionary.Add(entity, KindOfCollision.Right);
                        }
                            //персонаж находится внутри
                        else if (entity.PositionRectangle.Contains(PositionRectangle))
                        {
                            dictionary.Add(entity, KindOfCollision.Contain);
                        }
                    }
                }
            }

            //если объект ни на чем не стоит, т.е. находится в воздухе, он будет падать
            if (dictionary.Count(d => ((d.Key is Platform) || (d.Key is Character) || (d.Key is PowderKeg)) &&
                                      (d.Value == KindOfCollision.Top)) == 0)
            {
                groundCoordinateY = ScreenHeight + 2 * PositionRectangle.Y;
            }
            return dictionary;
        }
    }
}