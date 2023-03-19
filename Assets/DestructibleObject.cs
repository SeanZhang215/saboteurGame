using System.Collections;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public Animator animator;
    public string destroyAnimationName = "Destroy";
    public float destroyAnimationLength = 3.0f;
    public float destroyDelay = 0.1f;
    public Vector3 rotationSpeed = new Vector3(0, 45, 0); // Rotation speed in degrees per second

    private static Transform character;
    private bool isDestroyed = false;
    private bool isRotating = false;

    void Start()
    {
        if (character == null)
        {
            character = FindObjectOfType<CharacterController>().transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDestroyed && Input.GetMouseButtonDown(0))
            {
                isDestroyed = true;
                StartCoroutine(PlayDestroyAnimation());
            }

            if (!isRotating)
            {
                isRotating = true;
                RotateObject();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = false;
        }
    }

    private void RotateObject()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    IEnumerator PlayDestroyAnimation()
    {
        if (animator)
        {
            animator.SetTrigger(destroyAnimationName);
            animator.SetBool("isDestroying", true);
            yield return new WaitForSeconds(destroyDelay);
            yield return new WaitForSeconds(destroyAnimationLength);
            animator.SetBool("isDestroying", false);
        }
        Destroy(gameObject);
    }

    void Update()
    {
        if (isRotating)
        {
            RotateObject();
        }
    }
}
