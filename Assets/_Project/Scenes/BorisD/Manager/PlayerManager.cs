using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint;
    //IsArmed?
    [FormerlySerializedAs("Instance")] public GameObject Player;
    private PlayerMovement playerMovement;
    //the health ui?
    private GameObject HealthUi;
    

    public void Setup()
    {
        //Set Player spawnPoint
        playerMovement = Player.GetComponent<PlayerMovement>();
        HealthUi = Player.GetComponentInChildren<Canvas>().gameObject;
    }

    public void DisableControl()
    {
        playerMovement.enabled = false;
        //disable the ui
        HealthUi.SetActive(false);
    }

    public void EnableControl()
    {
        playerMovement.enabled = true;
        //enable the ui
        HealthUi.SetActive(true);

    }

    public void Replace()
    {
     //reset spawn point ect  
    }

    public GameObject getPlayer()
    {
        return Player;
    }

    public void PlayerCreation()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(Player);
    }

    //Soit param soit find
    public void ReAffectPlayer()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        Player.transform.position = spawnPoint.position;
    }

    public void DestroyPlayer()
    {
        GameObject obj = GameObject.Find(Player.name);
        
        Destroy(Player);
        Player = null;
    }
}
