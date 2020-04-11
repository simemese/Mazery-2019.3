using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    
    [SerializeField] float speed = 1f;
    [SerializeField] Enumerations.color color;
    [SerializeField] List<Sprite> spriteList;
    [SerializeField] bool spawned = true;
    [SerializeField] float minDistance=0.5f;
    [SerializeField] float minDistanceForDisappearance = 0.02f;

    Sprite gemSprite;
    Wizard wizard;
    Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        wizard = FindObjectOfType<Wizard>();
        
        SetGemColor();
    }

    private void Update()
    {
        float distance = Mathf.Abs(Vector3.Distance(gameObject.transform.position, wizard.transform.position));
        bool closeEnough= distance < minDistance;

        if (spawned)
        {
            if (closeEnough)
            {
                Vector3 target = wizard.transform.position;

                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                bool gemIsCloseEnough = Mathf.Abs(Vector3.Distance(transform.position, wizard.transform.position))< minDistanceForDisappearance;

                if (gemIsCloseEnough)
                {
                    inventory.AddGems(color, 1);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void SetGemColor()
    {
        int randomIndex = Random.Range(0, spriteList.Count);
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[randomIndex];
        gemSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        switch (gemSprite.name)
        {
            case "purple_gem_animation_0":
                color = Enumerations.color.purple;
                break;
            case "green_gem_animation_0":
                color = Enumerations.color.green;
                break;
            case "red_gem_animation_0":
                color = Enumerations.color.red;
                break;
            case "teal_gem_animation_0":
                color = Enumerations.color.teal;
                break;
        }

    }

    public void SetSpawnedStatus(bool spawned)
    {
        this.spawned = spawned;
    }
    public bool GetSpawnedStatus()
    {
        return spawned;
    }
}
