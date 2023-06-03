using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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
    
    public Song introSong;
    public SoundEffect clickSound;
    public SpriteFont arialFont;
    public Texture2D info;
    
    public Texture2D TEXTURE_NOT_FOUND;

    public Texture2D background;

    public Texture2D logo;
    public Texture2D pressSpaceTexture;

    public Texture2D playButton;
    public Texture2D settingsButton;
    public Texture2D exitButton;
    public Texture2D hoverMask;
    public Texture2D gameBanner;

    public Texture2D singlePlayerButton;
    public Texture2D twoPlayerButton;

    public Texture2D backButton;
    public Texture2D gridTile1;
    public Texture2D gridTile2;
    public Texture2D gridTileBroken;
    public Texture2D gridTileLines;
    public Texture2D gridTileBolts;
    public Texture2D gridTile2Part;

    public Texture2D player1Score;
    public Texture2D player2Score;

    public Texture2D character1;
    public Texture2D character2;

    public Texture2D disabledMask1;
    public Texture2D disabledMask2;

    public Texture2D sliderBar;
    public Texture2D sliderKnob;
    public void Init(Func<string, Texture2D> loadTexture2D, Func<string, SpriteFont> loadFont, Func<string, Song> loadSong, Func<string, SoundEffect> loadSound)
    {
        introSong = loadSong("sounds/MenInBlackTheme");
        clickSound = loadSound("sounds/clickSound");
        arialFont = loadFont("UI/arialFont");
        info = loadTexture2D("info");

        TEXTURE_NOT_FOUND = loadTexture2D("NOT_FOUND");

        background = loadTexture2D("background");

        logo = loadTexture2D("UI/logo");
        pressSpaceTexture = loadTexture2D("UI/pressToCont");

        gameBanner = loadTexture2D("UI/gameBanner");
        playButton = loadTexture2D("UI/playButton");
        settingsButton = loadTexture2D("UI/settingsButton");
        exitButton = loadTexture2D("UI/exitButton");
        singlePlayerButton = loadTexture2D("UI/1Player");
        twoPlayerButton = loadTexture2D("UI/2Player");
        hoverMask = loadTexture2D("UI/hoverMask");

        backButton = loadTexture2D("UI/backButton");
        gridTile1 = loadTexture2D("grid/gridTile1");
        gridTile2 = loadTexture2D("grid/gridTile2");
        gridTileBolts = loadTexture2D("grid/gridTile3");
        gridTileBroken = loadTexture2D("grid/gridTileBroken");
        gridTileLines = loadTexture2D("grid/gridTileLines");
        gridTile2Part = loadTexture2D("grid/gridTile2Part");
        player1Score = loadTexture2D("UI/player1score");
        player2Score = loadTexture2D("UI/player2Score");

        character1 = loadTexture2D("player/character1");
        character2 = loadTexture2D("player/character2");

        disabledMask1 = loadTexture2D("grid/disabledMask1");
        disabledMask2 = loadTexture2D("grid/disabledMask2");

        sliderBar = loadTexture2D("UI/bar");
        sliderKnob = loadTexture2D("UI/knob");
    }
}
