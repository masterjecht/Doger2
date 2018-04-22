using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    /// <summary>
    /// this will cause a explosion to occur
    /// </summary>
    /// 
    public float ExplosionPower;
    private GameObject ExplosionObject;
    private float CurrentPower;
    private bool ReachedMaximum;

	void Start () {
        // create the explosion
        GameObject item = Resources.Load("Prefabs/Explosion") as GameObject;
        ExplosionObject = Instantiate(item, this.transform.position, Quaternion.identity);

	}
	
	
	void Update () {
        // increase the size of the explosion
        if (!ReachedMaximum)
        {
            CurrentPower++;
            ExplosionObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);

            if (CurrentPower > ExplosionPower) ReachedMaximum = true;
        }

        // after it has reached maximum fade it out 
        if (ReachedMaximum)
        {
            ExplosionObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            ExplosionObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.01f);
        }

        // lastly check if the object should be destroyed
        if (ExplosionObject.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            Destroy(ExplosionObject);
            Destroy(this.gameObject);
        }
	}
}
