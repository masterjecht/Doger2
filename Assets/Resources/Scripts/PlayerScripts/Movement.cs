using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    /// <summary>
    /// this script controls the movement, it gathers input then move the player accordingly
    /// </summary>
    /// 
    public PlayerMasterScript masterscript;

    public bool InputUp;
    public bool InputDown;
    public bool InputLeft;
    public bool InputRight;


    void Start () {
        masterscript = GameObject.Find("Scripts").GetComponent<PlayerMasterScript>();

        

	}
	

	void Update () {
        // firstly check inputs
        CheckInputs();

        // next move if the player wants to move
        if ((!InputUp && !InputDown && !InputRight && !InputLeft) || !masterscript.CanMove) return;                // return if all inputs are false or not allowed to move
        MovePlayer();
    }

    // this function checks for any inputs from the user NOTE THIS INCLUDES ACTION INPUT
    void CheckInputs()
    {
        // at the moment only computer controls

        //-------------action-----------
        if (Input.GetKey(KeyCode.Q))
        {
            masterscript.ActionIput = true;
        }
        else
        {
            masterscript.ActionIput = false;
        }

        //-------------up-------------
        if (Input.GetKey(KeyCode.W))
        {
            InputUp = true;
        } else
        {
            InputUp = false;
        }

        //-------------down------------
        if (Input.GetKey(KeyCode.S))
        {
            InputDown = true;
        }
        else
        {
            InputDown = false;
        }

        //-------------Right------------
        if (Input.GetKey(KeyCode.D))
        {
            InputRight = true;
        }
        else
        {
            InputRight = false;
        }

        //-------------Left------------
        if (Input.GetKey(KeyCode.A))
        {
            InputLeft = true;
        }
        else
        {
            InputLeft = false;
        }

    }

    // this function will move the player
    void MovePlayer()
    {
        // --------------move up--------------
        if (InputUp)
        {
            this.transform.position += new Vector3(0, masterscript.MovementSpeed * Time.deltaTime,0);
        }

        // --------------move down--------------
        if (InputDown)
        {
            this.transform.position += new Vector3(0, -masterscript.MovementSpeed * Time.deltaTime,0);
        }

        // --------------move right--------------
        if (InputRight)
        {
            this.transform.position += new Vector3(masterscript.MovementSpeed * Time.deltaTime,0,0);
        }

        // --------------move left--------------
        if (InputLeft)
        {
            this.transform.position += new Vector3(-masterscript.MovementSpeed * Time.deltaTime, 0, 0);
        }
    }
}
