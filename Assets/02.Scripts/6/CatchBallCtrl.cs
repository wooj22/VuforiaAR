using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBallCtrl : MonoBehaviour
{
    [SerializeField] Transform camTr;
    private Rigidbody rb;
    private AudioSource ads;
    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ads = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (rb.isKinematic == false)
            return;

        // 카메라 앞에 위치 업데이트
        Vector3 offset = camTr.forward * 0.4f - camTr.up * 0.07f;
        transform.position = camTr.position + offset;
        transform.rotation = camTr.rotation;

        // 몬스터볼 던지기
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 deltaPos = mousePos - Input.mousePosition;
            float len = deltaPos.magnitude;

            rb.isKinematic = false;
            rb.AddForce((camTr.forward + camTr.up).normalized * len * 0.3f);
            rb.AddForce(-deltaPos.y, deltaPos.x, 0);

            /* 사운드 재생
            if(GameManager6.instance.gameState == GameState6.Begin)
            {
                ads.Play();
            }
            */

            Invoke("ResetBall", 2);
        }
    }

    // 몬스터볼 원위치
    private void ResetBall()
    {
        gameObject.SetActive(true);

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // 몬스터볼 맞추기
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
