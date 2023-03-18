using UnityEngine;
using UnityEditor.AI;
public class NavMeshBaker : MonoBehaviour
{
    public float bakeInterval = 5f; // Interval in seconds between NavMesh bakes

    void Start()
    {
        InvokeRepeating("BakeNavMesh", bakeInterval, bakeInterval);
    }

    void BakeNavMesh()
    {
        NavMeshBuilder.ClearAllNavMeshes();
        NavMeshBuilder.BuildNavMesh();
    }
}
