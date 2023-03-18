using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAI : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject starPrefab;
    public float starDropChance = 0.5f; // Chance of dropping a star at each waypoint
    public float timeInterval = 2f; // Time interval for dropping stars
    private int currWaypoint = -1;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float timeSinceLastDrop = 0f;
    public int maxStarInTheGame = 5;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeSinceLastDrop >= timeInterval)
        {
            DropStarIfCollidingWithTag("path");
            timeSinceLastDrop = Time.time;
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance + 0.8 && !navMeshAgent.pathPending)
        {
            SetNextWaypoint();            
        }
        // float speed = navMeshAgent.speed;
        // animator.SetBool("isRunning", speed > 0f);
    }

    void SetNextWaypoint()
    {
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
    }

    void DropStarIfCollidingWithTag(string tag)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        int starCount = GameObject.FindGameObjectsWithTag("Star").Length;
        if (starCount >= maxStarInTheGame) return;
        foreach (Collider collider in colliders)
        {
            if (collider.tag == tag)
            {
                Vector3 starPosition = collider.transform.position;
                starPosition.y += 1.0f; // add 1 unit to Y-coordinate
                Instantiate(starPrefab, starPosition, Quaternion.identity);
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}