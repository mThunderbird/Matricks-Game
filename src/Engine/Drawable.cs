using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameEngine.src.Engine
{
    internal class Drawable
    {
        public Drawable() 
        {
            mOrigin = Vector2.Zero;
        }

        public Vector2 mPosition;
        public Vector2 mDimensions = Vector2.Zero;
        protected Texture2D mTexture;
        public Vector2 mOrigin;
        public Texture2D Texture
        {
            get { return mTexture; }
            set
            {
                mTexture = value;
                if (mDimensions == Vector2.Zero)
                {
                    mDimensions.X = value.Width;
                    mDimensions.Y = value.Height;
                }
            }
        }

        public Color mColor = Color.White;

        public Rectangle Bounds()
        {
            return new Rectangle((int)mPosition.X, (int)mPosition.Y, (int)mDimensions.X, (int)mDimensions.Y);
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
