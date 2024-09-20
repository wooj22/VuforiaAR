using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RotatePlanet : MonoBehaviour
{
    public Transform targetTr;  // 회전중심
    public float rotSpeed;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }


    void Update()
    {
        // 자전
        tr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * rotSpeed);
    }

    public void OnTargetFound()
    {
        gameObject.SetActive(true);
        Debug.Log("타겟 이미지 발견");
    }

    public void OnTargetLost()
    {
        gameObject.SetActive(false);
        Debug.Log("타겟 이미지 없음");
    }

}
