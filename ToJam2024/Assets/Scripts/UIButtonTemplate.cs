using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UIButtonTemplate", menuName = "GrandpaSam/UIButtonTemplate")]
public class UIButtonTemplate : ScriptableObject
{
    public ColorBlock btnColors;
    public Image img;
    public TMP_Text text;
    
}