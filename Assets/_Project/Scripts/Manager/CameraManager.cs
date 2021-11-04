using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] public GameObject Camera;
    
    public void CameraCreation()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        DontDestroyOnLoad(Camera);
    }

    public void ReAffectPlayer()
    {
        //Nothing ?
    }

    public GameObject GetCamera()
    {
        return Camera;
    }
    
    public void DestroyCamera()
    {
        GameObject obj = GameObject.Find(Camera.name);
        
        Destroy(Camera);
        Camera = null;
    }
    
}
