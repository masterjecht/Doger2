using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineManagers : MonoBehaviour {

	/// <summary>
    /// manages the timelines
    /// </summary>
    /// 
    public List<GameObject> Timelines;
	void Awake () {
		foreach(Transform i in GameObject.Find("TimeLineManager").transform)
        {
            Timelines.Add(i.gameObject);
        }
	}
	
	// this funtion activates a certin timeline
	public void ActivateTimeLine (int Level) {
		foreach (GameObject i in Timelines)
        {
            if (i.name == "TimeLine " + Level.ToString())
            {
                i.SetActive(true);
            }
        }
	}
}
