using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomizeDoorColors();
        //RandomizeAnimationDelay();
    }

    private void RandomizeDoorColors()
    {
        Door[] doorArray = FindObjectsOfType<Door>();

        foreach (var item in doorArray)
        {
            if (item.tag=="Door" || item.tag=="SideDoor")
            {
                int randomIndex = Random.Range(0, 4);
                Enumerations.color color = Enumerations.color.red;

                switch (randomIndex)
                {
                    case 0:
                        color = Enumerations.color.purple;
                        break;
                    case 1:
                        color = Enumerations.color.green;
                        break;
                    case 2:
                        color = Enumerations.color.red;
                        break;
                    case 3:
                        color = Enumerations.color.teal;
                        break;
                }
                item.SetDoorColor(color);
            }

        }
    }
}
