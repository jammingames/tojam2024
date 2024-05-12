using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneViewController : MonoBehaviour
{
    
    [SerializeField] private SceneData sceneData;
    private void Awake()
    {
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameManager.OnGameStateChange += OnGameStateChange;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        GameManager.OnGameStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                SceneManager.LoadScene(sceneData.startScene);
                break;
            case GameState.Game:
                SceneManager.LoadScene(sceneData.gameScene);
                break;
            case GameState.GameOver:
                SceneManager.LoadScene(sceneData.gameOverScene);
                break;
            case GameState.Summary:
                SceneManager.LoadScene(sceneData.summaryScene);
                break;
            case GameState.Pause:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void LoadScene(SceneReference scene)
    {
        if (scene.loadAdditive)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
        
    }
   
    
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //dunno what to do, scene is loaded, start state i guess?
    }
}