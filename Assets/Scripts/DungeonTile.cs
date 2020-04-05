using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTile : MonoBehaviour
{
    public Enumerations.tileType tileType { get; set; }
    public int rowCoordinate { get; set; }
    public int columnCoordinate { get; set; }

}
