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
        // ī�޶� �������� ȸ��
        tr.LookAt(camTr.position);
    }
}
