using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public Pawn(Vector2Int pos, PieceColor color, PieceName name) : base(pos, color, name)
    {
    }

    public override bool IsAValidMove(Vector2Int newPos)
    {
        foreach (Vector2Int posibleMove in PosibleMoves())
        {
            if (newPos == position + posibleMove)
            {
                Debug.LogWarning(newPos + "=" + position + "+" + posibleMove);
                Debug.Log("VALID move");
                return true;
            }
        }
        Debug.LogError("NOT a valid move" + position);
        return false;
    }
    private List<Vector2Int> PosibleMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>()
        {
            new Vector2Int(0,1),
            new Vector2Int(0, 2),
        };
        return moves;
    }
    private bool IsOutsideOfBorder(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y < 8 && position.y >= 0;
    }
}
