using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    [SerializeField] int startingMana=100;
    Slider manaSlider;
    int currentMana=0;
    Text manaText;

    // Start is called before the first frame update
    void Start()
    {
        manaSlider = gameObject.GetComponent<Slider>();
        manaText = gameObject.GetComponentInChildren<Text>();
        UpdateMaxMana(startingMana);
        currentMana += startingMana;
        UpdateManaBar(currentMana);
    }

    private void UpdateMaxMana(int maxValue)
    {
        manaSlider.maxValue = maxValue;
    }

    private void UpdateManaBar(int currentMana)
    {
        manaSlider.value = currentMana;
        manaText.text = currentMana.ToString() + "/" + manaSlider.maxValue.ToString();
    }

    public void AdjustMana(int mana)
    {
        if (currentMana+mana>0)
        {
            currentMana += mana;
            UpdateManaBar(currentMana);
        }

    }
}
