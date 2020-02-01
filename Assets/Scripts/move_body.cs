 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_body : MonoBehaviour {

    Rigidbody rb;
    public float force = 5000;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1) {
            Debug.Log("FORCE");
            rb.AddForce(new Vector3(0, Input.GetAxis("Vertical")  * force * Time.deltaTime,0));
        }

        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1)
        {
            Debug.Log("FORCE");
            rb.AddForce(new Vector3( Input.GetAxis("Vertical") * force * Time.deltaTime, 0, 0));
        }
    }
}
