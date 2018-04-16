using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterScript : MonoBehaviour {

    // public varibles accessed by other scripts

    public bool CanMove;
    public bool CanUseAbility;
    public bool AbilityOnCooldown;
    public float MovementSpeed;
    public bool IsAlive;
    public GameObject CurrentPlatform;

    public bool ActionIput;

    public bool Paused;


	void Start () {
        // start the level NOTE remove this when demo over
        //GetComponent<TimeLine>().StartTimer();
        CurrentPlatform = GameObject.Find("Platform");
	}
	
	
	void Update () {
        // check for death
		if (!IsAlive && !Paused)
        {
            Paused = true;
            Died();
        }

      
	}

    // this is the actions played when the player dies
    void Died()
    {
        CanMove = false;
        GameObject models = GameObject.Find("Models");
       // Debug.Log(models.name);
        // removie objects from game
        foreach( GameObject i in GameObject.FindGameObjectsWithTag("Hazard"))
        {
            if (!i.GetComponent<HazardProperties>().DoNotDestroy)
            {
                Destroy(i);
            }
        }

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            i.SetActive (false);

        }

        GetComponent<TimeLine>().StopTimer();
        GetComponent<InGameText>().GameOver();


    }
}
