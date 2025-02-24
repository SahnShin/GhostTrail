using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HovorColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text buttonText; 
    public Image buttonImage;

    public Color hoverColor = Color.black; 
    public Color normalColor;

    void Start()
    {
        if (buttonText != null)
        {
            normalColor = buttonText.color; 
            normalColor = buttonImage.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor;
            buttonImage.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor;
            buttonImage.color = normalColor;
        }
    }
}
