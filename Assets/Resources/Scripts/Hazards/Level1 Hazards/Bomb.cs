using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    /// <summary>
    /// this script will cause a bomb to fall from the sky and explode after a certian amount of time
    /// if the explosion hits a fireball the fireball will also explode
    /// </summary>
    /// 

    public float FallingSpeed;
    public float CountDownTime;
    public float ExplosionPower;


	void Start () {
        // order the bomb to fall to the ground
        this.GetComponent<HazardProperties>().FallingObject(FallingSpeed);
        
	}
	
	
	void Update () {
        // wait until the object has landed then start the coundown
		if (GetComponent<HazardProperties>().FallenObjectLanded)
        {
            Invoke("Countdown", CountDownTime);
            GetComponent<HazardProperties>().FallenObjectLanded = false;            // bad practice
        }
	}

    // this will cause the bomb to  explode
    void CountDown()
    {

    }
}
