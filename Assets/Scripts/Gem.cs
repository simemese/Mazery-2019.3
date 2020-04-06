using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] float speed = 1f;
    bool moving=false;
    GameObject player;
    [SerializeField] Enumerations.color color;
    Sprite gemSprite;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        gemSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        SetGemColor();
    }

    private void Update()
    {
        if (moving)
        {
            Vector3 target = player.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);

            if (transform.position == player.transform.position)
            {
                moving = false;
                inventory.AddGems(color, 1);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            moving = true;
            player = collision.gameObject;

        }    
    }

    private void SetGemColor()
    {
        switch (gemSprite.name)
        {
            case "purpleGem":
                color = Enumerations.color.purple;
                break;
            case "greenGem":
                color = Enumerations.color.green;
                break;
            case "redGem":
                color = Enumerations.color.red;
                break;
            case "yellowGem":
                color = Enumerations.color.yellow;
                break;
        }

    }
}
