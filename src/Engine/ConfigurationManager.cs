using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine.src.Engine
{
    /// <summary>
    /// Solution using Lazy implementation.
    /// </summary>
    internal class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());
        public static ConfigurationManager Instance { get { return instance.Value; } }

        private ConfigurationManager()
        {
        }

        public Texture2D Logo;
    }
}
