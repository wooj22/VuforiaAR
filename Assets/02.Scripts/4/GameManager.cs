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

    // 다음 스테이지로 이동
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
            // 더이상 씬이 없다면 씬 재로드
            SceneManager.LoadScene("EscapeMaze");
        }
    }
}
