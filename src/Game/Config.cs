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
    public Texture2D logo;

    public Texture2D gridTileA;
    public Texture2D gridTileB;
    public Texture2D gridMaskCross;
    public Texture2D gridMaskPoint;

    public void Init(Func<string, Texture2D> loadTexture2D)
    {
        TEXTURE_NOT_FOUND = loadTexture2D("NOT_FOUND");
        logo = loadTexture2D("cool_graphics/kiroIdrago");

        gridTileA = loadTexture2D("grid/tile_brown");
        gridTileB = loadTexture2D("grid/tile_white");
        gridMaskCross = loadTexture2D("grid/cross");
        gridMaskPoint = loadTexture2D("grid/point");

    }
}
