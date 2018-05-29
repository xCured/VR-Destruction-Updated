using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class RayCastCam : MonoBehaviour
{

    public float RayDistance = 500;
    public GameObject SetActivePls;
    public Image HealthBar;

    public float GetHealth;
    public float GetStarterHealth;
    // Use this for initialization
    void Start()
    {
        //rend = SetActivePls.GetComponent<Renderer>();

    }
    void Update()
    {
        // GetHealth = Break.health;
        // GetStarterHealth = Break.StartHealth;
        Debug.Log(GetHealth);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Ray ray= Camera.main.ScreenPointToRay(InputTracking.GetLocalPosition(XRNode.CenterEye));
        // HealthBar.fillAmount = GetHealth / GetStarterHealth;
        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.tag == ("Base"))
            {

                SetActivePls.GetComponent<Canvas>().enabled = true;
                Break breakScript = hit.transform.GetComponent<Break>();
                HealthBar.fillAmount = breakScript.GetDividedHealth(); ;

            }
            else
            {
                SetActivePls.GetComponent<Canvas>().enabled = false;
            }

            //else
            //{
            //    SetActivePls.GetComponent<Canvas>().enabled = false;
            //    Debug.Log("hit");
            //}

        }
    }

}
