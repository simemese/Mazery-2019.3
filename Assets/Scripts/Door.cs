using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Enumerations.color color;
    Sprite doorSprite;
    // Start is called before the first frame update
    void Start()
    {
        // determine the identity of the door
        doorSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        SetDoorColor();
    }

    private void SetDoorColor()
    {
        switch (doorSprite.name)
        {
            case "purpleDoor":
                color = Enumerations.color.purple;
                break;
            case "greenDoor":
                color = Enumerations.color.green;
                break;
            case "redDoor":
                color = Enumerations.color.red;
                break;
            case "yellowDoor":
                color = Enumerations.color.yellow;
                break;
        }

    }

    public Enumerations.color GetDoorColor()
    {
        Debug.Log("Color of the door was requested: " + color);
        return color;
    }

}
