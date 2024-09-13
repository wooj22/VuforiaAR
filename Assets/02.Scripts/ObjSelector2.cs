using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjSelector2 : MonoBehaviour
{
    public AnchorBehaviour astronaut;
    public AnchorBehaviour drone;
    public AnchorBehaviour oxygentank;
    public AnchorBehaviour steam;
    ContentPositioningBehaviour cpb;

    void Start()
    {
        cpb = GetComponent<ContentPositioningBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cpb.AnchorStage = astronaut;
        }
        else if (Input.GetKeyDown("2"))
        {
            cpb.AnchorStage = drone;
        }
        else if (Input.GetKeyDown("3"))
        {
            cpb.AnchorStage = oxygentank;
        }
        else if (Input.GetKeyDown("4"))
        {
            cpb.AnchorStage = steam;
        }
    } 
}
