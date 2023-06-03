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
            generateOperations();
        }

        private void createMatrix(Vector2 _dimensions)
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

                    temp.Texture = Config.Instance.gridTile1;

                    matrix[i].Add(temp);
                }
            }
        }

        private void generateOperations()
        {
            int maxValue = (int)(dimensions.X + dimensions.Y);

            for(int i = 0; i < dimensions.Y; i++)
            {
                for(int j = 0; j < dimensions.Y; j++)
                {
                    int depth = MathHelper.Min(
                        distanceFromTwoSquares(Vector2.Zero, new Vector2(i, j)), 
                        distanceFromTwoSquares(new Vector2(dimensions.X - 1, dimensions.Y - 1), new Vector2(i, j)));
                    Operation temp = createOperation(depth, maxValue);
                    temp.setRect(matrix[i][j].Bounds());
                    matrix[i][j].setOperation(temp);
                }
            }
        }

        private int distanceFromTwoSquares(Vector2 start, Vector2 end)
        {
            return (int)MathHelper.Max(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
        }

        private Operation createOperation(int depth, int maxValue)
        {
            Operation newOp;

            //choose type -> chance for * or div grows with depth
            float koef = (depth / (MathHelper.Max(dimensions.X, dimensions.Y)));

            if(new Random().NextDouble() < koef)
            {
                if(new Random().NextDouble() < 0.5)
                {
                    newOp = new OperationMultiply();
                }
                else
                {
                    newOp = new OperationDivide();
                }
            }
            else
            {
                if (new Random().NextDouble() < 0.5)
                {
                    newOp = new OperationAdd();
                }
                else
                {
                    newOp = new OperationSubstract();
                }
            }

            //choose value
            if(depth == 0)
            {
                newOp.setValue(0);
                return newOp;
            }

            int curVal = (int)(koef * maxValue);
            int val = new Random().Next(curVal - 1, curVal + 2);
            if (val < 0) val = curVal;

            newOp.setValue(val);

            return newOp;
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

}
