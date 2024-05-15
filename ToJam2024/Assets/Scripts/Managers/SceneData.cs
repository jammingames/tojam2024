using UnityEngine;

[CreateAssetMenu(menuName = "GrandpaSam/Create SceneData", fileName = "SceneData", order = 0)]
public class SceneData : ScriptableObject
{
    [SerializeField] public SceneReference bootStrapScene;
    [SerializeField] public SceneReference startScene;
    [SerializeField] public SceneReference[] gameScenes;
    [SerializeField] public SceneReference gameOverScene;
    [SerializeField] public SceneReference summaryScene;
    [SerializeField] public SceneReference uiScene;
    
    private void OnEnable()
    {
        bootStrapScene.loadAdditive = false;
        startScene.loadAdditive = false;
        foreach (var gameScene in gameScenes)
        {
            gameScene.loadAdditive = false;    
        }
        
        gameOverScene.loadAdditive = true;
        summaryScene.loadAdditive = true;
        uiScene.loadAdditive = true;
    }
}