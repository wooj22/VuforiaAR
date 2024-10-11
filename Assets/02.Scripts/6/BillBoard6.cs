using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BillBoard6 : MonoBehaviour
{
    [SerializeField] Transform camTr;

    private void LateUpdate()
    {
        transform.LookAt(camTr.position, Vector3.up);
    }
}
