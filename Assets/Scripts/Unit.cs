using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;

    public float can;
    public float saldiri;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

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

    //public void Move(Vector2 konum)
    //{
    //    agent.SetDestination(konum);
    //}

    public void AgentBelirle()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}

