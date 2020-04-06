using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> gemSpriteList;
    [SerializeField] Gem gemPrefab;
    float tileWidth;
    float tileHeight;
    [SerializeField] int possibleItemPositions = 9;
    float tileScale = 0.9f;
    float slices;
    float sliceWidth;
    float sliceHeight;
    int gemCount = 0;
    [SerializeField] int probabilityOfSpawningPerc = 20;

    // Start is called before the first frame update
    void Start()
    {
        tileWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
        tileHeight= gameObject.GetComponent<BoxCollider2D>().size.y;
        slices = Mathf.Pow(possibleItemPositions, 0.5f);
        sliceWidth = tileWidth * tileScale / slices;
        sliceHeight = tileHeight * tileScale / slices;

        GenerateGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Sprite GenerateGemSprite()
    {
        int spriteCount = gemSpriteList.Count;
        int randomIndex = Random.Range(0, spriteCount);

        Sprite gemSprite = gemSpriteList[randomIndex];

        return gemSprite;
    }

    private void GenerateGems()
    {
        List<float> xList = GenerateXCoordinates();
        List<float> yList = GenerateYCoordinates();

        for (int rowIndex = 0; rowIndex < xList.Count; rowIndex++)
        {
            for (int colIndex = 0; colIndex < yList.Count; colIndex++)
            {
                int randomNumber = Random.Range(1, 100);
                if (randomNumber<probabilityOfSpawningPerc)
                {
                    Gem gem = Instantiate(gemPrefab, transform.position, transform.rotation);
                    gem.transform.parent = gameObject.transform;
                    gem.GetComponent<SpriteRenderer>().sprite = GenerateGemSprite();
                    gem.transform.localPosition = new Vector3(xList[rowIndex], yList[colIndex], 0);
                }
            }
        }
    }

    private List<float> GenerateXCoordinates()
    {
        List<float> xList = new List<float>();
        float xPoint = -tileScale*tileWidth/2+ sliceWidth / 2;
        xList.Add(xPoint);
        for (int i = 1; i < slices; i++)
        {
            xList.Add(xList[i-1] + sliceWidth);
        }

        return xList;
    }

    private List<float> GenerateYCoordinates()
    {
        List<float> yList = new List<float>();

        float yPoint = tileScale * tileHeight / 2 - sliceHeight / 2;
        yList.Add(yPoint);
        for (int i = 1; i < slices; i++)
        {
            yList.Add(yList[i - 1] - sliceHeight);
        }

        return yList;
    }

}
