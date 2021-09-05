using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int connectionMax = 4;
    public static int pathGoal;
    public static int connectionTotal = 0;
    public static int currentValue;
    public static void AddConnection()
    {
        connectionTotal ++;
        GameObject[] stations = GameObject.FindGameObjectsWithTag("station");
        stations[Random.Range(0, stations.Length)].SendMessage("AddConnection");
    }

    public static void AddBooth(int value)
    {
        currentValue = value;
        GameObject[] stations = GameObject.FindGameObjectsWithTag("station");
        stations[Random.Range(0, stations.Length)].SendMessage("AddBooth");
    }
}
