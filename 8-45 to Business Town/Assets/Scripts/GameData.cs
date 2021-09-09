using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string[] names1;
    public string[] names2;
    public string[] names;

    public Color32[] colors;

    private void Awake()
    {
        for (int i = 0; i < 50; i++)
        {
            names[i] = names1[Random.Range(0, names1.Length)] + names2[Random.Range(0, names2.Length)];
        }
        GameController.gameData = this;

        for (int i = 0; i < 100; i++)
        {
            colors[i] = new Color(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f),1);
        }
    }
}
