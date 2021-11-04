using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
    //[SerializeField] private string startScene;
    [SerializeField] private UnityEvent onEndGame;
    [SerializeField] private LevelManager _levelManager;
    //[SerializeField] private CinemachineBrain cam;
    public LevelManager levelManager => _levelManager;

    
    //SceneManager----------
    public void StartGame()
    {
        //Already a scene?
        StartCoroutine(levelManager.NextScene());
    }
    
    public void Quit()
    {
        levelManager.Quit();
    }
    
    public void EndGame()
    {
        onEndGame?.Invoke();
    }
    public void NextLevel()
    {
        StartCoroutine(levelManager.NextScene());
    }

    public void MainMenu()
    {
        Destroy(gameObject);
        levelManager.MainMenu();
    }
    //-------------
    
    
    
}
