using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaintenance
{
    public const int GREEN = 0;
    public const int RED = 1;
    public const int BLUE = 2;
    public const int YELLOW = 3;

    int[] path;
    int[] playerPath;
    int levelCount;
    IndicatorController indicator;
    UIController uiController;
    bool newGame = true;

    public void initializeGame(GameObject indicatorLight, UIController controller)
    {
        indicator = indicatorLight.GetComponent<IndicatorController>();
        uiController = controller;
        path = new int[1];
        path[0] = Random.Range(0, 4);
        levelCount = 1;
        //Debug works here
        if (newGame)
        {
            indicator.newPath(path); // Issue here
            newGame = false;
        }
        playerPath = new int[1];
        Debug.Log(printArray(path));
    }

    public void playerPassed(int doorColor)
    {
        playerPath[path.Length - levelCount] = doorColor;
        levelCount--;
        if (levelCount == 0)
        {
            // Check if player followed correct path, return boolean for yes or no
            bool correctPath = ArraysEqual(path, playerPath);
            if (correctPath)
            {
                newLevel();
            }
            else
            {
                restartLevel();
            }
        }
    }

    void newLevel()
    {
        path = nextPath(path);
        playerPath = new int[path.Length];
        levelCount = path.Length;
        indicator.newPath(path); 
        uiController.updateLevel(path.Length);
        Debug.Log(printArray(path));
    }

    void restartLevel()
    {
        //levelCount = path.Length;
        //playerPath = new int[path.Length];
        //Debug.Log(printArray(path));
        initializeGame(indicator.gameObject, uiController);
        uiController.updateLevel(1);
        indicator.failed(path);
    }

    int[] nextPath(int[] currentPath)
    {
        int[] newPath = new int[currentPath.Length + 1];
        for (int i = 0; i < currentPath.Length; i++)
        {
            newPath[i] = currentPath[i];
        }
        newPath[newPath.Length - 1] = Random.Range(0, 4);
        return newPath;
    }

    bool ArraysEqual(int[] correctPath, int[] playerPath)
    {
        bool pathIsCorrect = true;
        for (int i = 0; i < correctPath.Length; i++)
        {
            if (correctPath[i] != playerPath[i])
            {
                pathIsCorrect = false;
                break;
            }
        }
        return pathIsCorrect;
    }

    string printArray(int[] a)
    {
        string log = "";
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == GREEN)
            {
                log += "green ";
            }
            else if (a[i] == RED)
            {
                log += "red ";
            }
            else if (a[i] == BLUE)
            {
                log += "blue ";
            }
            else if (a[i] == YELLOW)
            {
                log += "yellow ";
            }
        }
        return log;
    }
}
