using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiecesSetup : MonoBehaviour
{
    public GameObject Blackking;
    public GameObject BlackPawn;
    public GameObject BlackBishop;
    public GameObject BlackRook;
    public GameObject BlackKnigh;
    public GameObject BlackQeen;
    public GameObject Whiteking;
    public GameObject WhitePawn;
    public GameObject WhiteBishop;
    public GameObject WhiteRook;
    public GameObject WhiteKnigh;
    public GameObject WhiteQeen;
    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < ChessManager.PiecePosition.GetLength(0); i++)
        {
            for (int j = 0; j < ChessManager.PiecePosition.GetLength(1); j++)
            {
                char color = ChessManager.PiecePosition[i, j][0];
                switch (ChessManager.PiecePosition[i, j][1])
                {
                    case 'P':
                        ChouseColour(BlackPawn, WhitePawn, i, j,color);
                        break;
                    case 'B':
                        ChouseColour(BlackBishop, WhiteBishop, i, j,color);
                        break;
                    case 'N':
                        ChouseColour(BlackKnigh, WhiteKnigh, i, j,color);
                        break;
                    case 'R':
                        ChouseColour(BlackRook, WhiteRook, i, j,color);
                        break;
                    case 'k':
                        ChouseColour(Blackking, Whiteking, i, j,color);
                        break;
                    case 'Q':
                        ChouseColour(BlackQeen, WhiteQeen, i, j,color);
                        break;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void ChouseColour(GameObject blackPiece, GameObject whitePiece, float x, float y, char colour)
    {
        if (colour == 'B')
        {
            Instantiate(blackPiece, new Vector3(y + 0.5f, x + 0.5f, -2f), transform.rotation);
        }
        else if (colour == 'W')
        {
            Instantiate(whitePiece, new Vector3(y + 0.5f, x + 0.5f, -2f), transform.rotation);
        }
    }
}
