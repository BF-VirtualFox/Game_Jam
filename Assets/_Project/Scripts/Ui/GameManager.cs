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
    
    [SerializeField] private CameraManager _cameraManager;
    public CameraManager cameraManager => _cameraManager;
    
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
            cameraManager.DestroyCamera();
        }
//        Destroy(gameObject);
        levelManager.MainMenu();
    }
    //PlayerManager-------------

    public void AskAPlayer()
    {
        if (playerManager.getPlayer() == null)
        {
            playerManager.PlayerCreation();
        }
        else
        {
            
            playerManager.ReAffectPlayer();
        }
    }
    //CameraManager-----
    
    //I Could Refactor AskAPlayer && AskACamera
    public void AskACamera()
    {
        if (cameraManager.GetCamera() == null)
            cameraManager.CameraCreation();
        else
        {
            cameraManager.ReAffectPlayer();
        }
    }

}
