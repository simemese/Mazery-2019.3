using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Enumerations.color color;
    [SerializeField] List<Sprite> spriteList;
    Animator animator;
    Sprite doorSprite;
    [SerializeField] Enumerations.doorType doorType;


    // Start is called before the first frame update

    void Start()
    {
        // determine the identity of the door
        doorSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        animator = gameObject.GetComponent<Animator>();
    }

    public void SetDoorColor(Enumerations.color color)
    {
        this.color = color;
        SetChildColor();
        SetDoorSprite();
        SetDoorAnimator();
    }

    private void SetChildColor()
    {
        if (transform.childCount>0)
        {
            GameObject childObject = transform.GetChild(0).gameObject;
            Door childDoor = childObject.GetComponentInChildren<Door>();
            childDoor.SetDoorColor(color);
        }

    }

    private void SetDoorSprite()
    {
        string spriteName = GetSpriteName(color);

        foreach (var item in spriteList)
        {
            if (item.name==spriteName)
            {
                doorSprite = item;
            }
        }

    }

    private void SetDoorAnimator()
    {
        switch (color)
        {
            case Enumerations.color.purple:
                animator.SetBool("isPurple",true);
            break;
            case Enumerations.color.green:
                animator.SetBool("isGreen", true);
                break;
            case Enumerations.color.red:
                animator.SetBool("isRed", true);
                break;
            case Enumerations.color.teal:
                animator.SetBool("isTeal", true);
                break;
        }

    }

    private string GetSpriteName(Enumerations.color color)
    {
        string spriteName="";

        if (doorType==Enumerations.doorType.front)
        {
            switch (color)
            {
                case Enumerations.color.purple:
                    spriteName = "portal_purple_animation_0";
                    break;
                case Enumerations.color.green:
                    spriteName = "portal_green_animation_0";
                    break;
                case Enumerations.color.red:
                    spriteName = "portal_red_animation_0";
                    break;
                case Enumerations.color.teal:
                    spriteName = "portal_teal_animation_0";
                    break;
            }
        }
        else if (doorType == Enumerations.doorType.side)
        {
            switch (color)
            {
                case Enumerations.color.purple:
                    spriteName = "portals_top_24";
                    break;
                case Enumerations.color.green:
                    spriteName = "portals_top_20";
                    break;
                case Enumerations.color.red:
                    spriteName = "portals_top_28";
                    break;
                case Enumerations.color.teal:
                    spriteName = "portals_top_16";
                    break;
            }
        }
        return spriteName;
    }

    public Enumerations.color GetDoorColor()
    {
        return color;
    }

    public Enumerations.doorType GetDoorType()
    {
        return doorType;
    }

}
