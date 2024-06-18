using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;


public class DemoPathFinding : MonoBehaviour
{
    public Transform endPos;
    //private Selection selectionManager;
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;
    private void Start()
    {
        wayPoints = new List<Vector3>();
        //selectionManager = FindObjectOfType<Selection>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
            List<GameObject> selectedUnits = selectionManager2.GetUnitsSelected();
            foreach (GameObject unit in selectedUnits) 
            {
                if (unit.transform.gameObject.layer == 7 &&unit.tag=="Player")
                {
                    MoveForGlory(unit);
                }

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
            wayPoints = AStar.FindPathClosest(tilemap, obj.transform.position, endPos.position);
        }
        else
        {
            Debug.LogWarning("UnitSelectionManager not found!");
        }
        if (wayPoints != null)
        {
            linePath.positionCount = wayPoints.Count;
            linePath.SetPositions(wayPoints.ToArray());
            //selectionManager.GetSelectedObject().transform.DOPath(wayPoints.ToArray(), 1f,PathType.Linear);
            if (selectionManager2 != null)
            {
                obj.transform.DOPath(wayPoints.ToArray(), 1f, PathType.Linear);
            }
            else
            {
                Debug.LogWarning("UnitSelectionManager not found!");
            }
        }
    }
}
