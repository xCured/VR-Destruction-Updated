using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour {

    public static int speed;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {
      
    }
    // Update is called once per frame
   public void FixedUpdate () {
        Vector3 vel = rb.velocity;
        speed = (int)vel.magnitude;

        //Debug.Log(speed);
        
    }
}
