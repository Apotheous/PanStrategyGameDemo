using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;
using DG.Tweening;
using UnityEngine.UI;


public class DemoPathFinding : MonoBehaviour
{
    public Transform endPos;
    public Transform startPos;
    private Selection selectionManager;
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;

    public Text DebugText;
    //bool oneMoveOne =false;
    private void Start()
    {
        wayPoints = new List<Vector3>();
        selectionManager = FindObjectOfType<Selection>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
            List<GameObject> selectedUnits = selectionManager2.GetUnitsSelected();
 
            Debug.Log("PathFinding Start");
            foreach (GameObject unit in selectedUnits) 
            { 
                MoveForGlory(unit);Debug.Log("PathFinding Finish " + unit.name); 
            }
        }
    }
    void MoveForGlory(GameObject obj)
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y = mousePos.y+ Random.Range(-0.75f, 0.75f);
        mousePos.x = mousePos.x+ Random.Range(-0.75f, 0.75f);
        endPos.position = mousePos;

        //wayPoints = AStar.FindPathClosest(tilemap, selectionManager.GetSelectedObject().transform.position,endPos.position);
        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        if (selectionManager2 != null)
        {
            Debug.Log("PathFinding Step1: " + obj.name);
            wayPoints = AStar.FindPathClosest(tilemap, obj.transform.position, endPos.position);
        }
        else
        {
            Debug.LogWarning("UnitSelectionManager not found!");
        }
        //
        if (wayPoints != null)
        {
            linePath.positionCount = wayPoints.Count;
            linePath.SetPositions(wayPoints.ToArray());
            //selectionManager.GetSelectedObject().transform.DOPath(wayPoints.ToArray(), 1f,PathType.Linear);
            if (selectionManager2 != null)
            {
                Debug.Log("PathFinding Step2: " + obj.name);
                obj.transform.DOPath(wayPoints.ToArray(), 1f, PathType.Linear);
            }
            else
            {
                Debug.LogWarning("UnitSelectionManager not found!");
            }
        }
    }
}
