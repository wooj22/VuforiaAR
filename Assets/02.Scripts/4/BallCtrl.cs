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
        // Ball�� ���� ������
        firstPos = transform.localPosition;
    }

    void Update()
    {
        Physics.gravity = camTr.up * -0.5f;
    }

    // �̹����� �ν������� �߷� ����
    public void OnFound()
    {
        if(rb != null)
        {
            rb.isKinematic = false;
        }
    }

    // �̹��� �ν��� Ǯ���� ��
    public void OnLost()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    // Ball �� �浹
    private void OnCollisionEnter(Collision collision)
    {
        string objName = collision.gameObject.name;

        if(objName == "Item")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("������ ȹ��");
        }
        else if (objName == "Exit")
        {
            GameManager.instace.GoNextStage();
            Debug.Log("�������� Ŭ����");
        }
        else if (objName == "Trap")
        {
            Debug.Log("Ʈ���� �ɷȴ�!");
            transform.localPosition = firstPos;
        }
    }
}
