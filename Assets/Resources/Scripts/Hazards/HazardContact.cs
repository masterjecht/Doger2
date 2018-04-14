using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardContact : MonoBehaviour {

    /// <summary>
    /// this script deals with the collisions on hazards
    /// </summary>
    /// 

    public PlayerMasterScript masterscript;

    void Start () {
        masterscript = GameObject.Find("Scripts").GetComponent<PlayerMasterScript>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            masterscript.IsAlive = false;
        }
		
	}
}
