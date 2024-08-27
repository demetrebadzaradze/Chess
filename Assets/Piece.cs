using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Piece
{
    public PieceName Name;
    public PieceColor Color;
    public Vector2Int position;

    public Piece(Vector2Int pos, PieceColor color, PieceName name)
    {
        position = pos;
        Color = color;
        Name = name;
    }
    public virtual bool IsAValidMove(Vector2Int movePos)
    {
        return false;
    }
    public bool IsAValidTurn()
    {
        if (Color == GameManager.Turn)
        {
            return true;
        }
        return false;
    }
}
