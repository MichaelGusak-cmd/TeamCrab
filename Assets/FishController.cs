using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    
    
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Player")) {
            float r1 = Random.Range(-50f, 50f);
            float r2 = Random.Range(-50f, 50f);
            rb.position = new Vector3(r1, 30f, r2);
        }
    }

}
