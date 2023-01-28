using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    Rigidbody rb;
    //Ground Check
    bool isGrounded = false;
    //Constants
    int jumpForce = 7;
    int dashForce = 25;
    int walkSpeed = 50;
    int dashDelay = 0;    
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
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }        
        if (Input.GetKeyDown(KeyCode.Tab)) {
            dash = !dash;
        }
        
        Vector3 m_Input = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")) )) ;
        
        if( !dash ){
           // rb.MovePosition(transform.position + m_Input* Time.deltaTime * walkSpeed );
            
            rb.velocity = rb.velocity + m_Input * walkSpeed * Time.deltaTime;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, walkSpeed);
            //rb.AddForce(m_Input * walkForce, ForceMode.Impulse);
        } else {
            if(dashDelay == 0){
                rb.AddForce(m_Input * dashForce, ForceMode.Impulse);
                dashDelay = 250;
            } else {
                dashDelay--;
                if(dashDelay == 180) {
                    rb.velocity = Vector3.zero;
                }
            }
            
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



























