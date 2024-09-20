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
        // ��Ŭ���ÿ� ī�޶󿡼� ���̸� ���, �¾�� �浹�ߴٸ� ĵ���� Ȱ��ȭ
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = ARCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���� ���̾�� �浹�˻� (��Ʈ����)
            if(Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                GameObject canvas = hit.transform.Find("Canvas").gameObject;
                canvas.SetActive(!canvas.activeSelf);
            }
        }
    }
}
