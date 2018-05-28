using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {
    Rigidbody rb; //reference to the rigidbody, if we call RB we instantly know RB = rigidbody
    public int ToolSpeed;
    GameObject Hammersp;
    
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>(); // when we call RB we already know its the rigidbody but here we set the RB to getting the component for easy acces.
    
       
        
	}

    // Update is called once per frame
    void FixedUpdate() {
        RayCastThis(); //FixedUpdate for Physics. We call the Raycast function
        Hammersp.GetComponent<HammerScript>().speed = ToolSpeed;
        //  GameObject.Find("Hammer").GetComponent<HammerScript>().speed = ToolSpeed;
        Debug.Log(ToolSpeed);

	}

    void RayCastThis()
    {
       
        if (gameObject.tag == "Breakable") // If the tag is Breakable then the raycasting is applied to that object. If the tag is anything else. The raycast isnt applied
        {
            RaycastHit hit; //Create the raycast here
            if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity)) //We have a Physics Raycast here that takes in parameters.
                //First one is the gameobject the that the script is attached to middlepoint(Position). The second one is the direction we point the raycast. Third is the ray we send and last is the length of the raycast
            {
                if (hit.transform.tag == "Ground") //Simple control statement. If the raycast hits the object with "ground" as the tag the kinematic on the objects gets turned off (Which makes it fall)
                {
                    rb.isKinematic = false;
                   // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow); //<---- Debug statement for getting displaying the raycast in Yellow lines
                    
                }
            }
        }

    }
 
    void OnCollisionEnter(Collision Coll)
    {

        if(Coll.gameObject.tag == "Hammer" && ToolSpeed > 3)
        {
            rb.isKinematic = false;
            rb.AddForce(Coll.impulse * 1, ForceMode.Impulse);
            StartCoroutine(DestroyWithDelay());
        }
    }
    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
