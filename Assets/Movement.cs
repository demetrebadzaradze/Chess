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
    // private Pieces piece;
    // private ChessManager chessManager;

    void Start()
    {
        piece = new Pawn(new Vector2Int(0,1),PieceColor.White,PieceName.Pawn);
        // piece = GetComponent<Pieces>();
        // chessManager = ChessManager.Instance;    //FindObjectOfType<ChessManager>();  // Assumes there's only one ChessManager in the scene
    }


    // Update is called once per frame
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

            selectedObject = this.gameObject;

            isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        Vector2Int newPos;
        isBeingHeld = false;
        FindNearesSquere(out newPos);

        if (nearestSquare != null && piece != null/*&& piece != null*/)
        {
            if (piece.IsAValidMove(newPos))
            {
                piece.position = newPos;
            }
            else
            {
                SnapToOriginalPosition();
            }
            // Vector2Int currentPos = chessManager.GetBoardPosition(this.gameObject);
            // Vector2Int newPos = chessManager.GetBoardPosition(nearestSquare);

            // if (chessManager.IsValidMove(currentPos, newPos, piece))
            // {
                // Debug.Log("Snapping to square: " + nearestSquare.name);
                // SnapToSquare(nearestSquare);
            // }
            // else
            // {
                // Debug.Log("Invalid move.");
                // SnapToOriginalPosition();
            // }
        }
        else
        {
            Debug.Log("No nearest square found oorrr piece is not asigned");
            SnapToOriginalPosition();
        }

        if (nearestSquare != null)
        {
            SnapToSquare(nearestSquare);
        }
        else
        {
            Debug.Log(selectedObject.name);
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
                newPos = new Vector2Int((int)Math.Floor(newposV2.x),(int)Math.Floor(newposV2.y));
                Debug.Log("new position is " + newPos);
                return;
            }
        }

        newPos = new Vector2Int(-1,-1);
        nearestSquare = null;
    }
    private void SnapToSquare(GameObject square)
    {
        transform.position = new Vector3(square.transform.position.x, square.transform.position.y, -2f);
    }
    private void SnapToOriginalPosition()
    {
        Vector2Int currentPos = piece.position;
        if (currentPos != new Vector2Int(-1, -1))
        {
            transform.position = new Vector3(currentPos.x, currentPos.y, -2f);
        }
        else
        {
            // Debug.LogError("Piece position is not valid!");
            Debug.LogError("curent position of that piece is (-1, -1)");
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