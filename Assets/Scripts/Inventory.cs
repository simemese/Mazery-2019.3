using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Starting Inventory")]
    [SerializeField] int startRed;
    [SerializeField] int startGreen;
    [SerializeField] int startPurple;
    [SerializeField] int startYellow;
    [Header("Mana Costs")]
    [SerializeField] int manaCostRed = 20;
    [SerializeField] int manaCostGreen = 50;
    [SerializeField] int manaCostYellow = 30;
    [SerializeField] int manaCostPurple = 40;

    Dictionary<Enumerations.color, int> manaCostDictionary;
    UIGemButton[] gemButtons;

    Dictionary<Enumerations.color, int> gemInventory;

    private void Awake()
    {
        gemInventory = new Dictionary<Enumerations.color, int>();

        //build mana cost dictionary
        manaCostDictionary = new Dictionary<Enumerations.color, int>();
        manaCostDictionary.Add(Enumerations.color.red, manaCostRed);
        manaCostDictionary.Add(Enumerations.color.green, manaCostGreen);
        manaCostDictionary.Add(Enumerations.color.yellow, manaCostYellow);
        manaCostDictionary.Add(Enumerations.color.purple, manaCostPurple);
    }
    private void Start()
    {
        //set up references
        gemButtons = FindObjectsOfType<UIGemButton>();
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

    public int GetManaCost(Enumerations.color color)
    {
        return manaCostDictionary[color];
    }
}
