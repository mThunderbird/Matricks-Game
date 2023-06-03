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
        int maximumGridWidth = 1000;
        int maximumGridHeight = 800;

        int tileSize;

        Vector2 dimensions;

        Vector2 position;

        List<Texture2D> gridTileMainTextures;
        List<Texture2D> gridTileSecondaryTextures;


        /// <summary>
        ///  first [] contains index of row
        ///  second [] contains index of collumn
        /// </summary>
        List<List<GridTile>> matrix;
        List<Unit> units;
        public Grid(Vector2 _dimensions)
        {
            matrix = new List<List<GridTile>>();
            units = new List<Unit>();

            gridTileMainTextures = new List<Texture2D>();
            gridTileMainTextures.Add(Config.Instance.gridTile1);
            gridTileMainTextures.Add(Config.Instance.gridTile2);

            gridTileSecondaryTextures = new List<Texture2D>();
            gridTileSecondaryTextures.Add(Config.Instance.gridTile2Part);
            gridTileSecondaryTextures.Add(Config.Instance.gridTileBolts);
            gridTileSecondaryTextures.Add(Config.Instance.gridTileLines);
            gridTileSecondaryTextures.Add(Config.Instance.gridTileBroken);

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

            for (int i = 0; i < dimensions.X; i++)
            {
                matrix.Add(new List<GridTile>());
                for (int j = 0; j < dimensions.Y; j++)
                {
                    GridTile temp = new GridTile();
                    temp.mPosition = new Vector2(position.X + j * tileSize, position.Y + i * tileSize);
                    temp.mDimensions = new Vector2(tileSize, tileSize);

                    int rand = new Random().Next(0, gridTileMainTextures.Count + 1);
                    if (rand >= gridTileMainTextures.Count)
                    {
                        temp.Texture = gridTileSecondaryTextures[new Random().Next(0, gridTileSecondaryTextures.Count)];
                    }
                    else temp.Texture = gridTileMainTextures[rand];

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
                    if (matrix[i][j].Bounds().Intersects(new Rectangle(InputManager.getMouseCoordinates().ToPoint(), new Point(1, 1)))) {
                        matrix[i][j].drawMask = true;
					} else
					{
                        matrix[i][j].drawMask = false;
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

            foreach(Unit i in units)
            {
                i.Draw();
            }
        }

        public void addUnit(Unit _newUnit, int x, int y)
        {
            Unit temp = new Unit(_newUnit);
            temp.mPosition.X = matrix[x][y].mPosition.X + tileSize / 2 - temp.mDimensions.X / 2;
            temp.mPosition.Y = matrix[x][y].mPosition.Y + tileSize / 2 - temp.mDimensions.Y / 2;
            temp.mDimensions.X = tileSize - 20;
            temp.mDimensions.Y = tileSize - 20;
        }

    }

    internal class Unit : Drawable
    {
        public Unit()
        {
        }

        public Unit(Unit _unit)
        {
            mPosition = _unit.mPosition;
            mDimensions = _unit.mDimensions;
            mTexture = _unit.Texture;
        }
    }

    internal class GridTile : Drawable
    {
        Texture2D mask;
        public bool drawMask = false;
        public GridTile() 
        {
            mask = Config.Instance.hoverMask;
        }

        public override void Draw()
        {
            base.Draw();

            if(drawMask)
            {
                Texture2D temp = Texture;
                Texture = mask;
                Render.Draw(this);
                Texture = temp;
            }

        }
    }
}
