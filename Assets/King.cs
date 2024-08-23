using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Pieces
{
    public override void Initialize(PieceName pieceType, PieceColor pieceColor, Vector2Int startPos)
    {
        base.Initialize(pieceType, pieceColor, startPos);
    }

    public override List<Vector2Int> GetPossibleMoves(Vector2Int currentPos)
    {
        List<Vector2Int> possibleMoves = new List<Vector2Int>();

        Vector2Int[] moveDirections = {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1),
            new Vector2Int(1, 1),
            new Vector2Int(1, -1),
            new Vector2Int(-1, 1),
            new Vector2Int(-1, -1)
        };

        foreach (Vector2Int direction in moveDirections)
        {
            Vector2Int newPos = currentPos + direction;
            if (IsValidMove(newPos))
            {
                possibleMoves.Add(newPos);
            }
        }

        return possibleMoves;
    }

    private bool IsValidMove(Vector2Int pos)
    {
        return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
    }
}