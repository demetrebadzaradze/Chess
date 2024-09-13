using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverllayControler : MonoBehaviour
{
    public GameObject posibleMoveOverllay;
    public GameObject posibleKillOverllay;
    public void DrawMoveOverllay(List<Vector2Int> positions)
    {   
        foreach (Vector2Int pos in positions)
        {
            Instantiate(posibleMoveOverllay,new Vector3(pos.x, pos.y, -3),Quaternion.identity);
        }
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
}
