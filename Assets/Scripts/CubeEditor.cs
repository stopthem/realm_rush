using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    TextMesh textMesh;

    private void Awake() {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        snapGrid();

        labelTextEdit();
    }

    private void snapGrid()
    {
        int gridSize=waypoint.GetGridSize();
        transform.position = new Vector3(
        waypoint.GetGridPos().x*gridSize,
        0f,
        waypoint.GetGridPos().y*gridSize);
    }

    private void labelTextEdit()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelTextEdit = waypoint.GetGridPos().x+ "," + waypoint.GetGridPos().y;
        textMesh.text = labelTextEdit;
        gameObject.name = "cube" + " " + labelTextEdit;
    }
    

}
