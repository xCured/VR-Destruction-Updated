using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public static int speed;
    Rigidbody rb;
   



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //setSize();
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector3 vel = rb.velocity;
        speed = (int)vel.magnitude;

        //Debug.Log(speed);

    }


    //private void OnCollisionEnter(Collision Coll)
    //{
    //    if (Coll.gameObject.tag == "breakable" || Coll.gameObject.tag == "Base")
    //    {

    //        GameObject AOEClone = (GameObject)Instantiate(aoeOrigin, Coll.gameObject.transform.position, Quaternion.identity);
    //        AOEClone.transform.Rotate(new Vector3(90, 90, 90));
    //        Destroy(AOEClone, 0.3f);
            

    //        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //        //Vector3 pos = contact.point;
    //        //Instantiate(AOE, pos, rot);
    //        //   Destroy(gameObject);
    //        // Instantiate(AOE, Contact, Quaternion.identity);


    //    }

    //}
         
}


 
