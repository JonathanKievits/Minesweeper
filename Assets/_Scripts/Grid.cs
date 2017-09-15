using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    public static int width = 10;
    public static int height = 13;
    public static TextureLoader[,] tiles = new TextureLoader[width, height];

    public static void uncoverMines()
    {
        foreach (TextureLoader tile in tiles)
        {
            if (tile.mine)
                tile.LoadTextures(0);
        }
    }

    public static bool mineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return tiles[x, y].mine;
        return false;
    }

    public static int neighbourMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1)) ++count;
        if (mineAt(x + 1, y + 1)) ++count;
        if (mineAt(x + 1, y)) ++count;
        if (mineAt(x + 1, y - 1)) ++count;
        if (mineAt(x, y - 1)) ++count;
        if (mineAt(x - 1, y - 1)) ++count;
        if (mineAt(x - 1, y)) ++count;
        if (mineAt(x - 1, y + 1)) ++count;

        return count;
    }

    public static void FFuncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (visited[x, y])
                return;

            tiles[x,y].LoadTextures(neighbourMines(x,y));

            if(neighbourMines(x,y)> 0)
                return;

            visited[x, y] = true;

            FFuncover(x + 1, y, visited);
            FFuncover(x - 1, y, visited);
            FFuncover(x, y + 1, visited);
            FFuncover(x, y - 1, visited);
        }
    }

    public static bool isFinished()
    {
        foreach (TextureLoader tile in tiles)
            if (tile.isCovered() && !tile.mine)
                return false;

        return true;
    }

}
