using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine.src.gameSpecific
{
    /// <summary>
    /// Solution using Lazy implementation.
    /// </summary>
    internal class Config
    {
        private static readonly Lazy<Config> instance =
        new Lazy<Config>(() => new Config());
        public static Config Instance { get { return instance.Value; } }

        private Config()
        {
        }

        public void Init(Func<string, Texture2D> LoadTexture2D)
        {
            NOT_FOUND = LoadTexture2D("NOT_FOUND");
            Logo = LoadTexture2D("cool_graphics/kiroIdrago");
        }

        public Texture2D NOT_FOUND;
        public Texture2D Logo;
    }
}
