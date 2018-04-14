using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    /// <summary>
    /// this script is a simple striaght projectile based on the spawner's location
    /// </summary>
    /// 

    public bool model;

    public HazardProperties Properties;
    public string Direction;
    public float Speed;
    public float Lifetime;

	void Start () {
        Properties = this.GetComponent<HazardProperties>();
        // check for owner or if it is just a model
        if (Properties.Owner != null) {
            // find the direction from the owner
            Direction = Properties.Owner.GetComponent<Spawners>().Side;
            model = false;

            // destroy after lifetime turn on to destroy
            Invoke("RemoveItem", Lifetime);
            Properties.DoNotDestroy = false;
        }
        else {
            Properties.DoNotDestroy = true;
                 }
	}
	
	
	void Update () {
        if (model) return;
		// move object opposite of the direction
        // ------------movedown-----------
        if (Direction == "Top")
        {
            transform.position += new Vector3(0, -Speed * Time.deltaTime,0);

        }

        // ------------moveup-----------
        if (Direction == "Bottom")
        {
            transform.position += new Vector3(0, Speed * Time.deltaTime,0);
        }

        // ------------moveright-----------
        if (Direction == "Left")
        {
            transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        }

        // ------------moveleft-----------
        if (Direction == "Right")
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }

    void RemoveItem()
    {
        Destroy(this.gameObject);
    }
}
