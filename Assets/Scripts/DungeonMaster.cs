using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public Dictionary<(int,int), Enumerations.tileType> dungeonTileList;
    public HashSet<Enumerations.tileType> dungeonTypes;

    private void Start()
    {
        dungeonTileList = new Dictionary<(int, int), Enumerations.tileType>();
        dungeonTypes = new HashSet<Enumerations.tileType>();
    }

    public void AddToDungeonTileList((int,int) dungeonId, Enumerations.tileType tileType)
    {
        dungeonTileList.Add(dungeonId,tileType);
        if (!dungeonTypes.Contains(tileType))
        {
            dungeonTypes.Add(tileType);
        }
    }

    public bool CheckIfTileTypeExists(Enumerations.tileType tileType)
    {
        return dungeonTypes.Contains(tileType);
    }

}
