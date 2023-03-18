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

    // Reference to the bridge prefab to be instantiated

    private GameObject nearestDestination;
    private float minDistance = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        if (currentStar == null){
            speed = 0f;
        }
        animator.SetBool("isWalking", speed > 0f);

        // Check if starsDestroyed is a multiple of 5, and create a bridge if it is
        if (starsDestroyed % numOfStarNeededForBridge == 0 && starsDestroyed > 0)
        {
            float randomAngle = Random.Range(-180f, 180f);
            Instantiate(bridgePrefab, transform.position, Quaternion.Euler(0f, randomAngle, 0f));
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

        // Increment the starsDestroyed variable by 1
        starsDestroyed++;
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

    bool CheckIfCanGoToDestination(){
        nearestDestination = null;
        minDistance = float.MaxValue;
        // Check if any of the destinations are reachable
        foreach (GameObject destination in destinations)
        {
            NavMeshPath path = new NavMeshPath();
            if (navMeshAgent.CalculatePath(destination.transform.position, path))
            {
                float distance = Vector3.Distance(transform.position, destination.transform.position);
                if (distance < minDistance)
                {
                    nearestDestination = destination;
                    minDistance = distance;
                }
            }
        }
        if(nearestDestination != null){
            navMeshAgent.SetDestination(nearestDestination.transform.position);
            animator.SetBool("isWalking", true);
            return true;
        }
        return false;
    }
}
