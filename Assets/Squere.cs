using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Squere
{
    public bool ocupied;
    public  GameObject piece;      // type Piece would be better
    public Vector2Int position;
    public PieceColor color;
    private GameObject Tile;

    public Squere(PieceColor colour, bool ocupi, Vector2Int pos,GameObject tile)
    {
        ocupied = ocupi;
        color = colour;
        position = pos;
        Tile = tile;
    }

    public Squere(GameObject tileobj)
    {
        ocupied = IsOcupied(tileobj);
        color = WhatColorIsIt(tileobj);
        position = WhatsThePosition(tileobj);
        Tile = tileobj;
    }
    public void GetPiece()
    {
        if (piece == null)
        {
            IsOcupied(Tile,ref piece);
        }
    }
    private bool IsOcupied(GameObject tile, ref GameObject piece)
    {
        Vector2 tilePos = tile.transform.position;
        
        Collider2D[] coliders = Physics2D.OverlapBoxAll(tilePos,new Vector2(1f,1f),0f);

        foreach (Collider2D collider in coliders)
        {
            if (collider.CompareTag("Piece"))
            {
                piece = collider.gameObject;
                return true;
            }
        }
        return false;
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