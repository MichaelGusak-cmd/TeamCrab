using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UIManager;

public class CharacterControls : MonoBehaviour
{

    Rigidbody rb;
    //Ground Check
    bool isGrounded = false;
    public UIManager _UIManager;
    //Constants
    public int jumpForce = 100;
    public int fallForce = 2;
    public int walkSpeed = 200;
    public float RotateSpeed = 200;
    public float jumpTimeout = 0.5f;
    private float jumpedAt = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        makeObjects();
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y < -5) {
            //reset();
            die();
        }
        if(Input.GetKey(KeyCode.Tab)) {
            isGrounded = true;
        }
        if(Input.GetKey(KeyCode.R)) {
            isGrounded = true;
        }

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
        if (true){  //!isGrounded
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player") ) {
                //Debug.DrawRay(transform.position, Vector3.down, Color.red, 100f); 
                float O = 1.8f;
                Vector3[] attempts = new [] {
                    new Vector3(-O, 0, -O),
                    new Vector3(-O, 0, -O),
                    new Vector3( O, 0, -O),
                    new Vector3(-O, 0,  O),
                    new Vector3(-O, 0,  0),
                    new Vector3( O, 0,  0),
                    new Vector3( 0, 0, -O),
                    new Vector3( 0, 0,  O)
                };

                for (int i = 0; i< 8; i++){
                    Debug.DrawRay(transform.position + attempts[i], Vector3.down, Color.red, 100f);
                    if ( Physics.Raycast(transform.position  + attempts[i], Vector3.down, 2f, 1 << LayerMask.NameToLayer("Ground")) ) {
                        isGrounded = true;
                    }
                }    


            }
        }
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Finish")) {
            reset();
            duplicate();
            _UIManager.updateScore();
        }
    }

    private void OnCollisionExit(Collision collision) {
        // Check if the ball's rigidbody is not colliding with the ground
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }

    private void reset(){
        makeObjects();
    }

    private void duplicate(){
        Rigidbody clone;
        clone = Instantiate(rb, new Vector3(5.8f, 5f, -35.8f), Quaternion.identity);
        clone.transform.rotation = Quaternion.Euler(-90f, -28f, 210f); ;
        //Quaternion.Euler(-90f, -28f, 210f);
    }

    private void die(){
        rb.position = new Vector3(5.8f, 5f, -35.8f);
        rb.velocity = new Vector3(0,0,0);        
    }

    private void makeObjects(){

        makeCube(new Vector3(15, 15, 15), new Vector3(-5.8f,    40,    22     ));
        makeCube(new Vector3(6, 6, 6),    new Vector3(-18.8f,   40,    4.5f   ));
        makeCube(new Vector3(6, 6, 6),    new Vector3(-35,      40,   -27f   ));
        makeCube(new Vector3(8, 8, 8),    new Vector3(35f,     40,    -11f   ));

    }

    private void makeCube(Vector3 size, Vector3 position) {
        float r1 = Random.Range(-2f, 2f);
        float r2 = Random.Range(-2f, 2f);
        //float r3 = Random.Range(-2f, 2f);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = size;
        //cube.transform.rotation = new Vector3(r1, r2, r3); 
        cube.transform.position = ( position + new Vector3(r1, 0, r2) );
        Rigidbody rb1 = cube.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rb1.mass = 100;
        cube.tag="Ground";
        cube.layer=6;
    }

}



























