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

    public void ReAffectCamera()
    {

        var cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        //We look in all the cameras and if you find another camera we delete the current camera
        foreach (var cam in cameras)   
        {
            if (cam == Camera) continue;
            Destroy(Camera);
            Camera = cam;
            DontDestroyOnLoad(cam);
            break;
        }
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
