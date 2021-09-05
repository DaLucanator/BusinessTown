using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : MonoBehaviour
{
    public int id = 0;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = Instantiate(Resources.Load("Material") as Material);
        id = GameController.currentId;
        this.gameObject.GetComponent<Renderer>().material.color = GameController.colors[id];
        Debug.Log("Booth is telling GameController to add a station");
        GameController.AddStation();
    }
}
