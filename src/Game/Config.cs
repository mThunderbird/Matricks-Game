using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine.src.Game;

internal sealed class Config
{
    private static readonly Config instance = new Config();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Config()
    {

    }
    private Config()
    {
    }

    public static Config Instance
    {
        get { return instance; }
    }
    
    
    public Texture2D TEXTURE_NOT_FOUND;

    public Texture2D background;

    public Texture2D logo;
    public Texture2D pressSpaceTexture;

    public Texture2D playButton;
    public Texture2D settingsButton;
    public Texture2D exitButton;
    public Texture2D gameBanner;

    public Texture2D backButton;
    public Texture2D gridTile1;
    public Texture2D gridTile2;
    public Texture2D gridTileBroken;
    public Texture2D gridTileLines;
    public Texture2D gridTileBolts;
    public Texture2D gridTile2Part;
    public Texture2D gridMaskCross;
    public Texture2D gridMaskPoint;
    public Texture2D gridMaskHover;

    public void Init(Func<string, Texture2D> loadTexture2D, Func<string, SpriteFont> loadFont)
    {
        TEXTURE_NOT_FOUND = loadTexture2D("NOT_FOUND");

        background = loadTexture2D("background");
        logo = loadTexture2D("UI/logo");
        pressSpaceTexture = loadTexture2D("UI/pressToCont");

        gameBanner = loadTexture2D("UI/gameBanner");
        playButton = loadTexture2D("UI/playButton");
        settingsButton = loadTexture2D("UI/settingsButton");
        exitButton = loadTexture2D("UI/exitButton");

        backButton = loadTexture2D("UI/backButton");
        gridTile1 = loadTexture2D("grid/gridTile1");
        gridTile2 = loadTexture2D("grid/gridTile2");
        gridTileBolts = loadTexture2D("grid/gridTile3");
        gridTileBroken = loadTexture2D("grid/gridTileBroken");
        gridTileLines = loadTexture2D("grid/gridTileLines");
        gridTile2Part = loadTexture2D("grid/gridTile2Part");

        gridMaskCross = loadTexture2D("grid/cross");
        gridMaskPoint = loadTexture2D("grid/point");
        gridMaskHover = loadTexture2D("grid/hover");

    }
}
