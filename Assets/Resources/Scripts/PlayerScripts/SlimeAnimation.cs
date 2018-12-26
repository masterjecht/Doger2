using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour {

    /// <summary>
    /// this wil;l control the animations of the slime, the position of the children are critical!!!
    /// </summary>
    /// 
    private GameObject SlimeNormal;
    private GameObject SlimeSide;
    private GameObject SlimeBack;
    private GameObject WalkingEffect;

    private Vector3 Oldlocation;

        
	void Start () {
        // find all componants
        SlimeNormal = this.gameObject.transform.GetChild(0).gameObject;
        SlimeSide = this.gameObject.transform.GetChild(1).gameObject;
        SlimeBack = this.gameObject.transform.GetChild(2).gameObject;
        WalkingEffect = this.gameObject.transform.GetChild(3).gameObject;
        Oldlocation = this.transform.position;

        // turn off all componants except for standing 
        SlimeSide.SetActive(false);
        SlimeBack.SetActive(false);

    }
	

	void Update () {
        // check location against old location
        if (Oldlocation != this.transform.position)
        {

            // the player has moved check where
            if (Oldlocation.x > transform.position.x)
            {
                EnableSlimeObject(1);
                SlimeSide.transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            if (Oldlocation.x < transform.position.x)
            {
                EnableSlimeObject(1);
                SlimeSide.transform.localEulerAngles = new Vector3(0, 180, 0);
            }

            // player going up
            if (Oldlocation.y < transform.position.y)
            {
                EnableSlimeObject(2);
            }

            // player going down
            if (Oldlocation.y > transform.position.y)
            {
                EnableSlimeObject(0);
            }
        }

        else
        {
            EnableSlimeObject(0);
        }

        // set the new old location
        Oldlocation = this.transform.position;

    }

    void EnableSlimeObject(int Object)
    {

        if (Object == 0)
        {
            SlimeNormal.SetActive(true);
            SlimeSide.SetActive(false);
            SlimeBack.SetActive(false);
        }
        if (Object == 1) {
            SlimeNormal.SetActive(false);
            SlimeSide.SetActive(true);
            SlimeBack.SetActive(false);
        }
        if (Object == 2)
        {
            SlimeBack.SetActive(true);
            SlimeSide.SetActive(false);
            SlimeNormal.SetActive(false);
        }
       
    }

}
