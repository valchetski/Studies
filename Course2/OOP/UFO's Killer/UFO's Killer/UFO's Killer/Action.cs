using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace UFO_s_Killer
{
    class Action
    {
        public int Shot(ref Sight sight, ref UFOList ufoList)
        {
            int shotedUFO = 0;
            var sightCentreVector2 = new Vector2(sight.rectangle.X + sight.rectangle.Width/2, sight.rectangle.Y + sight.rectangle.Height/2);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                foreach (var ufo in ufoList)
                {
                    if (ufo.rectangle.Contains(Convert.ToInt32(sightCentreVector2.X), Convert.ToInt32(sightCentreVector2.Y)))
                    {
                        if (ufo.state != UFOState.Fall)
                        {
                            ufo.state = UFOState.Fall;
                            shotedUFO++;
                        }
                    } 
                }
            }
            return shotedUFO;
        }

        public int FlyAway(ref UFOList ufoList, SoundEffectInstance flyAwaySong)
        {
            var flyingUfoesList = new UFOList();
            foreach (var ufo in ufoList)
            {
                if ((((ufo.rectangle.X + ufo.rectangle.Width) < 0) || (ufo.rectangle.Y + ufo.rectangle.Height < 0)) && (ufo.state == UFOState.Fly))
                {
                    if (flyingUfoesList.Contains(ufo) == false)
                    {
                        flyingUfoesList.Add(ufo);
                        flyAwaySong.Play();
                    }
                }
            }
            int flyingufoes = flyingUfoesList.Count;
            foreach (var fly in flyingUfoesList)
            {
                ufoList.Remove(fly);
            }
            return flyingufoes;
        }

        private bool pauseKeyDown = false;
        private bool isNowPause = false;
        public bool IsPause
        {
            get
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    pauseKeyDown = true;
                }
                else if (pauseKeyDown)
                {
                    pauseKeyDown = false;
                    isNowPause = !isNowPause;
                }
                return isNowPause;
            }
        }
    }
}
