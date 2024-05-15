using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
   public GameObject mainMenu;
   public GameObject instructionsMenu;
   public GameObject levelSelectMenu;

   private void Awake()
   {
       Debug.Log(SceneViewController.Instance.name);
       ShowMainMenu();
   }

   private void OnEnable()
   {
       if (mainMenu.activeInHierarchy == false)
       {
           ShowMainMenu();
       }
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
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
       if (mainMenu.activeInHierarchy)
       mainMenu.SetActive(true);
       instructionsMenu.SetActive(false);
       levelSelectMenu.SetActive(false);
   }
   
   public void ShowInstructionsMenu()
   {
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(true);
       levelSelectMenu.SetActive(false);
   }
   
   public void ShowLevelSelectMenu()
   {
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(false);
       levelSelectMenu.SetActive(true);
   }

   public void HideAll()
   {
       mainMenu.SetActive(false);
       instructionsMenu.SetActive(false);
       levelSelectMenu.SetActive(false);
   }
}
