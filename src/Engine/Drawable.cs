using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameEngine.src.Engine
{
    internal class Drawable
    {
        public Drawable() { }

        public Vector2 mPosition;
        public Vector2 mDimensions = Vector2.Zero;
        protected Texture2D mTexture;
        public Vector2 mOrigin = Vector2.Zero;      // point from which the texture is rendered
        public Texture2D Texture
        {
            get { return mTexture; }
            set
            {
                mTexture = value;
                if (mDimensions == Vector2.Zero && value != null)
                {
                    mDimensions.X = value.Width;
                    mDimensions.Y = value.Height;
                }
            }
        }

        public Color mColor = Color.White;

        public Rectangle Bounds()
        {
            return new Rectangle((int)(mPosition.X - mOrigin.X), (int)(mPosition.Y-mOrigin.Y), (int)mDimensions.X, (int)mDimensions.Y);
        }

        public virtual void Draw()
        {
            Render.Draw(this);
        }

    }

    internal class DrawableRotated : Drawable
    {
        public DrawableRotated() { }

        public Single mRotation;
        public override void Draw()
        {
            Render.Draw(this);
        }
    }
}
