using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Piece : MonoBehaviour
{
    // here we need to add sqere class objs to determine kill and no more piece paces

    public GameObject posibleKillOverlay;
    public GameObject posibleMoveOverlay;
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
    public virtual List<Vector2Int> PosibleMoves()
    {
        return new List<Vector2Int>{};
    }
    public bool IsAValidTurn()
    {
        if (Color == GameManager.Turn)
        {
            return true;
        }
        return false;
    }
    public void UpdatePosition(Vector2Int newPosition)
    {
        position = newPosition;   
    }
    protected bool IsSquereOcupied(Vector2Int pos)
    {
        if(GameManager.squeres[pos.x,pos.y].ocupied)
        {
            return true;
        }
        return false;
    }  
    public void DrawPosibleMoves()
    {
        Debug.Log("drawing positions");
        foreach (Vector2Int move in PosibleMoves())
        {
            Instantiate(posibleMoveOverlay,new Vector3(move.x,move.x,-1), transform.rotation);
        }
    }
}
