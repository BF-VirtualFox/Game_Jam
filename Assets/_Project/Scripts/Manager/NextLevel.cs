using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private UnityEvent OnNext;

    void Menu()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnNext?.Invoke();
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        Menu();
    }
}
