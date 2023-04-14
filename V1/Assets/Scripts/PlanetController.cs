using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Transform orbitCenter;
    public float orbitSpeed = 10f;
    public float rotationSpeed = 10f;
    public Vector3 orbitAxis = Vector3.up;
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        Orbit();
        Rotate();
    }

    private void Orbit()
    {
        if (orbitCenter != null)
        {
            transform.RotateAround(orbitCenter.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
