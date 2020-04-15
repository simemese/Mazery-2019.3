using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LootSpawner : MonoBehaviour
{
    [SerializeField] Potion potionPrefab;
    [SerializeField] Gem gemPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] bool looted = false;
    [SerializeField] float minLootDistance = 10f;

    List<Gem> gems;
    Dictionary<Gem, Vector3> targetVectors;
    TextMeshPro hoverText;
    Wizard wizard;
    
    // Start is called before the first frame update
    private void Start()
    {
        hoverText = transform.GetComponentInChildren<TextMeshPro>();
        gems = new List<Gem>();
        targetVectors = new Dictionary<Gem, Vector3>();
        wizard = FindObjectOfType<Wizard>();
        hoverText.SetText("");
    }
    public void SpawnLoot()
    {
        float xOffset = 0;
        
        if (!looted)
        {
            int gemCount = GetGemCount();

            Debug.Log("Spawn " + gemCount + "gems");

            for (int i = 0; i < gemCount; i++)
            {
                Debug.Log("spawn gem " + i);
                Gem gem = Instantiate(gemPrefab, transform.position, transform.rotation);
                gem.SetSpawnedStatus(false);
                gem.transform.parent = gameObject.transform;
                gems.Add(gem);

                Vector3 target = new Vector3(xOffset, -0.2f, 0);

                targetVectors.Add(gem, target);
                xOffset += 0.1f;
            }

            looted = true;
        }
    }

    private static int GetGemCount()
    {
        int gemCount;
        int randomizer = Random.Range(0, 100);
        Debug.Log(randomizer);

        if (randomizer > 89)
        {
            gemCount = 3;
        }
        else if (randomizer > 69)
        {
            gemCount = 2;
        }
        else if (randomizer > 40)
        {
            gemCount = 1;
        }
        else
        {
            gemCount = 0;
        }

        return gemCount;
    }

    private void Update()
    {
        float distance = Vector3.Distance(wizard.transform.position, gameObject.transform.position);
        Debug.Log("Is distance " + distance + " smaller than min distance " + minLootDistance);
        if (distance < minLootDistance)
        {
            ShowHoverText();
        }
        else
        {
            hoverText.SetText("");
        }

        foreach (var gem in gems)
        {
            if (!gem.GetSpawnedStatus())
            {
                gem.transform.localPosition = Vector3.MoveTowards(gem.transform.localPosition, targetVectors[gem], speed * Time.deltaTime);
                if (gem.transform.localPosition == targetVectors[gem])
                {
                    //gems[key] = false;
                    gem.SetSpawnedStatus(true);
                }   
            }
        }
    }

    public void ShowHoverText()
    {
        if (looted)
        {
            hoverText.SetText("[Empty]");
        }
        else
        {
            hoverText.SetText("[Space]");
        }
    }
}
