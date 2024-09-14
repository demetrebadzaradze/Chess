using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverllayControler : MonoBehaviour
{
    // private static OverllayControler 
    public GameObject posibleMoveOverllay;
    private float xOffset = 0.5f;
    private float yOffset = 0.5f;
    public GameObject posibleKillOverllay;
    public List<GameObject> moveOverllays = new List<GameObject>(); 
    public void DrawMoveOverllay(List<Vector2Int> positions)
    {   
        foreach (Vector2Int pos in positions)
        {
            GameObject mo = Instantiate(posibleMoveOverllay,new Vector3(pos.x + xOffset, pos.y + yOffset, -3),Quaternion.identity);
            moveOverllays.Add(mo);
        }
    }
    public void EraceAllOverllays()
    {
        foreach (GameObject obj in moveOverllays)
        {
            Object.Destroy(obj);
        }
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
}
