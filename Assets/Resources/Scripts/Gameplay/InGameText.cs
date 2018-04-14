using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameText : MonoBehaviour {

    /// <summary>
    /// this script controls the ingame texts
    /// </summary>
    /// 

    public GameObject GameOverMenu;
    public GameObject Scripts;

	void Start () {
        Scripts = GameObject.Find("Scripts");
        // finding GUI
        GameOverMenu = GameObject.Find("GameOverMenu");
        GameOverMenu.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // this script plays when the player is dead and will prompt the player to retry level or back to the hub
    public void GameOver()
    {
        GameOverMenu.SetActive(true);
    }

    // button funtions
    public void Retry()
    {
        Scripts.GetComponent<TimeLine>().StartTimer();
        Scripts.GetComponent<PlayerMasterScript>().IsAlive = true;
        Scripts.GetComponent<PlayerMasterScript>().Paused = false;
        Scripts.GetComponent<PlayerMasterScript>().CanMove = true;
        GameOverMenu.SetActive(false);
    }

    public void Return()
    {


    }
}
