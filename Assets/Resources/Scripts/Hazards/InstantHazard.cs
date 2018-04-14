using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHazard : MonoBehaviour {

    /// <summary>
    /// this script is a hazard obsitcle that will open from the ground move up wait then go back down
    /// there is 2 componanets needed in the item, the hazard itself and a indicator both children of this script
    /// </summary>
    /// 

    public GameObject Hazard;
    public GameObject Indicator;
    public GameObject Player;

    public float WaitTime;
    public float MovingSpeed;
    public float StayTime;
    public float MovingTime;
    public bool MovingUp;
    public bool MovingDown;
    private bool Removing;

	void Start () {
        // check if this is just the model
        if (this.transform.parent == GameObject.Find("Models").transform) return;
        // find the parts
        Player = GameObject.Find("Player");
        Indicator = transform.GetChild(0).gameObject;
        Hazard = transform.GetChild(1).gameObject;

        // first move to under the player
        this.transform.position = Player.transform.position;
        this.transform.position -= new Vector3(0, 0.15f, 0);

        // next invoke movemennt after waittime
        Invoke("StartMoveUp", WaitTime);


	}
	
	// Update is called once per frame
	void Update () {
		// move if allowed
        if (MovingUp)
        {
            Hazard.transform.position += new Vector3(0,MovingSpeed * Time.deltaTime, 0);
        }

        if (MovingDown)
        {
            Hazard.transform.position += new Vector3(0,-MovingSpeed * Time.deltaTime, 0);
        }

        // remove from game
        if (Removing)
        {
            Invoke("Remove", 3);
        }

	}

    // start to move up
    void StartMoveUp()
    {
        MovingUp = true;
        Invoke("StopMoving", MovingTime);
        Indicator.SetActive(false);
    }

    // stop and wait
    void StopMoving()
    {
        MovingUp = false;
        Invoke("StartMoveDown", StayTime);
    }

    void StartMoveDown()
    {
        MovingDown = true;
        Removing = true;
    }

    // remove this object from the game
    void Remove()
    {
        Destroy(this.gameObject);
    }
}
