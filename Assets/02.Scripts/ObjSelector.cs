using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjSelector : MonoBehaviour
{
    public AnchorBehaviour lancejun;
    public AnchorBehaviour zombie;
    ContentPositioningBehaviour cpb;

    void Start()
    {
        cpb = GetComponent<ContentPositioningBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cpb.AnchorStage = lancejun;
        }
        else if (Input.GetKeyDown("2"))
        {
            cpb.AnchorStage = zombie;
        }
    } 
}
