using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectDescription : MonoBehaviour
{
    public LevelDescription data;
    public TMP_Text nameLabel;
    public TMP_Text descLabel;
    public Image image;
    
    public void SetData(LevelDescription data)
    {
        this.data = data;
        nameLabel.text = data.levelName;
        descLabel.text = data.levelDesc;
        image.sprite = data.levelImage;
    }
    
    private void OnValidate()
    {
        if (data == null) return;
        nameLabel.text = data.levelName;
        descLabel.text = data.levelDesc;
        image.sprite = data.levelImage;
    }

    public void Play()
    {
        if (data == null) return;
        SceneViewController.Instance.LoadGameScene(data.scene);
    }
}
