using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Squere tile = null;
    void Start()
    {
        tile = new Squere
        (
            Squere.WhatColorIsIt(gameObject),
            Squere.IsOcupied(gameObject),
            Squere.WhatsThePosition(gameObject),
            this.gameObject
        );

        Debug.Log(tile.color + " ____ " + tile.ocupied + " ____ " + tile.position + " ---------- " + gameObject.name + " ____ " + gameObject.transform.position);
    }
    void Update()
    {
        
    }
}
