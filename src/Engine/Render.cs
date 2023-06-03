using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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

        public static void drawString(SpriteFont _font, string _text, Rectangle _rect)
        {
            try
            {
                spriteBatch.DrawString(_font, _text, Vector2.One, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            }
            catch (Exception)
            {

            }
        }
    }
}
