using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScipts : MonoBehaviour {

    /// <summary>
    /// this script will hold all of the players resources and main game functions
    /// </summary>
    /// 

    public int Gems;
    public int SlimeBalls;

    private GameObject GemHolder;
    private GameObject SlimeballHolder;
    
	void Start () {
        // find varibles
        GemHolder = GameObject.Find("GemText").gameObject;
        SlimeballHolder = GameObject.Find("SlimeBallText").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //update UI
        GemHolder.GetComponent<TextMeshProUGUI>().text = Gems.ToString();
        SlimeballHolder.GetComponent<TextMeshProUGUI>().text = SlimeBalls.ToString();


    }
}
