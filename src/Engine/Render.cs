using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine.src.Engine
{


    // TO-DO investigate Origin bug
    internal static class Render
    {
        private static SpriteBatch spriteBatch;

        public static void SetBatch(SpriteBatch _spriteBatch) => spriteBatch = _spriteBatch;
        public static void Begin() => spriteBatch.Begin();
        public static void End() => spriteBatch.End();

        public static void Draw(Drawable _drawable)
        {
            spriteBatch.Draw(_drawable.Texture, _drawable.Bounds(), null, _drawable.mColor, 0f, Vector2.Zero, SpriteEffects.None, 0);
        }

        public static void Draw(DrawableRotated _drawable)
        {
            spriteBatch.Draw(_drawable.Texture, _drawable.Bounds(), null, _drawable.mColor, _drawable.mRotation, Vector2.Zero, SpriteEffects.None, 0);
        }

        public static void Draw()
        {
            //spriteBatch.DrawString()
        }
    }
}
