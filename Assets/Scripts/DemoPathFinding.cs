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
            for (int i = 0; i < selectedUnits.Count; i++) {
                Debug.Log("SelectedObjcetCount Start"+i);
                foreach (GameObject unit in selectedUnits) { MoveForGlory(unit);Debug.Log("SelectedObjcetCount Finish"); }
                
            }
        }
    }
    void MoveForGlory(GameObject obj)
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        endPos.position = mousePos;
        DebugText.text =mousePos.ToString();
        //wayPoints = AStar.FindPathClosest(tilemap, selectionManager.GetSelectedObject().transform.position,endPos.position);
        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        if (selectionManager2 != null)
        {
            Debug.Log("SelectedObjcetCount Step1: " + obj.name);
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
                Debug.Log("SelectedObjcetCount Step2: " + obj.name);
                obj.transform.DOPath(wayPoints.ToArray(), 1f, PathType.Linear);
            }
            else
            {
                Debug.LogWarning("UnitSelectionManager not found!");
            }
        }
    }
}
