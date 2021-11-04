using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Hey Man Do you have a Player ?
    void Start()
    {
        GameManagerProxy.AskAPlayer(this.transform);
    }
}
