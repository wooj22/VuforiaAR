using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard_BattleVer : MonoBehaviour
{
    public Transform camTr;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        // 카메라 방향으로 회전
        tr.LookAt(camTr.position);
    }
}
