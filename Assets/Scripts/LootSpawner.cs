using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] Potion potionPrefab;
    [SerializeField] Gem gemPrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] bool looted = false;
    List<Gem> gems;
    Dictionary<Gem, Vector3> targetVectors;

    // Start is called before the first frame update
    private void Start()
    {
        gems = new List<Gem>();
        targetVectors = new Dictionary<Gem, Vector3>();
    }
    public void SpawnLoot()
    {
        float xOffset = 0;
        
        if (!looted)
        {
            int gemCount = GetGemCount();

            Debug.Log("Spawn " + gemCount + "gems");

            for (int i = 0; i < gemCount; i++)
            {
                Debug.Log("spawn gem " + i);
                Gem gem = Instantiate(gemPrefab, transform.position, transform.rotation);
                gem.SetSpawnedStatus(false);
                gem.transform.parent = gameObject.transform;
                gems.Add(gem);

                Vector3 target = new Vector3(xOffset, -0.2f, 0);

                targetVectors.Add(gem, target);
                xOffset += 0.1f;
            }

            looted = true;
        }
    }

    private static int GetGemCount()
    {
        int gemCount;
        int randomizer = Random.Range(0, 100);
        Debug.Log(randomizer);

        if (randomizer > 89)
        {
            gemCount = 3;
        }
        else if (randomizer > 69)
        {
            gemCount = 2;
        }
        else if (randomizer > 40)
        {
            gemCount = 1;
        }
        else
        {
            gemCount = 0;
        }

        return gemCount;
    }

    private void Update()
    {
        foreach (var gem in gems)
        {
            if (!gem.GetSpawnedStatus())
            {
                gem.transform.localPosition = Vector3.MoveTowards(gem.transform.localPosition, targetVectors[gem], speed * Time.deltaTime);
                if (gem.transform.localPosition == targetVectors[gem])
                {
                    //gems[key] = false;
                    gem.SetSpawnedStatus(true);
                }   
            }
        }

        ////clean up spawned gems
        //for (int i = 0; i < gems.Count; i++)
        //{
        //    if (gems[i].GetSpawnedStatus())
        //    {
        //        targetVectors.Remove(gems[i]);
        //        gems.RemoveAt(i);
        //    }
        //}
    }
}
