using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameEngine.src.Engine
{
    internal static class SoundPlayer
    {
        public static void playSong(Song _song)
        {
            MediaPlayer.Play(_song);
        }

        public static void playSong(Song _song, float _volume)
        {
            MediaPlayer.Volume = _volume;
            MediaPlayer.Play(_song);
        }

        public static void playSound(SoundEffect _effect)
        {
            _effect.Play();
        }

    }
}
