using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] List<Sprite> spriteList;

    // Start is called before the first frame update
    void Start()
    {
        SetSprite();
    }


    private void SetSprite()
    {
        int spriteCount = spriteList.Count;
        int randomIndex = Random.Range(0, spriteCount);
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
