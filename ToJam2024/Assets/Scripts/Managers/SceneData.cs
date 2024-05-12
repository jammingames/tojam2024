using UnityEngine;

[CreateAssetMenu(menuName = "GrandpaSam/Create SceneData", fileName = "SceneData", order = 0)]
public class SceneData : ScriptableObject
{
    [SerializeField] public SceneReference startScene;
    [SerializeField] public SceneReference gameScene;
    [SerializeField] public SceneReference gameOverScene;
    [SerializeField] public SceneReference summaryScene;
    [SerializeField] public SceneReference uiScene;
    
    private void OnEnable()
    {
        startScene.loadAdditive = false;
        gameScene.loadAdditive = false;
        gameOverScene.loadAdditive = true;
        summaryScene.loadAdditive = true;
        uiScene.loadAdditive = true;
    }
}