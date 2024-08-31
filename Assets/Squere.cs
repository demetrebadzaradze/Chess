using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Squere
{
    public bool ocupied;
    public Piece piece;
    public Vector2Int position;
    public PieceColor color;

    public Squere(PieceColor colour, bool ocupi, Vector2Int pos)
    {
        ocupied = ocupi;
        color = colour;
        position = pos;
    }
    static public bool IsOcupied(GameObject tile)
    {
        Vector2 tilePos = tile.transform.position;
        
        Collider2D[] coliders = Physics2D.OverlapBoxAll(tilePos,new Vector2(1f,1f),0f);

        foreach (Collider2D collider in coliders)
        {
            if (collider.CompareTag("Piece"))
            {
                return true;
            }
        }
        return false;
    } 
    static public PieceColor WhatColorIsIt(GameObject tile)
    {
        if (tile.name.Contains("White"))
        {
            return PieceColor.White;
        }
        else //if (tile.name.Contains("Black"))
        {
            return PieceColor.Black;
        }
    }
    static public Vector2Int WhatsThePosition(GameObject tile)
    {
        return new Vector2Int
        (
            Convert.ToInt32(tile.transform.position.x - 0.5),
            Convert.ToInt32(tile.transform.position.y - 0.5)
        );
    }
}