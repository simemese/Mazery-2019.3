using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConverterGem : MonoBehaviour
{
    [SerializeField] Enumerations.color color;
    Text manaCostText;
    UIGemButton[] gemButtons;
    // Start is called before the first frame update

    private void Start()
    {
        manaCostText = gameObject.GetComponentInChildren<Text>();
        gemButtons = FindObjectsOfType<UIGemButton>();
        GetManaCostOfGem();
    }

    private void GetManaCostOfGem()
    {
        foreach (var item in gemButtons)
        {
            if (item.GetButtonColor()==color)
            {
                manaCostText.text = item.GetManaCost().ToString();
            }
        }
    }

}
