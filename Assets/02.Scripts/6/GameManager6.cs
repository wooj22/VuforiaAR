using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager6 : MonoBehaviour
{
    static public GameManager6 instance;

    [SerializeField] public GameState6 gameState = GameState6.Ready;
    [SerializeField] public GameObject ballObj; 
    [SerializeField] Text numText;
    [SerializeField] Text stateText;
    [SerializeField] GameObject replayBtn;
    [SerializeField] int maxCatch;

    [SerializeField] ParticleSystem failEff;
    [SerializeField] ParticleSystem successEff;

    private int numCatch = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            numText.text = "포획수 " + numCatch + "/" + maxCatch;
        }
    }

    private void Start()
    {
        ballObj.gameObject.SetActive(false);
    }

    public void AddCatch()
    {
        ++numCatch;
        numText.text = "포획수 " + numCatch + "/" + maxCatch;

        if(numCatch >= maxCatch)
        {
            PopupMsg("모든 몬스터를 잡았습니다!", 3);

            gameState = GameState6.End;
            replayBtn.SetActive(true);
        }
        else
        {
            PopupMsg("잡았습니다!", 2);
        }
    }

    public void PopupMsg(string msg, int time)
    {
        StartCoroutine(ShowMsg(msg, time));
    }

    IEnumerator ShowMsg(string msg, int time)
    {
        stateText.text = msg;
        yield return new WaitForSeconds(time);
        stateText.text = "";
    }

    public void OnDetected()
    {
        if(gameState == GameState6.Ready)
        {
            numText.text = "포획수 " + numCatch + "/" + maxCatch;
            gameState = GameState6.Begin;
            ballObj.SetActive(true);
            PopupMsg("드래그해서 볼을 던지세요!", 2);
        }
    }

    public void PlayEffect(bool sucess, Vector3 pos)
    {
        ParticleSystem ps = sucess ? Instantiate(successEff) : Instantiate(failEff);
        ps.transform.position = pos;
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene("CatchMon");
    }

    // 게임 상태 enum
    public enum GameState6
    {
        Ready,
        Begin,
        End
    }
}
