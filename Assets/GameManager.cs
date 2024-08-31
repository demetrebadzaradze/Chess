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

    public static PieceColor GetPieceColor(GameObject piece)
    {
        string name = piece.name;
        string res = "";

        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] == ' ')
            {
                break;
            }
            res += name[i]; 
        }

        switch (res)
        {
            case "white":
                return PieceColor.White;
            case "black":
                return PieceColor.Black;
            default:
                return PieceColor.White;
        }
    }
    public static PieceName GetPieceName(GameObject piece)
    {
        string name = piece.name;
        string result = "";
        
        for (int i = name.Length - 1 - 7; i >= 0 ; i--)
        {
            if (name[i] == ' ')
            {
                break;
            }
            result = name[i] + result;
        }

        switch (result)
        {
            case "pawn":
                return PieceName.Pawn;
            case "rook":
                return PieceName.Rook;
            case "knight":
                return PieceName.Knight;
            case "bishop":
                return PieceName.Bishop;
            case "queen":
                return PieceName.Queen;
            case "king":
                return PieceName.King;
            default:
                return PieceName.Queen;
        }
    }
}
