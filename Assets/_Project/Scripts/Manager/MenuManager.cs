using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{    
    [SerializeField] private GameObject Canva;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject InGameManager;
    [SerializeField] private GameObject DieMenuInGame;
    [SerializeField] private GameObject CanvaCamera;

    private bool isOpen = false;
    private bool passByTheMenu = false;
    public void NextScene(int countScene)
    {
        if (countScene > 0)
        {
            
            MainMenu.SetActive(false);
            Canva.SetActive(false);
            isOpen = false;
            InGameManager.SetActive(false);
        }
    }
    public void MenuScene()
    {
        passByTheMenu = true;
        //Disable all menus
        InGameManager.SetActive(!isOpen);
        MainMenu.SetActive(true);
        CanvaCamera.SetActive(true);
        isOpen = false;
        
        Debug.Log("isopen change");
    }
    //----------------Menu in game
    public void MenuInGame()
    {
        if (MainMenu.activeInHierarchy)
        {
            
        }
        else
        {
            if (passByTheMenu)
            {
                isOpen = false;
            }
            Debug.Log("hello" + isOpen);
            Canva.SetActive(!isOpen);
            InGameManager.SetActive(!isOpen);
            isOpen = !isOpen;
            CanvaCamera.SetActive(false);
        }
    }
        
    
    //Simply display ResumeMenu
    public void Resume()
    {
        CanvaCamera.SetActive(true);
        InGameManager.SetActive(!isOpen);
        //disable the canva
        Canva.SetActive(false);
        isOpen = !isOpen;
    }
    //--------
    public void Quit()
    {
        Application.Quit();
    }
    
    public void DieMenu()
    {
        DieMenuInGame.SetActive(true);
    }
    
    public void DisplayDieMenu()
    {
        
    }
    
    public void Restart()
    {
        MainMenu.SetActive(true);
    }

}
/*InGameManager.SetActive(false);
        isOpen = !isOpen;
        MainMenu.SetActive(true);
        Canva.SetActive(true);
        CanvaCamera.SetActive(true);*/
