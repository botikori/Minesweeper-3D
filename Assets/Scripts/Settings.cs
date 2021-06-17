using UnityEngine;

public static class Settings
{
    private static int _mineCount = 5;
    private static int _width = 10, _height = 10, _depth = 10;

    public static int MineCount
    {
        get => _mineCount;
        set => _mineCount = value;
    }

    public static int Width
    {
        get => _width;
        set => _width = value;
    }

    public static int Height
    {
        get => _height;
        set => _height = value;
    }

    public static int Depth
    {
        get => _depth;
        set => _depth = value;
    }
}