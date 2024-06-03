using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;

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
}

