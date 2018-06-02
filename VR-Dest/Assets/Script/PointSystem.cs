using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PointSystem : MonoBehaviour {

    public float points = 0f;
    public float V1= 40f;
    public float V2 = 60f;
    public float V3 = 100f;
    public float Multi = 1f;
    public float MaxPoints = 400f;
    int GetHammerSpeed;
    float timer = 2f;

    public int TotalScore;

    public float givenPoints;
   

    

    //When hit once lower amount of point
    //when Destroy(Gameobject) Get more points


    // Use this for initialization
    void Start () {
        
    }


    // Update is called once per frame
    void Update()
    {
        GetHammerSpeed = HammerScript.speed;
        if(timer <= 0)
        {
            Multi = 1f;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        TotalScore = (int)points;

    }

    void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject.tag == "Hammer" )
        {
            if (GetHammerSpeed == 0)
            {
                points = points + 0;

            }
            else if (GetHammerSpeed >= 4 && GetHammerSpeed <= 6)
            {
                givenPoints = V1 * Multi;
                points = points + givenPoints;

            }
            else if (GetHammerSpeed >= 7 && GetHammerSpeed <= 9)
            {
                givenPoints = V2 * Multi;
                points = points + givenPoints;

            }
            else if (GetHammerSpeed >= 11)
            {
                givenPoints = V3 * Multi;
                points = points + givenPoints;

            }
            timer = 2f;
            Multiplier();
            Debug.Log(TotalScore);   
        }

 
    }

    public void Multiplier()
    {
        if (GetHammerSpeed > 3)
        {
            if (Multi < 1.2f)
            {
                Multi += 0.08f;
            }else if (Multi > 1.2f && Multi < 1.5f)
            {
                Multi += 0.04f;
            }
            else if (Multi > 1.5f)
            {
                Multi += 0.02f;
            }

            if (Multi > 2.5f)
            {
                Multi = 2.5f;
            }
          
        }
    }
    public void FixedUpdate()
    {
       
    

    }
}
