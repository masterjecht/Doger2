using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    // this is a short burst of speed

    public float cooldown;
    private PlayerMasterScript masterscript;
    private Movement movementscript;
    private bool InUse;
    public float Duration;

    private Vector3 MovementSpeed;

    public float multiplyer;

    void Start () {
        masterscript = GameObject.Find("Scripts").GetComponent<PlayerMasterScript>();
        movementscript = this.gameObject.GetComponent<Movement>();
    }
	
	
	void Update () {
        // check if input is active and can use ability
        if (masterscript.ActionIput && !masterscript.AbilityOnCooldown && masterscript.CanUseAbility)
        {
            masterscript.AbilityOnCooldown = true;
            DashAction();
        }
		


        // move if inuse
        if (InUse)
        {
            this.transform.position += MovementSpeed;
        }
	}

    // simple dash basic
    void DashAction()
    {
        
        // first stop the player from inputing
        masterscript.CanMove = false;

        // now continue moving in the direction currently moving
        if (movementscript.InputUp)
        {
            MovementSpeed += new Vector3(0, 0, -masterscript.MovementSpeed * Time.deltaTime * multiplyer);
        }

        if (movementscript.InputDown)
        {
            MovementSpeed += new Vector3(0, 0, masterscript.MovementSpeed * Time.deltaTime * multiplyer);
        }

        if (movementscript.InputRight)
        {
            MovementSpeed += new Vector3(-masterscript.MovementSpeed * Time.deltaTime * multiplyer, 0, 0);
        }

        if (movementscript.InputLeft)
        {
            MovementSpeed += new Vector3(masterscript.MovementSpeed * Time.deltaTime * multiplyer, 0, 0);
        }

        // incase there is no input just dash up
        if (MovementSpeed == Vector3.zero)
        {
            MovementSpeed += new Vector3(0, 0, -masterscript.MovementSpeed * Time.deltaTime * multiplyer);
        }

        // finally set inuse and set a timer
        InUse = true;
        Invoke("StopDash", Duration);
    }

    // this function stops the dash and sets the cooldown
    void StopDash()
    {
        InUse = false;
        masterscript.CanMove = true;
        MovementSpeed = Vector3.zero;
        Invoke("RemoveCooldown", cooldown);
    }

    // this allows the function to be used again after cooldown
    void RemoveCooldown()
    {
        masterscript.AbilityOnCooldown = false;
    }
}
