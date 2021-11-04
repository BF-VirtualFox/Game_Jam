using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUi;
    private int currentScene = 0;

    //Manage the switch of level(inc)
    public IEnumerator NextScene()
    {
        //desactiver la scene courrant et activer la nouvel
        Debug.Log(SceneManager.sceneCount);
        if (SceneManager.sceneCount > 1)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        }
        currentScene++;

        if (currentScene > 0) gameUi.SetActive(false);

        yield return SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentScene));
        Debug.Log(currentScene);

    }

    //TO DO
    public void MainMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        currentScene = 0;
        SceneManager.LoadSceneAsync(0);
    }
    
    //
    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator SwitchSceneByName(string newScene)
    {
        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            yield return SceneManager.UnloadSceneAsync(currentScene);
            
        }
        
        yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));
    }
    
    //Manage the end of a level
    
    //I need to save my Player 
    
   
}
