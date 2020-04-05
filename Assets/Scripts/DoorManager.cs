using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Door doorPrefab;
    [SerializeField] List<Sprite> doorSpriteList;
    public Enumerations.color color;
    float doorHeight;
    float doorWidth;
    float dungeonSizeX;
    float dungeonSizeY;

    // Start is called before the first frame update
    void Start()
    {
        doorHeight = doorPrefab.GetComponent<BoxCollider2D>().size.y;
        doorWidth = doorPrefab.GetComponent<BoxCollider2D>().size.x;
        dungeonSizeX = gameObject.GetComponent<BoxCollider2D>().size.x;
        dungeonSizeY = gameObject.GetComponent<BoxCollider2D>().size.y;

        GenerateDoors();
    }

    private void GenerateDoors()
    {
        Debug.Log("Generate Doors");

        //create a top door
        Door door = GenerateDoorObject();
        door.transform.Rotate(0, 0, 90);
        door.transform.localPosition = new Vector3(0, dungeonSizeY/2-doorWidth/2, 0);

        //create a bottom door
        door = GenerateDoorObject();
        door.transform.Rotate(0, 0, -90);
        door.transform.localPosition = new Vector3(0, -dungeonSizeY / 2 + doorWidth / 2, 0);

        //generate a left door
        door = GenerateDoorObject();
        door.transform.Rotate(0, 0, 180);
        door.transform.localPosition = new Vector3(-dungeonSizeX / 2 + doorWidth / 2, 0, 0);

        //generate a right door
        door = GenerateDoorObject();
        door.transform.Rotate(0, 0, 0);
        door.transform.localPosition = new Vector3(dungeonSizeX / 2 - doorWidth / 2, 0, 0);
    }

    private Door GenerateDoorObject()
    {
        Sprite doorSprite = GenerateDoorSprite();
        Door door = Instantiate(doorPrefab, new Vector3(0, 0, 0), gameObject.transform.rotation);
        door.transform.parent = gameObject.transform;
        door.GetComponent<SpriteRenderer>().sprite = doorSprite;
        return door;
    }

    private Sprite GenerateDoorSprite()
    {
        int spriteCount = doorSpriteList.Count;
        int randomIndex = Random.Range(0, spriteCount);

        Sprite doorSprite = doorSpriteList[randomIndex];

        return doorSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
