using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    [SerializeField] bool nearDoor;
    [SerializeField] Enumerations.color doorColor;
    [SerializeField] Inventory inventory;
    [SerializeField] float minLootDistance = 0.2f;

    Door doorNearPlayer;
    GameObject doorObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Door")
        {
            nearDoor = true;
            doorNearPlayer = collision.gameObject.GetComponent<Door>();
            doorColor = doorNearPlayer.GetDoorColor();
            doorObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            nearDoor = false;
            doorNearPlayer = null;
        }      
    }

    public void OpenDoor(Enumerations.color color)
    {
        if (nearDoor && doorColor==color)
        {
            inventory.UseGems(color, 1);
            doorObject.GetComponent<Destroyer>().Disappear();
            nearDoor = false;
        }
    }

    private void Update()
    {
        LootObject();
    }

    private void LootObject()
    {
        if(Input.GetAxis("Jump")>0)
        {
            LootSpawner[] lootSpawners = FindObjectsOfType<LootSpawner>();

            foreach (var item in lootSpawners)
            {
                float distance = Vector3.Distance(item.transform.position, gameObject.transform.position);
                if (distance < minLootDistance)
                {
                    item.SpawnLoot();
                }
            }
        }
    }
}
