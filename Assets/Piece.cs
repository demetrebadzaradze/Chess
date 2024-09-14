using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Piece //: MonoBehaviour
{
    // here we need to add sqere class objs to determine kill and no more piece paces

    public GameObject posibleKillOverlay;
    public GameObject posibleMoveOverlay;
    private OverllayControler overllayControler;
    public PieceName Name;
    public PieceColor Color;
    public Vector2Int position;
    public bool overllayIsDisplayed = false;

    public Piece(Vector2Int pos, PieceColor color, PieceName name)
    {
        position = pos;
        Color = color;
        Name = name;
        overllayControler = GameObject.FindObjectOfType<OverllayControler>();      //new OverllayControler();
    }
    public virtual bool IsAValidMove(Vector2Int movePos)
    {
        return false;
    }
    public virtual List<Vector2Int> PosibleMoves()
    {
        return new List<Vector2Int> { };
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
        if (GameManager.squeres[pos.x, pos.y].ocupied)
        {
            return true;
        }
        return false;
    }
    void Start()
    {
        //  posibleMoveOverlay = Resources.Load("PosbleMoveOverlay") as GameObject;
    }
    public void DrawPosibleMoves()
    {
        if (overllayControler.moveOverllays.Count < PosibleMoves().Count)
        {
            overllayControler.DrawMoveOverllay(PosibleMoves());
            overllayIsDisplayed = true;
        }
    }
    public void DestroyMoveOverlays()
    {
        overllayControler.EraceAllOverllays();
        overllayIsDisplayed = false;
    }
}
