using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int numberOfRows=4;
    [SerializeField] int numberOfColumns = 8;
    [SerializeField] DungeonTile dungeonTilePrefab;
    [SerializeField] EdgeOfMap topEdge;
    [SerializeField] EdgeOfMap bottomEdge;
    [SerializeField] EdgeOfMap rightEdge;
    [SerializeField] EdgeOfMap leftEdge;
    float tileSizeX;
    float tileSizeY;
    float edgeSize = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        tileSizeX = dungeonTilePrefab.GetComponent<BoxCollider2D>().size.x;
        tileSizeY = dungeonTilePrefab.GetComponent<BoxCollider2D>().size.y;
        ResizeGameArea();
        GenerateGrid();
    }

    private void ResizeGameArea()
    {
        gameObject.GetComponent<BoxCollider2D>().size = new Vector3(numberOfColumns*tileSizeX,numberOfRows*tileSizeY,0);

        //top edge
        topEdge.GetComponent<BoxCollider2D>().size=new Vector3(edgeSize,numberOfColumns * tileSizeX+edgeSize*2,0);
        topEdge.transform.position = new Vector3( - gameObject.transform.position.x, gameObject.GetComponent<BoxCollider2D>().size.y/2 + edgeSize/2, 0);

        //bottom edge
        bottomEdge.GetComponent<BoxCollider2D>().size = new Vector3(edgeSize, numberOfColumns * tileSizeX + edgeSize * 2, 0);
        bottomEdge.transform.position = new Vector3(-gameObject.transform.position.x, -gameObject.GetComponent<BoxCollider2D>().size.y/2-edgeSize/2, 0);

        //left edge
        leftEdge.GetComponent<BoxCollider2D>().size = new Vector3(numberOfRows * tileSizeY + edgeSize * 2,edgeSize, 0);
        leftEdge.transform.position = new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 + edgeSize / 2, gameObject.transform.position.y, 0);

        //right edge
        rightEdge.GetComponent<BoxCollider2D>().size = new Vector3(numberOfRows * tileSizeY + edgeSize * 2, edgeSize, 0);
        rightEdge.transform.position = new Vector3(-gameObject.GetComponent<BoxCollider2D>().size.x / 2 - edgeSize / 2, gameObject.transform.position.y, 0);
    }

    private void GenerateGrid()
    {
        float xStartingPosition = -gameObject.GetComponent<BoxCollider2D>().size.x / 2 + tileSizeX/2;
        float yStartingPosition = gameObject.GetComponent<BoxCollider2D>().size.y / 2 - tileSizeY / 2;

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < numberOfColumns; column++)
            {
                DungeonTile dungeonTile= Instantiate(dungeonTilePrefab, new Vector2(0,0),transform.rotation);
                dungeonTile.transform.parent = transform;

                float xPosition = xStartingPosition + column * tileSizeX;
                float yPosition = yStartingPosition + -row * tileSizeY;

                dungeonTile.transform.localPosition = new Vector2(xPosition, yPosition);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
