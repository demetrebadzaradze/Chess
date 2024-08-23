using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public static ChessManager Instance { get; private set; }
    public GameObject[,] boardTiles = new GameObject[8, 8];
    public Pieces[,] chessPieces = new Pieces[8, 8];


    public GameObject whiteKingPrefab;
    public GameObject blackKingPrefab;
    // Add references for all other piece prefabs here

    private Dictionary<(PieceName, PieceColor), GameObject> piecePrefabs;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps this object alive across scenes
            InstanceBoardTiles();
            InitializePiecePrefabs();
            // InstantiatePiece(PieceName.King, PieceColor.White, Vector2Int.zero);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }


    public static int[,] tilePosition = new int[8, 8]{
        {0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0},
        {0,1,0,1,0,1,0,1},
        {1,0,1,0,1,0,1,0},
    };

    public static string[,] PiecePosition = new string[8, 8]{
        {"WR","WN","WB","WQ","Wk","WB","WN","WR"},
        {"WP","WP","WP","WP","WP","WP","WP","WP",},
        {"OO","OO","OO","OO","OO","OO","OO","OO"},
        {"OO","OO","OO","OO","OO","OO","OO","OO"},
        {"OO","OO","OO","OO","OO","OO","OO","OO"},
        {"OO","OO","OO","OO","OO","OO","OO","OO"},
        {"BP","BP","BP" ,"BP","BP","BP","BP","BP",},
        {"BR","BN","BB","BQ","Bk","BB","BN","BR"},
    };
    // public 

    private void InitializePiecePrefabs()
    {
        piecePrefabs = new Dictionary<(PieceName, PieceColor), GameObject>
        {
            {(PieceName.King, PieceColor.White), whiteKingPrefab},
            {(PieceName.King, PieceColor.Black), blackKingPrefab}
            // Add entries for all other piece prefabs here
        };
    }
    public void InstanceBoardTiles()
    {
        for (int i = 0; i < boardTiles.GetLength(0); i++)
        {
            for (int j = 0; j < boardTiles.GetLength(1); j++)
            {
                boardTiles[i, j] = GameObject.Find(i + j + "Tile");
            }
        }
    }
    // void InstantiatePiece(PieceName type, PieceColor color, Vector2Int position)
    // {
    //     if (piecePrefabs.TryGetValue((type, color), out GameObject prefab))
    //     {
    //         GameObject pieceObject = Instantiate(prefab);
    //         Pieces piece = pieceObject.GetComponent<Pieces>();
    //         piece.Initialize(type, color, position);
    //         pieceObject.transform.position = boardTiles[position.x, position.y].transform.position;
    //         chessPieces[position.x, position.y] = piece;
    //     }
    //     else
    //     {
    //         Debug.LogError($"Prefab for {color} {type} not found!");
    //     }
    // }

    public Vector2Int GetBoardPosition(GameObject obj)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (boardTiles[x, y] == obj)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);  // Return an invalid position if not found
    }
    public bool IsValidMove(Vector2Int currentPos, Vector2Int newPos, Pieces piece)
    {
        List<Vector2Int> moves = piece.GetPossibleMoves(currentPos);

        foreach (Vector2Int move in moves)
        {
            if (move == currentPos)
            {
                return true;
            }
        }
        return false;
    }
}


/*
public class GameSetupManager : MonoBehaviour
{
    public static GameSetupManager Instance { get; private set; }

    public GameObject[,] boardSquares = new GameObject[8, 8];  // Assuming an 8x8 board
    public ChessPiece[,] chessPieces = new ChessPiece[8, 8];

    public GameObject kingPrefab; // Assign your King prefab in the Unity inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keeps this object alive across scenes
            InitializeBoard();
            InitializePieces();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    void InitializeBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                boardSquares[x, y] = GameObject.Find("Square" + x + y);
            }
        }
    }

    void InitializePieces()
    {
        // Example for initializing Kings. Repeat for other pieces.
        InstantiatePiece(PieceType.King, PieceColor.White, new Vector2Int(4, 0));
        InstantiatePiece(PieceType.King, PieceColor.Black, new Vector2Int(4, 7));

        // Initialize other pieces similarly
    }

    void InstantiatePiece(PieceType type, PieceColor color, Vector2Int position)
    {
        GameObject pieceObject = Instantiate(kingPrefab); // Use appropriate prefab for each piece type
        ChessPiece piece = pieceObject.GetComponent<ChessPiece>();

        switch (type)
        {
            case PieceType.King:
                piece = pieceObject.AddComponent<King>();
                break;
            // Add cases for other piece types
        }

        piece.Initialize(type, color, position);
        pieceObject.transform.position = boardSquares[position.x, position.y].transform.position;
        chessPieces[position.x, position.y] = piece;
    }

    public Vector2Int GetBoardPosition(GameObject obj)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (boardSquares[x, y] == obj)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);  // Return an invalid position if not found
    }

    public void SelectPiece(ChessPiece piece, Vector2Int position)
    {
        // Logic to select a piece and handle its movement
    }

    public bool IsValidMove(Vector2Int currentPos, Vector2Int newPos, ChessPiece piece)
    {
        List<Vector2Int> possibleMoves = piece.GetPossibleMoves(currentPos);

        foreach (Vector2Int move in possibleMoves)
        {
            if (newPos == move)
            {
                return true;
            }
        }

        return false;
    }
}

*/