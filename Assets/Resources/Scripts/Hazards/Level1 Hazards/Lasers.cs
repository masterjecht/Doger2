using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    /// <summary>
    /// this script controls the lazer hazard
    /// </summary>
    /// 
    private GameObject indicator;
    private GameObject Laser;

    public float IndicationTime;
    public float Duration;
    private bool LaserGrowing;

    private float Size;



    
	void Start () {
        // finding objects
        indicator = transform.Find("LaserIndicator").gameObject;
        Laser = transform.Find("LaserObject").gameObject;
        Size = Laser.transform.localScale.y;

        // changing the scales of the lase to 0
        Laser.transform.localScale -= new Vector3(0, Size, 0);

        // deactivate laser at start
        Laser.SetActive(false);

        // find out if the laser will be vertical or horizontal
        string direction = this.GetComponent<HazardProperties>().Owner.GetComponent<Spawners>().Side;
        if (direction == "Bottom" || direction == "Top") transform.eulerAngles = new Vector3(0, 0, 90);         // setting the rotation

        // start the indication timer
        Invoke("StartLaser", IndicationTime);

	}
	
	
	void Update () {
		// check and grow the laser if needed
        if (LaserGrowing)
        {
            Laser.transform.localScale += new Vector3(0, 0.1f, 0);
            if (Laser.transform.localScale.y > Size) LaserGrowing = false;                      // turn off when the laser is full size
        }


	}

    // this function starts laser growing
    void StartLaser()
    {
        LaserGrowing = true;
        indicator.SetActive(false);
        Laser.SetActive(true);
        Invoke("RemoveLaser", Duration);
    }

    // destroys laser, reinvokes itself after first active to reduce the size of the laser to make it disappear until destroy
    void RemoveLaser()
    {
        Laser.transform.localScale -= new Vector3(0, 0.1f, 0);
        Invoke("RemoveLaser", 0.01f);
        if (Laser.transform.localScale.y < 0)
        {
            CancelInvoke();
            Destroy(this.gameObject);
        }
    }


}
