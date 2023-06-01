using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

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


    }
}
