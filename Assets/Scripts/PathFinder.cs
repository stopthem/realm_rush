using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint,endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid=new Dictionary<Vector2Int, Waypoint>();
    bool isRunning=true;
    Waypoint searchCenter;
    Queue<Waypoint> queue=new Queue<Waypoint>();
    List<Waypoint>path=new List<Waypoint>();
  
    Vector2Int[]directions={
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };
    public List<Waypoint> GetPath(){

        if(path.Count==0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceable=false;
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous !=startWaypoint)
        {
            path.Add(previous);
            previous.isPlaceable=false;
            previous=previous.exploredFrom;
            
        }
        path.Add(startWaypoint);
        startWaypoint.isPlaceable=false;
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count>0 && isRunning)
        {
            searchCenter=queue.Dequeue();
            HaltIfEndEqualsStart();
            ExploreNeighbours();
            searchCenter.isExplored=true;
        }
    }

    private void HaltIfEndEqualsStart()
    {
        if(searchCenter==endWaypoint){
            isRunning=false;
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning){return;}
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates=searchCenter.GetGridPos()+direction;
            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
               
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom=searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints=FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos=waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos)){
                Debug.LogWarning("overlapping block"+waypoint);
            }
            else{
                grid.Add(gridPos,waypoint);
            }
            
            
        }
                
    }
    void Update()
    {
        
    }
}
