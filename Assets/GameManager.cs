using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    // static public int Turn = 0;
    static public PieceColor Turn = PieceColor.White;

    public static void EndOfTheTurn(PieceColor color)
    {
        if (color == PieceColor.White && Turn == PieceColor.White)
        {
            Turn = PieceColor.Black; 
        }
        else if (color == PieceColor.Black && Turn == PieceColor.Black)
        {
            Turn = PieceColor.White;
        }
    }

    public static void PrintTheTurn()
    {
        Debug.Log(Turn);
    } 
    
}
