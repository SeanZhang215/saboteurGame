using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DwarfEnemyAI : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currWaypoint = -1;
    private NavMeshAgent navMeshAgent;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            setNextWaypoint();
        }
        float speed = navMeshAgent.speed;
        animator.SetBool("isRunning", speed > 0f);
    }

    void setNextWaypoint()
    {
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
    }
}
