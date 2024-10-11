using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] float hitRate;
    [SerializeField] public float damageRate;
    [SerializeField] public float catchRate;
    [SerializeField] Image imgHP;

    private Animation ani;

    private void Start()
    {
        ani = GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Ball")
        {
            return;
        }

        // 몬스터볼에 닿았을 때
        if(Random.Range(0.0f, 1.0f) < hitRate)
        {
            imgHP.fillAmount -= damageRate;
            if(imgHP.fillAmount < 0.001f)
            {
                // 몬스터 잡기
                if(Random.Range(0.0f, 1.0f) < catchRate)
                {
                    GameManager6.instance.AddCatch();
                }
                else
                {
                    GameManager6.instance.PopupMsg("놓쳤습니다..", 2);
                    GameManager6.instance.PlayEffect(false, collision.contacts[0].point);
                }

                // 몬스터 리스폰
                gameObject.SetActive(false);
                Invoke("ChangePos", Random.Range(2, 5));
                imgHP.fillAmount = 1;
            }
            else
            {
                GameManager6.instance.PopupMsg("명중입니다.", 2);
                GameManager6.instance.PlayEffect(true, collision.contacts[0].point);
            }
        }
        else
        {
            GameManager6.instance.PopupMsg("막혔습니다!", 2);
            StartCoroutine(PlayAni());
        }
    }

    // 리스폰
    private void ChangePos()
    {
        gameObject.SetActive(true);

        Vector3 pos;
        pos.x = Random.Range(-0.5f, 0.5f);
        pos.y = 0;
        pos.z = Random.Range(-0.5f, 0.5f);

        transform.localPosition = pos;
    }

    // 공격 애니메이션
    IEnumerator PlayAni()
    {
        ani.Play("Attack");
        float aniLen = ani.GetClip("Attack").length;
        yield return new WaitForSeconds(aniLen);
        ani.Play("Idle");
    }
}
