using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMgr : MonoBehaviour
{
    Camera ARCam;

    void Start()
    {
        ARCam = GetComponent<Camera>();
    }

    void Update()
    {
        // 좌클릭시에 카메라에서 레이를 쏘고, 태양과 충돌했다면 캔버스 활성화
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = ARCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 지정 레이어와 충돌검사 (비트연산)
            if(Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                GameObject canvas = hit.transform.Find("Canvas").gameObject;
                canvas.SetActive(!canvas.activeSelf);
            }
        }
    }
}
