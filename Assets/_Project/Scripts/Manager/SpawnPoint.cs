using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Hey Man Do you have a Player ?
    void Start()
    {
        //call 1 meth in GameManager ?
        GameManagerProxy.AskAPlayer();
        GameManagerProxy.AskACamera();
    }
}
