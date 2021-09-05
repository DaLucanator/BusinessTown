using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public int id;
    public int pathNum;

    public GameObject station;

    public string connectionName;

    public string comesFrom;
    public string GoesTo;

    Vector3 spawn;
    Vector3 spawnNorth;
    Vector3 spawnEast;
    Vector3 spawnSouth;
    Vector3 spawnWest;

    public GameObject myStation;

    private void Awake()
    {
        id = 0;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = Instantiate(Resources.Load("Material") as Material);
        station = Resources.Load<GameObject>("Station");
        connectionName = transform.name;

        spawnNorth = new Vector3(0, 0, 50);
        spawnEast = new Vector3(50, 0, 0);
        spawnSouth= new Vector3(0, 0, -50);
        spawnWest = new Vector3(-50, 0, 0);
    }



    public void AddStation()
    {
        Debug.Log("Connection is instantiating a new station");
        gameObject.GetComponent<BoxCollider>().enabled = true;

        if (connectionName == "Connection North")
        {
            spawn = (transform.position + spawnNorth);
            myStation = Instantiate(station, spawn,Quaternion.identity);
            Debug.Log("north connection disabling southern connection of station");
            myStation.SendMessage("DisableSouth");
        }
        if (connectionName == "Connection East")
        {
            spawn = (transform.position + spawnEast);
            myStation = Instantiate(station, spawn, Quaternion.identity);
            Debug.Log("east connection disabling western connection of station");
            myStation.SendMessage("DisableWest");
        }
        if (connectionName == "Connection South")
        {
            spawn = (transform.position + spawnSouth);
            myStation = Instantiate(station, spawn, Quaternion.identity);
            Debug.Log("south connection disabling north connection of station");
            myStation.SendMessage("DisableNorth");
        }
        if (connectionName == "Connection West")
        {
            spawn = (transform.position + spawnWest);
            myStation = Instantiate(station, spawn, Quaternion.identity);
            Debug.Log("west connection disabling eastern connection of station");
            myStation.SendMessage("DisableEast");
        }
    }

    public void BoothSetup()
    {
        Debug.Log("THe connection is" + transform.name);
        Debug.Log("connection activated renderer prior to adding booth");
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        id = GameController.currentId;
        this.gameObject.GetComponent<Renderer>().material.color = GameController.colors[id];
        gameObject.tag = id.ToString();
        Debug.Log("the connection has id of " + id.ToString());
        AddBooth();
    }

    public void AddBooth()
    {
        Debug.Log("Connection is sending message to Gamecontroller to add a booth");
        GameController.AddBooth(id);
    }

}
