using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardProperties : MonoBehaviour
{

    /// <summary>
    /// this stores the properties and functions hazards can use
    /// </summary>
    /// 
    public GameObject Owner;
    public bool DoNotDestroy;
    public bool check;

    public bool FallenObjectLanded;
    private float FallenObjectHeight;
    private float FallenObjectSpeed;
    private GameObject FallenObjectShadow;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // this function is used by hazards that are classified as falling hazards
    // the basic is it will create a "Shadow" for the object and will make
    // the object fall from the sky to the playing field

    public void FallingObject(float Speed)
    {
        // find the shadow sprite and create
        GameObject Shadow = Resources.Load("Prefabs/Shadow") as GameObject;
        FallenObjectShadow = Instantiate(Shadow, Vector3.zero, Quaternion.identity);

        // placing the shadow
        FallenObjectShadow.transform.position = Owner.transform.position;                       // this line may cause a issue where the item will be incorrect place as a spawner moves

        // place obect in air
        this.gameObject.transform.position += new Vector3(0, 10, 0);
        FallenObjectHeight = 10;
        FallenObjectSpeed = Speed;

        // make the boulder fall
        Invoke("Fall", Speed);



    }

    // this is used with the function falling object to move the object down towards the "Shadow"
    void Fall()
    {
        this.gameObject.transform.position -= new Vector3(0, 0.1f, 0);
        FallenObjectHeight -= 0.1f;

        // when the height is smaller then 0 (onshadown)
        if (FallenObjectHeight < 0)
        {
            Destroy(FallenObjectShadow);
            FallenObjectLanded = true;                          // this will allow other scripts to identify when the object has landed
        } else
        {
            Invoke("Fall", FallenObjectSpeed); //reinvoke
        }

    }

}
