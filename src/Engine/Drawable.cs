using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameEngine.src.Engine
{
    internal class Drawable
    {
        public Drawable() { }

        public Vector2 position;
        public Vector2 dimensions = Vector2.Zero;
        protected Texture2D texture;
        public Vector2 origin = Vector2.Zero;      // point from which the texture is rendered
        public Texture2D Texture
        {
            get { return texture; }
            set
            {
                texture = value;
                if (dimensions == Vector2.Zero && value != null)
                {
                    dimensions.X = value.Width;
                    dimensions.Y = value.Height;
                }
            }
        }

        public Color mColor = Color.White;

        public Rectangle Bounds()
        {
            return new Rectangle((int)(position.X - origin.X), (int)(position.Y - origin.Y), (int)dimensions.X, (int)dimensions.Y);
        }

        public virtual void draw()
        {
            Render.draw(this);
        }

    }

    internal class DrawableRotated : Drawable
    {
        public DrawableRotated() { }

        public Single rotation;
        public override void draw()
        {
            Render.draw(this);
        }
    }
}
