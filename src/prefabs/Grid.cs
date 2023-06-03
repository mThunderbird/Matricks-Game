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
                    matrix[i][j].isHovered = false;

                    if (matrix[i][j].isEnabled)
                    {
                        if (matrix[i][j].Bounds().Intersects(new Rectangle(InputManager.getMouseCoordinates().ToPoint(), new Point(1, 1))))
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
                    }
                    else
                    {
                        matrix[i][j].isHighlighted = false;
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
                players[i].body.mPosition = matrix[(int)players[i].coordinatesInGrid.X][(int)players[i].coordinatesInGrid.Y].mPosition;
                players[i].body.mDimensions = new Vector2(tileSize, tileSize);
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
            for (int i = 0; i < 2; i++) players[i].draw();
        }

        public void movePlayer(Vector2 newCoordinates)
        {
            int currentPlayerX = (int)players[GamePlay.onTurn].coordinatesInGrid.X;
            int currentPlayerY = (int)players[GamePlay.onTurn].coordinatesInGrid.Y;
            matrix[currentPlayerX][currentPlayerY].isEnabled = false;
            players[GamePlay.onTurn].coordinatesInGrid = newCoordinates;
            players[GamePlay.onTurn].isSelected = false;
            GamePlay.switchTurn();
        }
        public void highlightPossibleMoves()
		{
            int currentPlayerX = (int)players[GamePlay.onTurn].coordinatesInGrid.X;
            int currentPlayerY = (int)players[GamePlay.onTurn].coordinatesInGrid.Y;
            for (int i = currentPlayerX - 1; i <= currentPlayerX + 1; i++) {
                for (int j = currentPlayerY - 1; j <= currentPlayerY + 1; j++)
                {
                    if (i >= 0 && i < GamePlay.gridDimensions.X && j >= 0 && j < GamePlay.gridDimensions.Y)
					{
                        if (matrix[i][j].isEnabled) matrix[i][j].isHighlighted = true;
                    }
                }
            }
		}
    }

    internal class GridTile : Drawable
    {
        Texture2D hMask;
        Texture2D disabledMask;
        public bool isHovered = false;
        public bool isHighlighted = false;
        public bool isEnabled = true;
        public GridTile() 
        {
            hMask = Config.Instance.hoverMask;
            disabledMask = Config.Instance.gridTile2;
        }

        public void update()
        {

        }

        public override void Draw()
        {
            base.Draw();
            if (isHighlighted || isHovered || !isEnabled) drawMask();
        }

        public void drawMask()
        {
            Texture2D temp = Texture;
            Texture = hMask;
            if (!isEnabled) Texture = disabledMask;
            Render.Draw(this);
            Texture = temp;
        }
    }
}
