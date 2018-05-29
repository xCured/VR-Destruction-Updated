using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Break : MonoBehaviour
{
    Rigidbody rb; //reference to the rigidbody, if we call RB we instantly know RB = rigidbody
    public int ToolSpeed;
    float StartHealth = 20f;
    float health;
    float ToolSpeed2;
    float tools;
    readonly float maxAOE = 1f;
    public GameObject Interactable;


    public GameObject aoeOrigin;


    //public GameObject HealthBarShow;


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); // when we call RB we already know its the rigidbody but here we set the RB to getting the component for easy acces.
        health = StartHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ToolSpeed = HammerScript.speed;
        RayCastThis(); //FixedUpdate for Physics. We call the Raycast function


        ToolSpeed2 = HammerScript.speed;
        tools = ToolSpeed2 / 5;
        if (tools > maxAOE)
        {
            tools = 1f;
        }
        //GameObject.Find("Sledge").GetComponent<HammerScript>().speed = ToolSpeed;

        //  GameObject.Find("Hammer").GetComponent<HammerScript>().speed = ToolSpeed;
        // Debug.Log(health);
        // Debug.Log(ToolSpeed);

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
        ContactPoint contact = Coll.contacts[0];

        if (Coll.gameObject.tag == "Hammer"  && ToolSpeed > 3)
        {
            health -= 10f;
            rb.isKinematic = false;

            GameObject AOEClone = (GameObject)Instantiate(aoeOrigin, contact.point, Quaternion.identity);
             AOEClone.transform.Rotate(new Vector3(90, 90, 90));

            AOEClone.GetComponent<AreaOfEffect>().setSize(tools);
           Destroy(AOEClone);


            //Debug.Log(health);
            if (health < 10f)
            {

                StartCoroutine(DestroyWithDelay());
                rb.AddForce(Coll.impulse * 1, ForceMode.Impulse);
            }
        }

        if(Coll.gameObject.tag == "AOE")
        {
            rb.isKinematic = false;
        }
    }
    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public float GetDividedHealth()
    {
        return health / StartHealth;
    }

}
