using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformProperties : MonoBehaviour {
    /// <summary>
    /// this script holds properties and functions for the platform a player is standing on
    /// 
    /// </summary>


    public Vector2 TopLeft;
    public Vector2 TopRight;
    public Vector2 BottomLeft;
    public Vector2 BottomRight;

    public GameObject PlayerSpawn;

	void Start () {
        // finding the deminsions
        TopLeft = transform.Find("TopLeft").position;
        TopRight = transform.Find("TopRight").position;
        BottomLeft = transform.Find("BottomLeft").position;
        BottomRight = transform.Find("BottomRight").position;

        // finding the spawn location
        PlayerSpawn = transform.Find("PlayerSpawn").gameObject;

    }

    public Vector2 FindRandomLocation()
    {
        return new Vector2(Random.Range(TopRight.x, TopLeft.x), Random.Range(TopLeft.y, BottomLeft.y));

    }
	

}
