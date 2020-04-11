using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConverterGem : MonoBehaviour
{
    [SerializeField] Enumerations.color color;
    Text manaCostText;
    UIGemButton[] gemButtons;
    Inventory inventory;
    // Start is called before the first frame update


    private void Start()
    {
        manaCostText = gameObject.GetComponentInChildren<Text>();
        gemButtons = FindObjectsOfType<UIGemButton>();
        inventory = FindObjectOfType<Inventory>();
        GetManaCostOfGem();
    }

    private void GetManaCostOfGem()
    {
        int manaCost = inventory.GetManaCost(color);
        manaCostText.text = manaCost.ToString();
    }

}
