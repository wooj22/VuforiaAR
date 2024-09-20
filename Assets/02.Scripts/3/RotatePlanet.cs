using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotatePlanet : MonoBehaviour
{
    public Transform targetTr;  // ȸ���߽�
    public float rotSpeed;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }


    void Update()
    {
        // ����
        tr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * rotSpeed);
    }

    public void OnTargetFound()
    {
        gameObject.SetActive(true);
        Debug.Log("Ÿ�� �̹��� �߰�");
    }

    public void OnTargetLost()
    {
        gameObject.SetActive(false);
        Debug.Log("Ÿ�� �̹��� ����");
    }

}
