using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Toolbox;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour
{

    //AgainMove
    Transform endPos;
    private List<Vector3> wayPoints;
    public float attackRange;
    //*
    GameObject tileMap;
    GameObject linePath;

    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
        tileMap = GameObject.Find("Walls");
        linePath = GameObject.Find("Line");

    }

    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.gameObject.layer != 6)
        {
            if (collision.transform.gameObject.layer == 7 || collision.transform.gameObject.layer == 6)
            {
                //MoveforNewPos(transform.gameObject);
            }
        }
        
    }

    void MoveforNewPos(GameObject obj )
    {
        endPos = transform;
        var objPos = transform.position;
        objPos.z = 0;
        objPos.y = objPos.y + UnityEngine.Random.Range(-0.1f, 0.1f);
        objPos.x = objPos.x + UnityEngine.Random.Range(-0.1f, 0.1f);
        endPos.position = objPos;
        UnitSelections selectionManager2 = FindObjectOfType<UnitSelections>();
        if (selectionManager2 != null)
        {
            wayPoints = AStar.FindPathClosest(tileMap.GetComponent<Tilemap>(), obj.transform.position, endPos.position);
        }
        else
        {
            Debug.LogWarning("UnitSelectionManager not found!");
        }
        if (wayPoints != null)
        {
            linePath.GetComponent<LineRenderer>().positionCount = wayPoints.Count;
            linePath.GetComponent<LineRenderer>().SetPositions(wayPoints.ToArray());
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

