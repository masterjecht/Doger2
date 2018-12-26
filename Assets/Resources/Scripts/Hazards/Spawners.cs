using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    /// <summary>
    /// this is all the properties for the spawners
    /// </summary>
    /// 

    public GameObject ObjectToSpawn;
    public string Side;
    public float Time;
    public bool RandomTime;
    public bool RandomLocation;             // if false will home to player
    public bool ChangingSides;
    public bool SpawnerOnPlayfield;

    private float CurrentTime;
    private float AdditionalTime;
    private GameObject Player;
    private GameObject Scripts;
    private GameObject Platform;

    public float TimeUntilActive;               // this script will be passes onto the timeline when this script is found


	void Start () {
        Player = GameObject.Find("Player");
        Scripts = GameObject.Find("Scripts");
        Platform = Scripts.GetComponent<PlayerMasterScript>().CurrentPlatform;

        InvokeRepeating("IncreaseTime", 0, 0.01f);
    }
	
	// increases time and checks if it is time to spawn
	void IncreaseTime () {
        CurrentTime += 0.01f;

        if (CurrentTime > Time + AdditionalTime)
        {
            CurrentTime = 0;
            if (ChangingSides) RandomSide();
             ChangeLocation();
            if (!RandomLocation) FollowPlayer();
            GameObject item = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity) as GameObject;
            item.GetComponent<HazardProperties>().Owner = this.gameObject;
            item.GetComponent<HazardProperties>().DoNotDestroy = false;

        }
	}

    // change the location to a random position NOTE I HAVE TAKEN THE RANDOM OUT FOR NOW!!
    void ChangeLocation()
    {
        // check if the spawner spawns ontop the platform ------------
        if (SpawnerOnPlayfield)
        {
            if (RandomLocation)
            {
                this.transform.position = Platform.GetComponent<PlatformProperties>().FindRandomLocation();
            }
            else
            {
                this.transform.position = Player.transform.position;
            }
            return;
        }
        //-----------top ------------------
        if (Side == "Top")
        {
            this.transform.position = new Vector3(0,3, 0);
        }

        //-----------bottom ------------------
        if (Side == "Bottom")
        {
            this.transform.position = new Vector3(0, -3, 0);
        }

        //-----------right ------------------
        if (Side == "Right")
        {
            this.transform.position = new Vector3(-3, 0, 0);
        }

        //-----------Left ------------------
        if (Side == "Left")
        {
            this.transform.position = new Vector3(3, 0, 0);
        }
    }

    // choose a randomside
    void RandomSide()
    {
        int luck = Random.Range(0, 4);

        if (luck == 4) Side = "Top";
        if (luck == 3) Side = "Bottom";
        if (luck == 2) Side = "Right";
        if (luck == 1) Side = "Left";
    }

    // will home the Player
    void FollowPlayer()
    {
        if (Side == "Top" || Side == "Bottom")
        {
           transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (Side == "Right" || Side == "Left")
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y,transform.position.z);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
