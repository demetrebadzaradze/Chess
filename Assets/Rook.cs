using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public Rook(Vector2Int pos, PieceColor color, PieceName name) : base(pos, color, name)
    {
    }

    public override bool IsAValidMove(Vector2Int newPos)
    {
        foreach (Vector2Int posibleMove in PosibleMoves())
        {
            if (newPos == position + posibleMove)
            {   // Debug.Log("VALID move");
                return IsOutsideOfBorder(newPos);
                // return true;
            }
        }
        Debug.Log("NOT a valid move" + position);
        return false;
    }
    private List<Vector2Int> PosibleMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>() { };

        for (int i = -8; i < 8; i++)
        {
            if (i != position.x && i != position.y)
            {
                moves.Add(new Vector2Int(position.x, i));
                moves.Add(new Vector2Int(i, position.y));
            }
        }

        return moves;
    }
    public List<Vector2Int> killingPatern = new List<Vector2Int>() { };
    private bool IsOutsideOfBorder(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y < 8 && position.y >= 0;
    }
    public void PrintMoves()
    {
        foreach (Vector2Int move in PosibleMoves())
        {
            Debug.Log(move);
        }
    }
}
