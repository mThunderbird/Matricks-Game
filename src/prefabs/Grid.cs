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
        int maximumGridWidth = Game1.WINDOW_WIDTH - 200;
        int maximumGridHeight = Game1.WINDOW_HEIGHT - 200;

        int tileSize;

        Vector2 dimensions;

        Vector2 position;

        Texture2D gridTileA;

        Texture2D gridTileB;

        List<List<GridTile>> matrix;

        public Grid(Vector2 _dimensions)
        {
            dimensions = _dimensions;
            gridTileA = Config.Instance.gridTileA;
            gridTileB = Config.Instance.gridTileB;

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
            for(int i = 0; i < dimensions.Y; i++)
            {
                matrix.Add(new List<GridTile>());
                for(int j = 0; j < dimensions.X; j++)
                {
                    GridTile temp = new GridTile();
                    temp.mPosition = new Vector2(position.X + j * tileSize, position.Y + i * tileSize);
                    temp.mDimensions = new Vector2(tileSize, tileSize);
                    if(i % 2 == 0)
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

        public void draw()
        {
            for(int i = 0; i < dimensions.Y; i ++)
            {
                for(int j = 0; j < dimensions.X; j++)
                {
                    matrix[i][j].Draw();
                }
            }
        }

    }

    internal class GridTile : Drawable
    {
        public GridTile() { }
    }
}
