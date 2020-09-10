using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField]int towerLimit=4;
    [SerializeField]Tower towerPrefab;
    int towerN;
    Queue<Tower> queueTower=new Queue<Tower>();
    [SerializeField]Transform newTransformParent;
    public void AddTower(Waypoint baseWaypoint)
    {
        towerN=queueTower.Count;
        if(towerN>=towerLimit)
        {
            removeExistingLastTower(baseWaypoint);
        }
        else
        {
            placeTower(baseWaypoint);
        }

    }

    private void removeExistingLastTower(Waypoint newBaseWaypoint)
    {
        var oldTower=queueTower.Dequeue();
        oldTower.baseWaypoint.isPlaceable=true;
        oldTower.baseWaypoint=newBaseWaypoint;
        oldTower.transform.position=newBaseWaypoint.transform.position;

        queueTower.Enqueue(oldTower);
    }

    private void placeTower(Waypoint baseWaypoint)
    {
        var newTower=Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent=newTransformParent;
        baseWaypoint.isPlaceable = false;
 
        newTower.baseWaypoint=baseWaypoint;
        baseWaypoint.isPlaceable=false;

        queueTower.Enqueue(newTower);
    }
}
