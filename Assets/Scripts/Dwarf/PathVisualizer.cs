using UnityEngine;
using UnityEngine.AI;

public class PathVisualizer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        if (navMeshAgent != null && navMeshAgent.hasPath)
        {
            Gizmos.color = Color.blue;
            Vector3 previousCorner = transform.position;

            foreach (Vector3 corner in navMeshAgent.path.corners)
            {
                Gizmos.DrawLine(previousCorner, corner);
                previousCorner = corner;
            }
        }
    }
}
