using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] public TrackObj objPlayer;
    [SerializeField] public TrackObj objMonster;
    [SerializeField] public Text stateMsg;
    [SerializeField] public GameObject objStartBtn;
    [SerializeField] public GameObject objReplayBtn;

    public GameState gameState = GameState.Ready;


    private void Update()
    {
        GameStartCondition();
    }


    // 게임 시작 조건 검사
    private void GameStartCondition()
    {
        if(gameState == GameState.Ready)
        {
            if (objPlayer.isDetected && objMonster.isDetected)
            {
                if (objStartBtn.activeSelf == false)
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "시작 버튼을 눌러주세요";
                }
            }
            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "카드를 인식시켜주세요";
                }
            }
        }
    }


    // 게임 시작
    public void OnClickStart()
    {
        gameState = GameState.Battle;
        stateMsg.text = "주사위로 선공 정하기";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }


    // 주사위 던지기
    IEnumerator RollTheDices()
    {
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i=0; i<30; i++)
        {
            dicePlayer = Random.Range(0, 6) + 1;
            diceMonster = Random.Range(0, 6) + 1;

            objPlayer.infoTM.text = "주사위 : " + dicePlayer;
            objMonster.infoTM.text = "주사위 : " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }


        // 선공 결정
        if(dicePlayer> diceMonster)
        {
            stateMsg.text = objPlayer.objName + "선공";
            StartCoroutine(StartBattle(objPlayer, objMonster));            
        }
        else if(dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + "선공";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "무승부! 다시하기";
            yield return new WaitForSeconds(1f);
            StartCoroutine(RollTheDices());
        }
    }


    // 배틀 진행
    IEnumerator StartBattle(TrackObj firstTurn, TrackObj secondTurn)
    {
        yield return new WaitForSeconds(1f);

        int firstHP = firstTurn.hp;
        int secondHP = secondTurn.hp;

        firstTurn.infoTM.text = firstTurn.objName + "\n HP : " + firstHP;
        secondTurn.infoTM.text = secondTurn.objName + "\n HP : " + secondHP;

        while (true)
        {
            //턴제 1
            stateMsg.text = firstTurn.objName + " 공격";

            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            secondHP -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP : " + secondHP;

            if(secondHP <= 0)
            {
                stateMsg.text = firstTurn.objName + "이(가) 승리하였습니다.";

                yield return new WaitForSeconds(1f);
                objReplayBtn.SetActive(true);
                break;
            }

            //턴제 2
            stateMsg.text = secondTurn.objName + " 공격";

            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            firstHP -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP : " + firstHP;

            if (firstHP <= 0)
            {
                stateMsg.text = secondTurn.objName + "이(가) 승리하였습니다.";

                yield return new WaitForSeconds(1f);
                objReplayBtn.SetActive(true);
                break;
            }
        }
    }

    // 리플레이
    public void OnclickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "카드를 인식시켜주세요";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);
    }
}

// 게임 상태 Enum
public enum GameState
{
    Ready,
    Battle,
    Result
}
