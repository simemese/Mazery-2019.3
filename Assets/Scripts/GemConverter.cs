using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GemConverter : MonoBehaviour, IPointerDownHandler
{
    Image buttonBackground;
    Image circleBackground;
    public bool converterActive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        buttonBackground = FindObjectOfType<ButtonLayer>().GetComponent<Image>();
        circleBackground = GetComponentInChildren<Image>();
        converterActive = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (converterActive)
        {
            buttonBackground.color = new Color32(204, 204,204,140);
            circleBackground.color= new Color32(255, 255, 255, 255);
            converterActive = false;
        }
        else if (!converterActive)
        {
            buttonBackground.color = new Color32(255, 255, 255, 255);
            circleBackground.color = new Color32(255, 255, 255, 255);
            converterActive = true;
        }

    }

    public Enumerations.color ConvertGemColor(Enumerations.color inputColor)
    {
        Enumerations.color outputColor=Enumerations.color.red;

        switch (inputColor)
        {
            case Enumerations.color.red:
                outputColor = Enumerations.color.green;
                break;
            case Enumerations.color.green:
                outputColor = Enumerations.color.purple;
                break;
            case Enumerations.color.purple:
                outputColor = Enumerations.color.teal;
                break;
            case Enumerations.color.teal:
                outputColor = Enumerations.color.red;
                break;
        }

        return outputColor;
 
    }
}   


