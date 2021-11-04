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
    
    [SerializeField] private PlayerManager _playerManager;
    public PlayerManager playerManager => _playerManager;
    
    
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
        if (playerManager.getPlayer())
        {
            playerManager.DestroyPlayer();
        }
//        Destroy(gameObject);
        levelManager.MainMenu();
    }
    //PlayerManager-------------

    //First creation of the player

    


    public void AskAPlayer(Transform SpawnPoint)
    {
        Debug.Log(SpawnPoint.position);
        if (playerManager.getPlayer() == null)
        {
            playerManager.PlayerCreation();
        }
        else
        {
            
            playerManager.ReAffectPlayer(SpawnPoint);
        }
    }
}
