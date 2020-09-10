using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored=false;
    public Waypoint exploredFrom;
    public bool isPlaceable=true;
    Vector2Int gridPos;
    
	// Use this for initialization
	void Start () {

	}
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

	// Update is called once per frame
	void Update () {

	}
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print(gameObject.name+" tower is not placeable");
            }
            
        }
    }
}