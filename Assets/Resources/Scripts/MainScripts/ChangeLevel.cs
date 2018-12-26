using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {

    /// <summary>
    /// this script creates a 'Teleport' to the desired level, also controls the UI componant 
    /// </summary>

    public int Level;
    public int OrbsRequired;

    private bool RequirementsReached;


    private GameObject LevelSelectHolder;
    private GameObject Player;
    private GameObject Door;

    private PlayerMasterScript playermasterscript;
    private CameraManagement cammanagement;
    private InGameText ingametext;
    private TimeLineManagers TimeLines;
    private GlobalScipts globalscripts;



    void Start () {
        // mapping varibles
        Player = GameObject.Find("Player");
        cammanagement = GameObject.Find("Scripts").GetComponent<CameraManagement>();
        playermasterscript = GameObject.Find("Scripts").GetComponent<PlayerMasterScript>();
        ingametext = GameObject.Find("Scripts").GetComponent<InGameText>();
        LevelSelectHolder = GameObject.Find("LevelSelectHolder");
        TimeLines = GameObject.Find("Scripts").GetComponent<TimeLineManagers>();
        globalscripts = GameObject.Find("Scripts").GetComponent<GlobalScipts>();
        Door = this.transform.Find("Door").gameObject;

    }
	

	void Update () {
        // check if the playr has reached the requirements
        if (!RequirementsReached)
        {
            if (globalscripts.Gems >= OrbsRequired)
            {
                RequirementsReached = true;
                // change the door
                Door.transform.GetChild(1).gameObject.SetActive(false);
            }
        }



		// check if the button has been clicked
        if (ingametext.LevelConfirmed)
        {
            ingametext.LevelConfirmed = false;
            // start to move the camera to the new level
            cammanagement.ChangeCameraPosition(Level);

            // activate the timeline
            TimeLines.ActivateTimeLine(Level);

            // move player to new positon
            Player.transform.position = GameObject.Find("Platform " + Level.ToString())
                .GetComponent<PlatformProperties>().PlayerSpawn.transform.position;

            // turn off UI
            LevelSelectHolder.transform.GetChild(0).gameObject.SetActive(false);

            // continue after a time periond
            Invoke("LevelConfirmedTimed", 2f);

        }

        // check if the player has cancelled the level
        if (ingametext.LevelCancelled)
        {
            ingametext.LevelCancelled = false;
            playermasterscript.CanMove = true;
            LevelSelectHolder.transform.GetChild(0).gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DisplayUI();
            playermasterscript.CanMove = false;
        }

    }

    // this function displays the UI for the level the player is trying to enter
    void DisplayUI()
    {
        // change the UI text to suit the level
        LevelSelectHolder.transform.GetChild(0).gameObject.SetActive(true);
        // find all elements needed
        GameObject title = LevelSelectHolder.transform.GetChild(0).Find("Title").gameObject;
        GameObject req = LevelSelectHolder.transform.GetChild(0).Find("Requirments").gameObject;
        GameObject buttonEnter = LevelSelectHolder.transform.GetChild(0).Find("ButtonEnter").gameObject;
        GameObject reqNotMet = LevelSelectHolder.transform.GetChild(0).Find("RequiementsNotMet").gameObject;

        // setting elements
        title.GetComponent<Text>().text = playermasterscript.CurrentWold + " - Level: " + Level.ToString();
        req.GetComponent<Text>().text = "Requires:           " + OrbsRequired;

        // Requirement checking and changing here
        if (globalscripts.Gems < OrbsRequired)
        {
            buttonEnter.GetComponent<Button>().interactable = false;
            reqNotMet.GetComponent<Text>().text = "Requirements Not Met";
        }
        else
        {
            buttonEnter.GetComponent<Button>().interactable = true;
            reqNotMet.GetComponent<Text>().text = "";
        }

    }

    // this is where the level loading function continues to show the text
    void LevelConfirmedTimed()
    {

    }
}
