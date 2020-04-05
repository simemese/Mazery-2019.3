using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{

    [SerializeField] bool nearDoor;
    [SerializeField] Enumerations.color doorColor;
    Door doorNearPlayer;
    GameObject doorObject;
    [SerializeField] Inventory inventory;

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
            Destroy(doorObject);
        }
    }
}
