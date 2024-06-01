using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Toolbox;
using DG.Tweening;


public class DemoPathFinding : MonoBehaviour
{
    public Transform endPos;
    public Transform startPos;
    private Selection selectionManager;
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;
    private void Start()
    {
        wayPoints = new List<Vector3>();
        selectionManager = FindObjectOfType<Selection>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            endPos.position = mousePos;
            wayPoints = AStar.FindPathClosest(tilemap, selectionManager.GetSelectedObject().transform.position,endPos.position);
            if (wayPoints != null )
            {
                
                linePath.positionCount = wayPoints.Count;
                linePath.SetPositions(wayPoints.ToArray());
                selectionManager.GetSelectedObject().transform.DOPath(wayPoints.ToArray(), 1f,PathType.Linear);
            }
        }
    }
}
