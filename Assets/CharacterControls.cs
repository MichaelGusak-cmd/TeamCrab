using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    Rigidbody rb;
    //Ground Check
    bool isGrounded = false;
    //Constants
    public int jumpForce = 100;
    public int fallForce = 2;
    public int walkSpeed = 200;
    public float RotateSpeed = 200;
    public float jumpTimeout = 0.5f;

    private float jumpedAt = 0f;
    int dashDelay = 0;    
    int dashForce = 25;
    
    //glitch variables
    bool flipGravity = false;
    bool dash = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(-Vector3.up * fallForce, ForceMode.Impulse); //gravity
        if (Input.GetKey(KeyCode.Space) && isGrounded && Time.time > jumpedAt+jumpTimeout) { //jump
            jumpedAt = Time.time;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }       
         
        if (Input.GetAxisRaw("Horizontal") < 0) { //rotate left
            transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);
        } else if ( Input.GetAxisRaw("Horizontal") > 0) {
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
        }

        if (!isGrounded) {
            rb.velocity = rb.velocity + transform.right * walkSpeed * Time.deltaTime;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, walkSpeed);
       }
    }

    private void OnCollisionStay(Collision collision) {
        // Check if the ball's rigidbody is colliding with the ground
        if (!isGrounded){
                    if (collision.gameObject.CompareTag("Ground") &&
            Physics.Raycast(transform.position, Vector3.down, 2f, 1 << LayerMask.NameToLayer("Ground")));
            Debug.DrawRay(transform.position, Vector3.down, Color.red, 2f, false );
            //DrawRay(Vector3 start, Vector3 dir, Color color = Color.white, float duration = 0.0f, bool depthTest = true);
        {
            // Set the isGrounded variable to true
            isGrounded = true;
            //rb.drag = groundDrag;
        }
        }
    }
    private void OnCollisionExit(Collision collision) {
        // Check if the ball's rigidbody is not colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Set the isGrounded variable to true
            isGrounded = false;
        }
    }

}



























