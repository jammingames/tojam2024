using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelDescription", menuName = "GrandpaSam/LevelDescription")]
public class LevelDescription : ScriptableObject
{
    public string levelName;
    [Multiline]
    public string levelDesc;
    public Sprite levelImage;
    public SceneReference scene;
}