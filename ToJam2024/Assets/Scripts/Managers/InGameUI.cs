using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameUI : MonoBehaviour
{
    public GameObject uiRoot;
    public GameObject mainMenu;
    public GameObject instructionsMenu;
   

   private void Awake()
   {
       Debug.Log(SceneViewController.Instance.name);
       
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           Debug.Log("Escape key pressed");
           ToggleMainMenu();
       }
   }
   
   public void ToggleMainMenu()
   {
       if (mainMenu.activeInHierarchy) HideAll();
       else ShowMainMenu();
   }

   public void ShowMainMenu()
   {
       uiRoot.SetActive(true);
       mainMenu.SetActive(true);
       instructionsMenu.SetActive(false);
       
   }
   
   public void ShowInstructionsMenu()
   {
       uiRoot.SetActive(true);
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(true);
       
   }
   
   public void ShowLevelSelectMenu()
   {
       uiRoot.SetActive(true);
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(false);
       
   }

   public void HideAll()
   {
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(false);
       uiRoot.SetActive(false);
       
   }

   public void ExitLevel()
   {
       GameManager.SetGameState(GameState.MainMenu);
   }
   
   public void RetryLevel()
   {
       GameManager.ResetLevel();
   }
}
