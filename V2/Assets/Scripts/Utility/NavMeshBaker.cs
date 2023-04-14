using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine that builds the NavMesh every 5 seconds
        StartCoroutine(BuildNavMeshCoroutine());
    }

    IEnumerator BuildNavMeshCoroutine()
    {
        while (true)
        {
            // Build the NavMesh
            navMeshSurface.BuildNavMesh();

            // Wait for 5 seconds before building the NavMesh again
            yield return new WaitForSeconds(5f);
        }
    }
}
