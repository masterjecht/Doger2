using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour {

    // Use this for initialization
    public float Time;

    // 2 lists, 1 is the time the other is the spawner
    public List<float> TimeSpawned;
    public List<GameObject> Spawner;

    


	void Start () {

	}

    public void StartTimer()
    {
        InvokeRepeating("IncreaseTime", 0, 0.5f);
    }

    public void StopTimer()
    {
        Time = 0;
        CancelInvoke();
    }
	// Update is called once per frame
	void Update () {
		
	}

    // increases time and checks for a spawner
    void IncreaseTime()
    {
        Time += 0.5f;

        // check every item in the timelist
        for (int i =0; i < TimeSpawned.Count; i++) { 
        
            if (TimeSpawned[i] == Time)
            {
                Spawner[i].SetActive(true);
            }
        }
    }
}
