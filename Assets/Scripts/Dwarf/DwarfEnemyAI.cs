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


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        isDestroyingObject = true;
        animator.SetBool("isDestroying", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("isDestroying", false);
        Destroy(obj);
        isDestroyingObject = false;
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
}
