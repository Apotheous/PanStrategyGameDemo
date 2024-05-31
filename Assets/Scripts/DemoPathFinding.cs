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
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            endPos.position = mousePos;
            wayPoints = AStar.FindPathClosest(tilemap,startPos.position,endPos.position);
            if (wayPoints != null )
            {
                
                linePath.positionCount = wayPoints.Count;
                linePath.SetPositions(wayPoints.ToArray());
                startPos.DOPath(wayPoints.ToArray(), 1f,PathType.CatmullRom);
                //for (int i = 0; i < wayPoints.Count; i++)
                //{
                //    Debug.Log("Point : " + i + "Have position :" + wayPoints[i]);
                //}
            }
        }
    }
}
