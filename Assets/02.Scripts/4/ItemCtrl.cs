using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 1, 0, Space.World);
    }
}
