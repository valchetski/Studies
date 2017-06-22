using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Django_Unchained
{
    public static class MusicPlayer
    {
        private static Song currentSong;
        private static SoundEffectInstance soundEffectInstance;

        public static void PlayMusic(Song song)
        {
            if (Settings.IsMusicOn)
            {
                currentSong = song;
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Volume = 0.15f;
                    MediaPlayer.Play(currentSong);
                }
            }
            else
            {
                MediaPlayer.Stop();
            }
        }

        public static void StopMusic(Song song)
        {
            if (currentSong != song)
            {
                MediaPlayer.Stop();
            }
        }

        public static void PlaySoundEffect(SoundEffect soundEffect)
        {
            if (Settings.IsSoundsOn)
            {
                soundEffectInstance = soundEffect.CreateInstance();
                soundEffectInstance.Volume = 0.5f;
                soundEffectInstance.Play();
            }
        }

        public static void PauseSoundEffects()
        {
            if (soundEffectInstance != null)
            {
                soundEffectInstance.Pause();
            }
        }

        public static void ResumeSoundEffects()
        {
            if (soundEffectInstance != null)
            {
                soundEffectInstance.Resume();
            }
        }
    }
}
