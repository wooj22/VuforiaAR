using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    [SerializeField] Transform camTr;
    [SerializeField] Rigidbody rb;
    Vector3 firstPos;

    private void Start()
    {
        // Ball의 시작 포지션
        firstPos = transform.localPosition;
    }

    void Update()
    {
        Physics.gravity = camTr.up * -0.5f;
    }

    // 이미지를 인식했을때 중력 적용
    public void OnFound()
    {
        if(rb != null)
        {
            rb.isKinematic = false;
        }
    }

    // 이미지 인식이 풀렸을 때
    public void OnLost()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    // Ball 의 충돌
    private void OnCollisionEnter(Collision collision)
    {
        string objName = collision.gameObject.name;

        if(objName == "Item")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("아이템 획득");
        }
        else if (objName == "Exit")
        {
            GameManager.instace.GoNextStage();
            Debug.Log("스테이지 클리어");
        }
        else if (objName == "Trap")
        {
            Debug.Log("트랩에 걸렸다!");
            transform.localPosition = firstPos;
        }
    }
}
