using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    /// <summary>
    /// this script controls the lazer hazard
    /// </summary>
    /// 
    public GameObject indicator;
    public GameObject Laser;

    public float IndicationTime;
    public float Duration;
    public bool LaserGrowing;

    public float Size;

    
	void Start () {
        // finding objects
        indicator = transform.Find("LaserIndicator").gameObject;
        Laser = transform.Find("LaserObject").gameObject;
        Size = Laser.transform.localScale.y;

        // changing the scales of the lase to 0
        Laser.transform.localScale -= new Vector3(0, Size, 0);

        // start the indication timer
        Invoke("StartLaser", IndicationTime) ;

	}
	
	
	void Update () {
		// check if the laser should be growing


	}

    // this function starts laser growing
    void StartLaser()
    {
        LaserGrowing = true; 
    }
}
