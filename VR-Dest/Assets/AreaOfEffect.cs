using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour {

 //   float ToolSpeed2;
 //   float tools;
 //   readonly float maxAOE = 2f;
  

	//// Use this for initialization
	//void Start () {
        
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       ToolSpeed2 = HammerScript.speed;
 //       tools = ToolSpeed2 / 5;
 //       if(tools > maxAOE)
 //       {
 //           tools = 2f;
 //       }
       

 //      // Debug.Log(tools);
 //       Debug.Log(ToolSpeed2);
	//}
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Base"  || col.gameObject.tag == "Breakable")
        {
            if (col.gameObject.GetComponent<Rigidbody>().isKinematic == true)
            {

                col.gameObject.GetComponent<Rigidbody>().isKinematic = false;

            }
        }

    }

    public void setSize(float size)
    {

        gameObject.transform.localScale = new Vector3(size, gameObject.transform.localScale.y, size);

    }
    //public void FixedUpdate()
    //{

    //    gameObject.transform.localScale = new Vector3(tools, gameObject.transform.localScale.y, tools);
        

    //}
}
