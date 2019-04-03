using System;
using System.Linq;
using Django_Unchained.Entities.Immovable_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Django_Unchained.Entities
{
    public class Cactus : ImmovableObject
    {
        /// <summary>
        /// Если кактус взаимодействует с джанго, то будет true
        /// </summary>
        private bool isCollision;

        /// <summary>
        /// Скорость, с которой джанго будет отскакивать от кактуса вверх
        /// </summary>
        private int pushUpSpeed;
        private int pushSpeed;

        private KindOfCollision kindOfCollision;

        /// <summary>
        /// Начальная позиция, где кактус уколол джанго
        /// </summary>
        private Point startPositionPoint;

        /// <summary>
        /// Расстояние, на которое джанго отнесет после укола кактусом
        /// </summary>
        private readonly int distance;

        public Cactus(Game game, Texture2D texture2D, Point coordinatesPoint, int squareSize)
            : base(game, texture2D, coordinatesPoint, squareSize)
        {
            distance = ScreenHeight/4;
        }

        public override void Update(GameTime gameTime)
        {
            if (isCollision)
            {
                PushDjango();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Кактус колет джанго
        /// </summary>
        public void Prick(KindOfCollision newKindOfCollision, Django django)
        {
            kindOfCollision = newKindOfCollision;
            isCollision = true;
            if (django != null)
            {
                pushUpSpeed = django.JumpSpeed;
                pushSpeed = 2 * django.MoveSpeed;
                startPositionPoint = new Point(django.PositionRectangle.Left, django.PositionRectangle.Top);
                django.HealthPoints -= 10;
            }
        }


        private void PushDjango()
        {
            var django = (Django)Game.Components.FirstOrDefault(c => c is Django);
            if ((django != null) && (startPositionPoint.Y - django.PositionRectangle.Y <= distance) &&
                (Math.Abs(startPositionPoint.X - django.PositionRectangle.X) <= distance))
            {
                int changeX = 0;
                int changeY = 0;
                switch (kindOfCollision)
                {
                    case KindOfCollision.Top:
                        changeX = 0;
                        changeY = -pushUpSpeed;
                        break;
                    case KindOfCollision.Left:
                        changeX = -pushSpeed;
                        changeY = 0;
                        break;
                    case KindOfCollision.Right:
                        changeX = pushSpeed;
                        changeY = 0;
                        break;
                }
                django.PositionRectangle = new Rectangle(django.PositionRectangle.X + changeX,
                        django.PositionRectangle.Y + changeY, django.PositionRectangle.Width,
                        django.PositionRectangle.Height);

            }
            else
            {
                isCollision = false;
            }
        }
    }
}
