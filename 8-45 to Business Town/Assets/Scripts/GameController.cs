using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject firstStation;
    public static GameData gameData;

    public static int connectionMax = 4;
    public static int pathMax = 7;

    public static int currentId = 0;
    public static int currentPathNum;

    public static List<GameObject> stations = new List<GameObject>();
    public static List<Color> colors = new List<Color>();

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            colors.Add(gameData.colors[i]);
        }
        firstStation.SendMessage("EndCheck");
    }

    public static void TrackStation(GameObject station)
    {
        stations.Add(station);
        station.transform.name = gameData.names[stations.Count];
    }

    public static void AddConnection(bool increaseId)
    {
        if (increaseId) { currentId++;}
        Debug.Log(currentId.ToString());
        Debug.Log("GameController sending message to add connection to  random station");
        stations[Random.Range(0, stations.Count)].SendMessage("AddConnection");
    }

    public static void AddBooth(int Id)
    {
        currentId = Id;
        Debug.Log("GameController is sending a message to a random station to add a booth");
        stations[Random.Range(0, stations.Count)].SendMessage("AddBooth");
    }

    public static void AddStation()
    {
        GameObject connection = GameObject.FindGameObjectWithTag(currentId.ToString());
        Debug.Log("GameController is telling the connection with the right id to Add a station, the id is " + currentId.ToString());
        connection.SendMessage("AddStation");
    }

}
