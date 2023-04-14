using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Variables
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    public Animator animator;

    private Rigidbody rb;
    private Vector3 movement;
    private float horizontal;
    private float vertical;

    public float jumpForce = 7.0f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;

    public bool isGrounded;
    private float jumpInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
{
    // Get input for movement
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
    jumpInput = Input.GetAxis("Jump");

    // Check if the character is grounded
    //isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayer, QueryTriggerInteraction.Ignore);
    isGrounded = true;
    // Create movement vector
    movement = transform.TransformDirection(new Vector3(horizontal, 0.0f, vertical));

    // Animate character based on movement
    if (movement != Vector3.zero)
    {
        animator.SetBool("isWalking", true);
        //animator.SetBool("isDestroying", true);
    }
    else
    {
        animator.SetBool("isWalking", false);
        //animator.SetBool("isDestroying", false);
    }

    
}

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
         MoveCharacter();

    // Jump character
    JumpCharacter();
    }

void MoveCharacter()
{
    // Move character
    rb.MovePosition(transform.position + transform.forward * vertical * speed * Time.deltaTime);

    // Rotate character
    if (horizontal != 0)
    {
        float targetRotationAngle = horizontal * rotationSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, targetRotationAngle, 0);
        Quaternion newRotation = rb.rotation * targetRotation;
        rb.MoveRotation(newRotation);
    }
}

void JumpCharacter()
{
    if (isGrounded && jumpInput > 0)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
    GameObject TEMP;
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Star")
        {
            if(Input.GetKeyDown(KeyCode.F))
            { 
                TEMP = other.gameObject;
                animator.SetTrigger("Attack"); 
                Invoke("shuijinglost",2.5f);
            }
        }
    }

    public void shuijinglost()
    {    
         GameObject.Destroy(TEMP);
    }
}
