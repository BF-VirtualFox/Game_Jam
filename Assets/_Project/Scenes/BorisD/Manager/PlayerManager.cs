using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoint;
    //IsArmed?
    public GameObject Instance;
    private PlayerMovement playerMovement;
    //the health ui?
    private GameObject HealthUi;

    public void Setup()
    {
        playerMovement = Instance.GetComponent<PlayerMovement>();
        HealthUi = Instance.GetComponentInChildren<Canvas>().gameObject;
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
     //set spawn point ect  
    }
}
