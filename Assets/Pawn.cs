using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    private int moveCount = 0;
    public Pawn(Vector2Int pos, PieceColor color, PieceName name) : base(pos, color, name)
    {
    }

    public override bool IsAValidMove(Vector2Int newPos)
    {
        foreach (Vector2Int posibleMove in PosibleMoves())
        {
            if (newPos == posibleMove)
            {      
                moveCount++;

                return IsOutsideOfBorder(newPos);       // return true;
            }
        }
        Debug.Log("NOT a valid move" + position);
        return false;
    }
    public override List<Vector2Int> PosibleMoves()
    {
        // Vector2Int posibleMove;
        List<Vector2Int> moves = new List<Vector2Int>();

        if (!IsSquereOcupied(position + MoveBasedOnCoulor(new Vector2Int(0, 1))))
        {
            moves.Add(MoveBasedOnCoulor(new Vector2Int(0, 1) + position));
        }



        if (moveCount == 0)
        {
            if (!IsSquereOcupied(position + MoveBasedOnCoulor(new Vector2Int(0, 2))))
            {
                moves.Add(MoveBasedOnCoulor(new Vector2Int(0, 2) + position ));
            }
        }

        return moves;
    }
    public List<Vector2Int> killingPatern = new List<Vector2Int>()
    {
        new Vector2Int(1,-1),
        new Vector2Int(1,1)
    };
    private bool IsOutsideOfBorder(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y < 8 && position.y >= 0;
    }
    private Vector2Int MoveBasedOnCoulor(Vector2Int move)
    {
        if (Color == PieceColor.White)
        {
            return move;
        }
        else
        {
            return new Vector2Int(move.x, -move.y);
        }
    }

}
