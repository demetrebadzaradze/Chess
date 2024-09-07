using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// here we need to ad sqere class objs to determine kild and no more piece paces
    public enum PieceName { King, Queen, Bishop, Knight, Rook, Pawn }
    public enum ShortPieceName { K, Q, R, B, N, }
    public enum PieceColor { White, Black }

public abstract class Pieces : MonoBehaviour
{

    public ShortPieceName shortName;
    public PieceName Name { get; private set; }
    public PieceColor playerCollor { get; private set; }
    public int playerNuber;
    public Vector2Int position { get; private set; }

    public virtual void Initialize(PieceName pieceType, PieceColor pieceColor, Vector2Int startPos)
    {
        Name = pieceType;
        playerCollor = pieceColor;
        position = startPos;
        transform.position = ChessManager.Instance.boardTiles[startPos.x, startPos.y].transform.position;
    }
    public abstract List<Vector2Int> GetPossibleMoves(Vector2Int currentPos);

    public Vector2Int[] PosibleMoves(Vector2Int curentPosition)
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (curentPosition != new Vector2Int(i, j))
                {
                    moves.Add(new Vector2Int(i, j));
                }
            }
        }
        return moves.ToArray();
    }

    internal void Initialize(ShortPieceName pieceType, PieceColor pieceColor, Vector2Int startPos)
    {
        throw new NotImplementedException();
    }

    // public void Move(Vector2Int newPosition)
    // {
    //     if (GameSetupManager.Instance.IsValidMove(CurrentPosition, newPosition, this))
    //     {
    //         CurrentPosition = newPosition;
    //         transform.position = GameSetupManager.Instance.boardSquares[newPosition.x, newPosition.y].transform.position;
    //     }
    // }
}
