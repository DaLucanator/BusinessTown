using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    GameObject north;
    GameObject east;
    GameObject south;
    GameObject west;

    GameObject one;
    GameObject two;
    GameObject three;
    GameObject four;

    List<GameObject> slots;
    GameObject[] booths;

    int connectionTotal = 1;
    int boothTotal = 0;
    int pathLength = 0;

    void Start()
    {
        north = transform.Find("Connection North").gameObject;
        east = transform.Find("Connection East").gameObject;
        south = transform.Find("Connection South").gameObject;
        west = transform.Find("Connection West").gameObject;

        slots.Add(north);
        slots.Add(east);
        slots.Add(south);
        slots.Add(west);

        booths.SetValue(one, 0);
        booths.SetValue(two, 1);
        booths.SetValue(three, 2);
        booths.SetValue(four, 3);

        if (connectionTotal == 1 && pathLength >= GameController.pathGoal)
        {
            //end
        }
        else
        {
            GameController.AddConnection();
        }

    }

    public void Disable(string direction)
    {
        if(connectionTotal != 1) {connectionTotal++;}

        if (direction == "north")
        {
            slots.Remove(north);
        }

        if (direction == "east")
        {
            slots.Remove(east);
        }

        if (direction == "south")
        {
            slots.Remove(south);
        }

        if (direction == "west")
        {
            slots.Remove(west);
        }
    }

    public void AddConnection()
    {
        if (connectionTotal != GameController.connectionMax)
        {
            if (connectionTotal != 1) { connectionTotal++; }
            slots[Random.Range(0, slots.Count)].SetActive(true);
        }
        else
        {
            GameController.AddConnection();
        }
    }
    
}
