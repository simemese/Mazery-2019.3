using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> floorSpriteList;
    Enumerations.tileType tileType;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = GenerateFloorSprite();
        gameObject.GetComponentInParent<DungeonTile>().tileType=tileType;
    }

    private Sprite GenerateFloorSprite()
    {
        int spriteCount = floorSpriteList.Count;
        int randomIndex = Random.Range(0, spriteCount);
        Sprite floorSprite = floorSpriteList[randomIndex];

        switch(floorSprite.name)
        {
            case "bookDungeon":
                tileType = Enumerations.tileType.book;
                break;
            case "fireDungeon":
                tileType = Enumerations.tileType.fire;
                break;
            case "orbDungeon":
                tileType = Enumerations.tileType.orb;
                break;
            case "stoneDungeon":
                tileType = Enumerations.tileType.stone;
                break;
            case "treasureDungeon":
                tileType = Enumerations.tileType.treasure;
                break;
        }

        return floorSpriteList[randomIndex];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
