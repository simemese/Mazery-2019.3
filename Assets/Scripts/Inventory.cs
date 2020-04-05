using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int startRed;
    [SerializeField] int startGreen;
    [SerializeField] int startPurple;
    [SerializeField] int startYellow;
    UIGemButton[] gemButtons;

    Dictionary<Enumerations.color, int> gemInventory;
    private void Start()
    {
        //set up references
        gemButtons = FindObjectsOfType<UIGemButton>();
        gemInventory = new Dictionary<Enumerations.color, int>();
        GenerateStartingInventory();
        UpdateGemButtons();
    }

    private void GenerateStartingInventory()
    {
        gemInventory.Add(Enumerations.color.green, startGreen);
        gemInventory.Add(Enumerations.color.red, startRed);
        gemInventory.Add(Enumerations.color.yellow, startYellow);
        gemInventory.Add(Enumerations.color.purple, startPurple);
    }

    public void AddGems(Enumerations.color color, int number)
    {
        gemInventory[color] += number;
        UpdateGemButton(color);
    }

    public void UseGems(Enumerations.color color, int number)
    {
        gemInventory[color] -= number;
        UpdateGemButton(color);
    }

    public void UpdateGemButtons()
    {
        foreach (var item in gemButtons)
        {
            Enumerations.color color=item.GetButtonColor();
            item.UpdateNumberOfGems(gemInventory[color]);
        }
    }

    private void UpdateGemButton(Enumerations.color color)
    {
        foreach (var item in gemButtons)
        {
            if (item.GetButtonColor()==color)
            {
                item.UpdateNumberOfGems(gemInventory[color]);
            }
        }
    }
}
