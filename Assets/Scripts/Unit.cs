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
    private NavMeshAgent agent;

    //AgainMove
    Transform endPos;
    Transform startPos;
    //private Selection selectionManager;
    public Tilemap tilemap;
    public LineRenderer linePath;
    private List<Vector3> wayPoints;
    //*

    public class Character
    {
        public int Health { get; set; }
        public int Attack { get; set; }

        public Character(int health, int attack)
        {
            Health = health;
            Attack = attack;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    public void Move(Vector3 konum)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(konum);
            }
            else
            {
                Debug.LogError("NavMeshAgent is not active!");
            }
        }
        else
        {
            Debug.LogError("Agent is not on the NavMesh!");
        }
    }
    public void AgentBelirle()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer==7|| collision.transform.gameObject.layer == 6) 
        { 
            MoveForGlory(transform.gameObject); 
        }
    }

    void MoveForGlory(GameObject obj )
    {
        endPos = transform;
        var mousePos = transform.position;
        mousePos.z = 0;
        mousePos.y = mousePos.y + UnityEngine.Random.Range(-0.5f, 0.5f);
        mousePos.x = mousePos.x + UnityEngine.Random.Range(-0.5f, 0.5f);
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

