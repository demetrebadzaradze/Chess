using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private GameObject nearestSquare = null;
    private GameObject selectedObject = null;
    private Piece piece;
    private Squere tile;
    // private Pieces piece;
    // private ChessManager chessManager;
    private Vector2Int startPos; 
    void Start()
    {
        FindNearesSquere(out startPos);

        piece = new Pawn        //rhis is monobehavior class and may be faultty without instantience
        (
            new Vector2Int(
                (int)Math.Floor(this.gameObject.transform.position.x),
                (int)Math.Floor(this.gameObject.transform.position.y)
                ),
            GameManager.GetPieceColor(gameObject), 
            GameManager.GetPieceName(gameObject));
        
        // piece = GetComponent<Pieces>();
        // chessManager = ChessManager.Instance;    //FindObjectOfType<ChessManager>();  // Assumes there's only one ChessManager in the scene
    }
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -3f);
        }
    }

    private void OnMouseDown()
    {
        // Debug.Log(Input.GetMouseButtonDown(1) == true);
        // if (Input.GetMouseButtonDown(1))
        // {
        //     Debug.Log("destried overlayes or no???");
        //     piece.DestroyMoveOverlays();
        // }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            selectedObject = this.gameObject;

            isBeingHeld = true;

            DrawOrEracePosibleOverllays();

            // piece.DrawPosibleMoves();
        }
    }
    private void OnMouseUp()
    {
        Vector2Int x;
        Vector2Int newPos;
        isBeingHeld = false;
        FindNearesSquere(out newPos);
        FindNearesSquere(out x);

//  i think any kinde of invalid movemant will show the posible moves that would be better
        // Debug.Log(" name is " + piece.Name + " ____ " + " and position is " + piece.position + " ________ " + "x = " + x + " ____ " + " newPos = " + newPos + " ____ " + piece.IsAValidTurn());

        // if (newPos == x && piece.IsAValidTurn())
        // {
        //     Debug.Log("uuuummmmmm is there anyone here");
        // }

        if (nearestSquare != null && piece != null)
        {
            if (piece.IsAValidMove(newPos) && piece.IsAValidTurn())
            {
                SnapToSquare(nearestSquare);
                GameManager.EndOfTheTurn(piece.Color);
                GameManager.PrintTheTurn();
                piece.UpdatePosition(newPos);
            }
            else
            {
                SnapToOriginalPosition();
            }
        }
        else
        {
            Debug.Log($"No nearest square found {nearestSquare == null} oorrr piece is not asigned {piece == null} i donow");
            SnapToOriginalPosition();
            piece.DrawPosibleMoves();
        }
    }
    private void FindNearesSquere(out Vector2Int newPos)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePos2D);

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Square"))
            {
                Vector2 newposV2 = collider.gameObject.transform.position;
                nearestSquare = collider.gameObject;
                tile = new Squere(nearestSquare);
                newPos = new Vector2Int((int)Math.Floor(newposV2.x), (int)Math.Floor(newposV2.y));
                return;
            }
        }

        newPos = new Vector2Int(-1, -1);            //this looks faluty
        nearestSquare = null;
    }
    private void SnapToSquare(GameObject square)
    {
        transform.position = new Vector3(square.transform.position.x, square.transform.position.y, -2f);
    }
    private void SnapToOriginalPosition()
    {
        Vector2 currentPos = piece.position;
        if (currentPos != new Vector2Int(-1, -1))
        {
            selectedObject = this.gameObject;
            selectedObject.transform.position = new Vector3(currentPos.x + 0.5f, currentPos.y + 0.5f, -2f);
        }
        else
        {
            // Debug.LogError("Piece position is not valid!");
            Debug.LogError("curent position of that piece is (-1, -1)");
        }
    }
    private void DrawOrEracePosibleOverllays()
    {
        if (piece.overllayIsDisplayed)
        {
            piece.DestroyMoveOverlays();
            
        }
        else
        {        
            piece.DrawPosibleMoves();
        }
    }
}




/*
public class cMovement : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private Pieces piece;

    private void Start()
    {
        piece = GetComponent<Pieces>();
    }

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -3f);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        SnapToOriginalPosition();
    }

    private void SnapToOriginalPosition()
    {
        Vector2Int currentPos = GameSetupManager.Instance.GetBoardPosition(this.gameObject);
        if (currentPos != new Vector2Int(-1, -1))
        {
            transform.position = GameSetupManager.Instance.boardSquares[currentPos.x, currentPos.y].transform.position;
        }
        else
        {
            Debug.LogError("Piece position is not valid!");
        }
    }
}

}
*/