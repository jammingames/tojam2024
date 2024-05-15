using System;
using System.Collections;
using GrandpaSamUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneViewController : PersistentSingleton<SceneViewController>
{
    
   
    private bool isLoading = false;
    [SerializeField] private SceneData sceneData;
    private SceneReference currentScene;


    protected override void Awake()
    {
        base.Awake();
        GameManager.OnGameStateChange += OnGameStateChange;
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("I am waking up and I am the SceneViewController");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        GameManager.OnGameStateChange -= OnGameStateChange;
        
    }

    private void OnGameStateChange(GameState state)
    {
        if (sceneData == null) return;
        switch (state)
        {
            case GameState.MainMenu:
                LoadScene(sceneData.startScene);
                break;
            case GameState.GameOver:
                LoadScene(sceneData.gameOverScene);
                break;
            case GameState.Summary:
                LoadScene(sceneData.summaryScene);
                break;
            case GameState.Pause:
                break;
            
                
        }
    }


    public void LoadScene(SceneReference scene, Action onComplete = null)
    {
        if (isLoading) return;
        LoadSceneMode mode = scene.loadAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;
        StartCoroutine(LoadAsync(scene, mode, onComplete));
    }
    public void LoadGameScene(SceneReference scene)
    {
        LoadScene(scene, () => GameManager.StartGame());
        currentScene = scene;
        if (SceneManager.GetSceneByPath(sceneData.uiScene.ScenePath).isLoaded) return;
        SceneManager.LoadSceneAsync(sceneData.uiScene.ScenePath, LoadSceneMode.Additive);
        
    }

    public void ResetScene(SceneReference scene = null)
    {
        if (scene == null) scene = currentScene;
        if (currentScene == null) scene = sceneData.startScene;
        if (SceneManager.GetSceneByPath(scene.ScenePath).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene.ScenePath);
            StartCoroutine(LoadAsync(scene, LoadSceneMode.Additive, null));
        }
            
    }

    private IEnumerator LoadAsync(SceneReference scene, LoadSceneMode loadSceneMode, Action onComplete = null)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.ScenePath, loadSceneMode);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            isLoading = true;
            yield return null;
        }

        currentScene = scene;
        isLoading = false;
        onComplete?.Invoke();
    }
   
    
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("OnSceneLoaded Callback happening from SceneViewController: " + arg0.name);
        //dunno what to do, scene is loaded, start state i guess?
    }
}