using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;
using MonoGameEngine.src.Game.States;

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
        ///  first [] contains index of collumn
        ///  second [] contains index of row
        /// </summary>
        List<List<GridTile>> matrix;

        List<Player> players;
        public Grid(Vector2 _dimensions)
        {
            matrix = new List<List<GridTile>>();

            players = new List<Player>();

            players.Add(new Player(0));
            players.Add(new Player(1));

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
                    temp.position = new Vector2(position.X + j * tileSize, position.Y + i * tileSize);
                    temp.dimensions = new Vector2(tileSize, tileSize);

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
                    matrix[i][j].isHovered = false;

                    if (matrix[i][j].Bounds().Intersects(new Rectangle(InputManager.getMouseCoordinates().ToPoint(), new Point(1, 1))))
                    {
                        if (matrix[i][j].isEnabled || 
                            (players[GamePlay.onTurn].coordinatesInGrid.X == i &&
                            players[GamePlay.onTurn].coordinatesInGrid.Y == j))
                        {
                            matrix[i][j].isHovered = true;
                            //if (click) showPossMoves ; if (showing moves) if (click na sebe si){ stop showing }else{ move player GamePlay.switchTurn();}
                            if (players[GamePlay.onTurn].coordinatesInGrid.X == i && 
                                players[GamePlay.onTurn].coordinatesInGrid.Y == j)
							{
                                if (InputManager.eventIsMouseReleased())
								{
                                    players[GamePlay.onTurn].isSelected = true;
								}
							}

                            if (matrix[i][j].isHighlighted)
                            {
                                bool isOccupied = false;
                                for (int k = 0; k < 2; k++)
								{
                                    if (players[k].coordinatesInGrid.X == i && players[k].coordinatesInGrid.Y == j)
                                    {
                                        isOccupied = true;
                                    }
								}

                                if (InputManager.eventIsMouseReleased() && !isOccupied)
                                {
                                    movePlayer(new Vector2(i, j));
                                }
                            }
                        }
                        else
                        {
                            matrix[i][j].isHighlighted = false;
                        }
                    }
                }
            }
            if (players[GamePlay.onTurn].isSelected)
			{
                highlightPossibleMoves();
			} else
			{
                for (int i = 0; i < dimensions.X; i++)
                {
                    for (int j = 0; j < dimensions.Y; j++)
                    {
                        matrix[i][j].isHighlighted = false;
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                players[i].body.position = matrix[(int)players[i].coordinatesInGrid.X][(int)players[i].coordinatesInGrid.Y].position;
                players[i].body.dimensions = new Vector2(tileSize, tileSize);
            }
        }

        public void draw()
        {
            for(int i = 0; i < dimensions.X; i ++)
            {
                for(int j = 0; j < dimensions.Y; j++)
                {
                    matrix[i][j].draw();
                }
            }
            for (int i = 0; i < 2; i++) players[i].draw();
        }

        public void movePlayer(Vector2 newCoordinates)
        {
            int currentPlayerX = (int)players[GamePlay.onTurn].coordinatesInGrid.X;
            int currentPlayerY = (int)players[GamePlay.onTurn].coordinatesInGrid.Y;
            matrix[currentPlayerX][currentPlayerY].owner = GamePlay.onTurn;
            matrix[currentPlayerX][currentPlayerY].isEnabled = false;
            matrix[(int)newCoordinates.X][(int)newCoordinates.Y].owner = GamePlay.onTurn;
            matrix[(int)newCoordinates.X][(int)newCoordinates.Y].isEnabled = false;
            players[GamePlay.onTurn].coordinatesInGrid = newCoordinates;
            players[GamePlay.onTurn].isSelected = false;
            GamePlay.switchTurn();
            if (possibleMoves().Count == 0) StateManager.Instance.SwitchState(GAME_STATE.END_SCREEN_1);
        }
        public void highlightPossibleMoves()
		{
            List<GridTile> possibleMoves = this.possibleMoves();
            for (int i = 0; i < possibleMoves.Count; i++) possibleMoves[i].isHighlighted = true;
        }
        public List<GridTile> possibleMoves()
		{
            List<GridTile> possibleMoves = new List<GridTile>();
            int currentPlayerX = (int)players[GamePlay.onTurn].coordinatesInGrid.X;
            int currentPlayerY = (int)players[GamePlay.onTurn].coordinatesInGrid.Y;
            for (int i = currentPlayerX - 1; i <= currentPlayerX + 1; i++)
            {
                for (int j = currentPlayerY - 1; j <= currentPlayerY + 1; j++)
                {
                    if (i >= 0 && i < GamePlay.gridDimensions.X && j >= 0 && j < GamePlay.gridDimensions.Y)
                    {
                        if (matrix[i][j].isEnabled)
                        {
                            possibleMoves.Add(matrix[i][j]);
                        }
                    }
                }
            }
            return possibleMoves;
        }
    }
}
