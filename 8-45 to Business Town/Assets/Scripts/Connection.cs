using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public int value = 0;

    private void Start()
    {
        value = GameController.connectionTotal;
        GameController.AddBooth(value);
    }
}
