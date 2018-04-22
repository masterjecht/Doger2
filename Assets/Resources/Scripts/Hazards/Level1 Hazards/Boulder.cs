using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    /// <summary>
    /// this script contains the AI of the boulder which will fall from the sky and hit on a spot
    /// </summary>
    /// 
    public float FallingSpeed;

    void Start () {

        // order the bomb to fall to the ground
        this.GetComponent<HazardProperties>().FallingObject(FallingSpeed);

    }
	
	// Update is called once per frame
	void Update () {
        // wait until the object has landed then start the coundown
        if (GetComponent<HazardProperties>().FallenObjectLanded)
        {
            Invoke("Death", 0.5f);
            gameObject.AddComponent<HazardContact>();
            this.GetComponent<HazardProperties>().FallenObjectLanded = false;            // bad practice

        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
