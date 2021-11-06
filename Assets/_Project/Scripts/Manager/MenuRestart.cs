using UnityEngine;
using UnityEngine.Events;

public class MenuRestart : MonoBehaviour
{    
    [SerializeField] private UnityEvent OnDeath;
    [SerializeField] private int currentHealth;

    void Menu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("hi");
            currentHealth -= 5;
            if (currentHealth == 0)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        Menu();
    }
}
