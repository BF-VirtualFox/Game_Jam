using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour, IGameManager
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void EndGame()
    {
        GameManager.instance.EndGame();
    }

    public void NextLevel()
    {
        GameManager.instance.NextLevel();
        
    }

    public void MainMenu()
    {
        GameManager.instance.MainMenu();
    }

    public static void AskAPlayer()
    {
        GameManager.instance.AskAPlayer();
    }
    public static void AskACamera()
    {
        GameManager.instance.AskACamera();
    }
}
