using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour {

    // Use this for initialization
    public float Time;
    private bool IsSet;

    // 2 lists, 1 is the time the other is the spawner
    public List<float> TimeSpawned;                     // NOTE this is set in the spawner script of each child
    public List<GameObject> Spawner;

    


	void Start () {
        // find all the spawners and find there time
        foreach(Transform i in transform)
        {
            Spawner.Add(i.gameObject);
            TimeSpawned.Add(i.gameObject.GetComponent<Spawners>().TimeUntilActive);
            i.gameObject.SetActive(false);
        }
        IsSet = true;
        // turn off this object and wait for active
        this.gameObject.SetActive(false);
	}

    void OnEnable()
    {
        if (IsSet) StartTimer();
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
