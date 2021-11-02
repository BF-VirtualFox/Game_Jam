using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
    [SerializeField] private string startScene;
    
    [SerializeField] private UnityEvent onEndGame;
    
    public void Quit()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        //Already a scene?
        StartCoroutine(SwitchScene(startScene));
    }

    private IEnumerator SwitchScene(string newScene)
    {
        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            yield return SceneManager.UnloadSceneAsync(currentScene);
            
        }
        
        yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));
    }

    public void EndGame()
    {
        onEndGame?.Invoke();
    }
}
