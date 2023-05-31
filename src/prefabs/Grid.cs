using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;

namespace MonoGameEngine.src.prefabs
{
    internal class Grid
    {
        int maximumTileSize = 100;
        int horizontalMargin = 200;
        int verticalMargin = 200;
        int maximumGridWidth;
        int maximumGridHeight;

        int tileSize;

        Vector2 dimensions;

        Vector2 position;

        Texture2D gridTileA;
        Texture2D gridTileB;
        Texture2D gridMaskCross;
        Texture2D gridMaskPoint;
        Texture2D gridMaskHover;

        /// <summary>
        ///  first [] contains index of row
        ///  second [] contains index of collumn
        /// </summary>
        List<List<GridTile>> matrix;

        public Grid(Vector2 _dimensions)
        {
            gridTileA = Config.Instance.gridTileA;
            gridTileB = Config.Instance.gridTileB;
            gridMaskCross = Config.Instance.gridMaskCross;
            gridMaskPoint = Config.Instance.gridMaskPoint;
            gridMaskHover = Config.Instance.gridMaskHover;

            maximumGridHeight = Game1.WINDOW_HEIGHT - verticalMargin * 2;
            maximumGridWidth = Game1.WINDOW_WIDTH - horizontalMargin * 2;

            createMatrix(_dimensions);

        }

        public void createMatrix(Vector2 _dimensions)
        {
            dimensions = _dimensions;

            if (maximumTileSize * dimensions.Y > maximumGridHeight)
            {
                tileSize = (int)(maximumGridHeight / dimensions.Y);
                tileSize = (tileSize / 5) * 5;
                if (tileSize * dimensions.X > maximumGridWidth)
                {
                    tileSize = (int)(maximumGridWidth / dimensions.X);
                    tileSize = (tileSize / 5) * 5;
                }
            }
            else if (maximumTileSize * dimensions.X > maximumGridWidth)
            {
                tileSize = (int)(maximumGridWidth / dimensions.X);
                tileSize = (tileSize / 5) * 5;
                if (tileSize * dimensions.Y > maximumGridHeight)
                {
                    tileSize = (int)(maximumGridHeight / dimensions.Y);
                    tileSize = (tileSize / 5) * 5;
                }
            }
            else tileSize = maximumTileSize;

            position.X = Game1.WINDOW_WIDTH / 2 - dimensions.X * tileSize / 2;
            position.Y = Game1.WINDOW_HEIGHT / 2 - dimensions.Y * tileSize / 2;

            matrix = new List<List<GridTile>>();
            for (int i = 0; i < dimensions.X; i++)
            {
                matrix.Add(new List<GridTile>());
                for (int j = 0; j < dimensions.Y; j++)
                {
                    GridTile temp = new GridTile();
                    temp.mPosition = new Vector2(position.X + j * tileSize, position.Y + i * tileSize);
                    temp.mDimensions = new Vector2(tileSize, tileSize);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0) temp.Texture = gridTileA;
                        else temp.Texture = gridTileB;
                    }
                    else
                    {
                        if (j % 2 == 0) temp.Texture = gridTileB;
                        else temp.Texture = gridTileA;
                    }
                    matrix[i].Add(temp);
                }
            }
        }

        public void update()
		{
            for (int i = 0; i < dimensions.X; i++)
            {
                for (int j = 0; j < dimensions.Y; j++)
                {
                    if (matrix[i][j].Bounds().Intersects(new Rectangle(InputManager.Instance.getMouseCoordinates(), new Point(1, 1)))) {
                        matrix[i][j].setMask(gridMaskHover);
					} else
					{
                        matrix[i][j].setMask(null);
                    }
                }
            }
		}

        public void draw()
        {
            for(int i = 0; i < dimensions.X; i ++)
            {
                for(int j = 0; j < dimensions.Y; j++)
                {
                    matrix[i][j].Draw();
                }
            }
        }

    }

    internal class GridTile : Drawable
    {
        Texture2D mask;
        public GridTile() 
        {

        }

        internal void setMask(Texture2D _mask)
        {
            mask = _mask;
        }

        public override void Draw()
        {
            base.Draw();

            if(mask != null)
            {
                Texture2D temp = Texture;
                Texture = mask;
                Render.Draw(this);
                Texture = temp;
            }

        }
    }
}
