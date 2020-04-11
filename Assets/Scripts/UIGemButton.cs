using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIGemButton : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] Enumerations.color color;
    public int currentGemNumber;
    Text gemNumber;
    Animator animator;
    Wizard wizard;
    bool isConverterActive;
    GemConverter gemConverter;
    Inventory inventory;
    Mana mana;

    private void Start()
    {
        gemNumber = gameObject.GetComponentInChildren<Text>();
        animator = gameObject.GetComponent<Animator>();
        wizard = FindObjectOfType<Wizard>();
        gemConverter = FindObjectOfType<GemConverter>();
        inventory = FindObjectOfType<Inventory>();
        mana = FindObjectOfType<Mana>();
        currentGemNumber = 0;
    }

    public void UpdateNumberOfGems(int number)
    {
        if (number > currentGemNumber)
        {
            animator.SetTrigger("IncreaseGem");
        }
        else if (number < currentGemNumber)
        {
            animator.SetTrigger("DecreaseGem");
        }

        gemNumber.text = number.ToString();
        currentGemNumber = number;
    }

    public Enumerations.color GetButtonColor()
    {
        return color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isConverterActive = gemConverter.converterActive;

        if (isConverterActive)
        {
            int manaCost = inventory.GetManaCost(color);
            mana.AdjustMana(-manaCost);
            Enumerations.color convertedColor = gemConverter.ConvertGemColor(color);
            inventory.UseGems(color, 1);
            inventory.AddGems(convertedColor, 1);
        }
        else if (!isConverterActive)
        {
            //check if number of gems is greater than 0
            if (currentGemNumber > 0)
            {
                wizard.OpenDoor(color);
            }
        }
    }

}
