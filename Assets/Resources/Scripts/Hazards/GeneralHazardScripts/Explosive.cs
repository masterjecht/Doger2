using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    /// <summary>
    /// this script will turn the object into explosive meaning if this object
    /// comes into contact with a explosion it will also explode
    /// </summary>
    /// 
    public float ExplosionPower;

	void Start () {
		
	}

    
    void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Explosive")
        {
            // destroy object and create explosion
            GameObject type = Resources.Load("Prefabs/ExplosionObject") as GameObject;
            type = Instantiate(type, this.transform.position, Quaternion.identity);
            type.GetComponent<Explosion>().ExplosionPower = ExplosionPower;
            Destroy(this.gameObject);
        }

    }
}
