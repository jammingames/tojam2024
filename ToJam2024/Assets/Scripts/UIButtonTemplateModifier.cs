using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonTemplateModifier : MonoBehaviour
{
    public UIButtonTemplate template;
    
    [ContextMenu("Modify Buttons")]
    void ModifyButtons()
    {
        if (template == null) return;
        
        foreach (var button in GetComponentsInChildren<Button>() )
        {
            var target = button.targetGraphic; 
            if (target == null) target = button.GetComponent<Image>();
            button.colors = template.btnColors;
            button.targetGraphic = target;

        }

        if (template.text == null) return;
        foreach (var text in GetComponentsInChildren<TMP_Text>())
        {
            text.color = template.text.color;
            text.font = template.text.font;
            text.fontSize = template.text.fontSize;
            text.fontStyle = template.text.fontStyle;
            text.alignment = template.text.alignment;
            text.enableWordWrapping = template.text.enableWordWrapping;
            
        }
    }

    private void OnValidate()
    {
        ModifyButtons();
    }

   
}