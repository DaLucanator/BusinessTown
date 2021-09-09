using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public GameObject north;
    GameObject east;
    GameObject south;
    GameObject west;

    public GameObject one;
    GameObject two;
    GameObject three;
    GameObject four;

    public List<GameObject> booths = new List<GameObject>();
    public List<GameObject> slots = new List<GameObject>();
    public List<GameObject> connections = new List<GameObject>();

    public int connectionTotal = 0;
    int boothTotal = 0;
    public int pathNum = 0;
    bool isFinalStation;

    void Start()
    {

        pathNum = GameController.currentPathNum;
        GameController.TrackStation(gameObject);

        north = transform.GetChild(0).gameObject;
        east = transform.GetChild(1).gameObject;
        south = transform.GetChild(2).gameObject;
        west = transform.GetChild(3).gameObject;

        one = transform.GetChild(4).gameObject;
        two = transform.GetChild(5).gameObject;
        three = transform.GetChild(6).gameObject;
        four = transform.GetChild(7).gameObject;

        slots.Add(north);
        slots.Add(east);
        slots.Add(south);
        slots.Add(west);

        booths.Add(one);
        booths.Add(two);
        booths.Add(three);
        booths.Add(four);

    }

    public void DisableNorth()
    {
        Debug.Log("northern connection was disabled by station");
        connectionTotal++;
        Destroy(transform.Find("Connection North").gameObject);
        StartCoroutine(Wait());
    }

    public void DisableEast()
    {
        Debug.Log("eastern connection was disabled by station");
        connectionTotal++;
        Destroy(transform.Find("Connection East").gameObject);
        StartCoroutine(Wait());
    }

    public void DisableSouth()
    {
        Debug.Log("southern connection was disabled by station");
        connectionTotal++;
        Destroy(transform.Find("Connection South").gameObject);
        StartCoroutine(Wait());
    }

    public void DisableWest()
    {
        Debug.Log("western connection was disabled by station");
        connectionTotal++;
        Destroy(transform.Find("Connection West").gameObject);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        EndCheck();
    }

    public void AddConnection()
    {
        if (connectionTotal < GameController.connectionMax)
        {
            GameController.currentPathNum = pathNum + 1;
            RaycastHit hit;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            if(Physics.Raycast(transform.position, Vector3.forward, out hit, 150f))
            {
                if(hit.collider.gameObject.CompareTag("station"))
                {
                    Debug.Log("we hit a station");
                    if (transform.Find("Connection North") != null)
                    {
                        Debug.Log("disabling north connection via ray");
                        Destroy(transform.Find("Connection North").gameObject);
                    } 
                }
            }
            if (Physics.Raycast(transform.position, Vector3.right, out hit, 150f))
            {
                if (hit.collider.gameObject.CompareTag("station"))
                {
                    Debug.Log("we hit a station");
                    if (transform.Find("Connection East") != null)
                    {
                        Debug.Log("disabling east connection via ray");
                        Destroy(transform.Find("Connection East").gameObject);
                    }
                }
            }
            if (Physics.Raycast(transform.position, Vector3.forward * -1f, out hit, 150f))
            {
                if (hit.collider.gameObject.CompareTag("station"))
                {
                    Debug.Log("we hit a station");
                    if (transform.Find("Connection South") != null)
                    {
                        Debug.Log("disabling south connection via ray");
                        Destroy(transform.Find("Connection South").gameObject);
                    }
                }
            }
            if (Physics.Raycast(transform.position, Vector3.right * -1f, out hit, 150f))
            {
                if (hit.collider.gameObject.CompareTag("station"))
                {
                    Debug.Log("we hit a station");
                    if (transform.Find("Connection West") != null)
                    {
                        Debug.Log("disabling west connection via ray");
                        Destroy(transform.Find("Connection West").gameObject);
                    }
                }
            }
            gameObject.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("station is enabling a connection");
            StartCoroutine(Wait2());
        }
        else
        {
            Debug.Log("Station had max connections and is sending message back to GameController");
            GameController.AddConnection(false);
        }

        IEnumerator Wait2()
        {
            yield return new WaitForSeconds(0.1f);
            if(slots.Count != 0)
            {
                GameObject slot = slots[Random.Range(0, slots.Count)];
                if (slot == null)
                {
                    Debug.Log("the connection returned null and was removed");
                    slots.Remove(slot);
                    AddConnection();
                }
                else
                    connections.Add(slot);
                slot.SendMessage("BoothSetup");
                slots.Remove(slot);
                connectionTotal++;
            }
            else
            {
                GameController.AddConnection(false);
            }
        }
    }

    public void AddBooth()
    {
        if(boothTotal != 4)
        {
            Debug.Log("Station is activating a random Booth");
            GameObject booth = booths[Random.Range(0, booths.Count)];
            booths.Remove(booth);
            booth.SetActive(true);
            boothTotal++;
        }
        else
        {
            Debug.Log("Station has too many booths and is sending message back to GameController");
            GameController.AddBooth(GameController.currentId);
        }
    }

    public void EndCheck()
    {
        if (pathNum >= GameController.pathMax)
        {
            Debug.Log("end reached");
            //end
        }
        else
        {
            Debug.Log("Station sending message to add connection to Gamecontroller");
            GameController.AddConnection(true);
        }
    }
    
}
