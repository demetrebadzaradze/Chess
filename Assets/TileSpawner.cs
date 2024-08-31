using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject WhiteTile;
    public GameObject BlackTile;
    // Start is called before the first frame update
    void Start()
    {
        float Xposition = 0.5f;  //-3.5f;
        float Yposition = 0.5f;  //3.5f;
        float space = 1.0f;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (ChessManager.tilePosition[i, j] == 1)
                {
                    GameObject tile = Instantiate(WhiteTile, new Vector3(Xposition, Yposition, -1), transform.rotation);
                    tile.name = j.ToString() + i.ToString() + tile.name;
                }
                else
                {
                    GameObject tile = Instantiate(BlackTile, new Vector3(Xposition, Yposition, -1), transform.rotation);
                    tile.name = j.ToString() + i.ToString() + tile.name;
                }

                Console.WriteLine(Xposition.ToString(), Yposition.ToString());

                Xposition += space;
            }
            Xposition = 0.5f; // Reset Xposition after each row
            Yposition += space; // Decrease Yposition to move to the next row
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
