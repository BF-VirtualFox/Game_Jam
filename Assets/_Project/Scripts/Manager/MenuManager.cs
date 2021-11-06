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
    [SerializeField] private GameObject Victory;


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
        
        if (MainMenu.activeInHierarchy)
        {
            
        }
        else
        {
            
            Canva.SetActive(true);
            DieMenuInGame.SetActive(true);
            CanvaCamera.SetActive(false);
        }
    }
    
    public void Restart()
    {
        CanvaCamera.SetActive(true);
        DieMenuInGame.SetActive(false);
        //disable the canva
        Canva.SetActive(false);
    }

    public void ShowVictory()
    {
        Canva.SetActive(true);
        CanvaCamera.SetActive(false);
        Victory.SetActive(true);
    }

}

