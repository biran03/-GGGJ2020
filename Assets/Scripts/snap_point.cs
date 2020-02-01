using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_point : MonoBehaviour {

    GameObject paired;
    Rigidbody rb;
    public float snap_force = 50;
    public float lock_distance = 0.05f;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(paired != null) {

            float distance = Vector3.Distance(paired.transform.position, gameObject.transform.position);
            Vector3 direction = Vector3.Normalize(paired.transform.position - gameObject.transform.position);
            rb.AddForce(direction * snap_force * Time.deltaTime);

            if(distance <= lock_distance) {
                Rigidbody pairedrb = paired.GetComponent<Rigidbody>();
                rb.velocity = pairedrb.velocity;
                ConfigurableJoint cj = GetComponent<ConfigurableJoint>();
                cj.connectedBody = pairedrb;
            }
        }


    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Slot") {
            paired = other.gameObject;
            RobotSlot robotSlot = paired.GetComponent<RobotSlot>();
            if (!robotSlot.Attached)
            {
                robotSlot.Attach();
            }
        }
    }

    void OnJointBreak(float breakForce) {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        paired.GetComponent<RobotSlot>().Detach();
        //call func in paired
        paired = null;
    }
}
