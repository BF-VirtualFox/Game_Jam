using System.Collections;
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
        if (SceneManager.sceneCount > 1)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        }
        currentScene++;

        //if (currentScene > 0) gameUi.SetActive(false);

        yield return SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentScene));
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }
    
    public void MainMenu()
    {
        if (SceneManager.sceneCount > 1)
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        currentScene = 0;
    }

}
