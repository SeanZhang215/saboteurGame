using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DwarfEnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private GameObject currentStar;
    private bool isDestroyingObject = false;
    private int starsDestroyed = 0;
    public GameObject bridgePrefab; 
    public int numOfStarNeededForBridge = 5;
    public GameObject[] destinations;

    private GameObject nearestDestination;
    private float minDistance = float.MaxValue;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(CheckIfCanGoToDestination()){
            return;
        }

        if (currentStar == null)
        {
            FindNearestStar();
        }
        else if (!isDestroyingObject && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            StartCoroutine(DestroyAfterDelay(currentStar, 10f));
            currentStar = null;
            FindNearestStar();
        }

        float speed = navMeshAgent.speed;
        if (currentStar == null)
        {
            speed = 0f;
        }
        animator.SetBool("isWalking", speed > 0f);

        if (starsDestroyed > 0 && starsDestroyed % numOfStarNeededForBridge == 0)
        {
            CreateBridge();
            starsDestroyed = 0;
        }
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        isDestroyingObject = true;
        animator.SetBool("isDestroying", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("isDestroying", false);
        Destroy(obj);
        isDestroyingObject = false;

        starsDestroyed++;
    }

    void CreateBridge()
    {
        float randomAngle = Random.Range(-180f, 180f);
        float randomDistance = Random.Range(0f, 3f); // choose a random distance between 5 to 10 units
        Vector3 bridgePosition = transform.position + Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * 3.0f;
        Instantiate(bridgePrefab, bridgePosition, Quaternion.Euler(0f, randomAngle, 0f));
    }


    void FindNearestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        if (stars.Length > 0)
        {
            GameObject nearestStar = stars[0];
            float minDistance = Vector3.Distance(transform.position, nearestStar.transform.position);

            for (int i = 1; i < stars.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, stars[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestStar = stars[i];
                }
            }

            currentStar = nearestStar;
            navMeshAgent.SetDestination(currentStar.transform.position);
        }
    }

    bool CheckIfCanGoToDestination()
    {
        foreach (GameObject destination in destinations)
        {
            NavMeshPath path = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, destination.transform.position, NavMesh.AllAreas, path))
            {
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    nearestDestination = destination;
                    navMeshAgent.SetDestination(nearestDestination.transform.position);
                    return true;
                }
            }
        }
        return false;
    }

}
