using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    static public GameManager instace;
    [SerializeField] GameObject[] stages;
    int curStage = 0;

    private void Start()
    {
        if (instace == null)
        {
            instace = this;
        }
    }

    // ���� ���������� �̵�
    public void GoNextStage()
    {
        StartCoroutine(CHangeStage());
    }

    IEnumerator CHangeStage()
    {
        stages[curStage].SetActive(false);
        curStage++;

        if(curStage < stages.Length)
        {
            yield return new WaitForSeconds(0.5f);
            stages[curStage].SetActive(true);
        }
        else
        {
            // ���̻� ���� ���ٸ� �� ��ε�
            SceneManager.LoadScene("EscapeMaze");
        }
    }
}
