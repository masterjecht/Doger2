using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {

    /// <summary>
    /// this script controls the camera's movement and behaviours
    /// </summary>
    /// 
    public List<GameObject> Cameras;
    private GameObject MainCam;
    private GameObject ChangingCam;
    private bool CameraMoving;

    public bool FollowPlayer;
    private GameObject Player;
	void Start () {
        // finding objects
        Player = GameObject.Find("Player").gameObject;
        // find the main camera
        MainCam = GameObject.Find("CameraHub");
        // find all cameras and only activate the camerahub
        GameObject camerahub = GameObject.Find("CameraController");
        foreach( Transform i in camerahub.transform)
        {
            if (i.name != "CameraHub")
            {
                Cameras.Add(i.gameObject);
                i.gameObject.SetActive(false);
            }
        }




	}
	
	// Update is called once per frame
	void Update () {
		// check if follow player is on
        if (FollowPlayer)
        {
            MainCam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, MainCam.transform.position.z);
        }

        if (CameraMoving)
        {
            MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, ChangingCam.transform.position, 50 * Time.deltaTime);
        }
	}

    // this script will find the camera needed and change that that cameras setting overtime
    public void ChangeCameraPosition( int Level )
    {
        // turn off follow player
        FollowPlayer = false;
        // find the interested camera
         ChangingCam = null;
        foreach( GameObject i in Cameras)
        {
            Debug.Log("looking for:" + "Camera " + Level.ToString());
            if (i.name == "Camera " + Level.ToString()) ChangingCam = i;
        }
        // Update below with some animation also change 'Zoom' by using "Size"
        CameraMoving = true;
 

    }
}
