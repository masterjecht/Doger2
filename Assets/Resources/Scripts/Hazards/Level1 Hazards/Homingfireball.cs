using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homingfireball : MonoBehaviour {

    /// <summary>
    /// this script generates a fireball that will slowly follow the player until it disappears
    /// </summary>
    /// 
    public float Speed;
    private GameObject Player;
    public float DecayTime;
    
	void Start () {
        // finding varibles
        Player = GameObject.Find("Player");

       InvokeRepeating("Decay", DecayTime,DecayTime);
	}
	
	
	void Update () {
        // move towards the player
        transform.position = Vector3.MoveTowards(this.transform.position,Player.transform.position, Speed * Time.deltaTime);	
	}

    // this will make the firball lose its size each time this function is called
    void Decay()
    {
        // making sprite smaller
        this.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        if (this.gameObject.transform.localScale.x <= 0.4f)
        {
            Destroy(this.gameObject);
        }
    }
}
