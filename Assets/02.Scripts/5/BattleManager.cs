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


    // ���� ���� ���� �˻�
    private void GameStartCondition()
    {
        if(gameState == GameState.Ready)
        {
            if (objPlayer.isDetected && objMonster.isDetected)
            {
                if (objStartBtn.activeSelf == false)
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "���� ��ư�� �����ּ���";
                }
            }
            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "ī�带 �νĽ����ּ���";
                }
            }
        }
    }


    // ���� ����
    public void OnClickStart()
    {
        gameState = GameState.Battle;
        stateMsg.text = "�ֻ����� ���� ���ϱ�";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }


    // �ֻ��� ������
    IEnumerator RollTheDices()
    {
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i=0; i<30; i++)
        {
            dicePlayer = Random.Range(0, 6) + 1;
            diceMonster = Random.Range(0, 6) + 1;

            objPlayer.infoTM.text = "�ֻ��� : " + dicePlayer;
            objMonster.infoTM.text = "�ֻ��� : " + diceMonster;

            yield return new WaitForSeconds(0.1f);
        }


        // ���� ����
        if(dicePlayer> diceMonster)
        {
            stateMsg.text = objPlayer.objName + "����";
            StartCoroutine(StartBattle(objPlayer, objMonster));            
        }
        else if(dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + "����";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "���º�! �ٽ��ϱ�";
            yield return new WaitForSeconds(1f);
            StartCoroutine(RollTheDices());
        }
    }


    // ��Ʋ ����
    IEnumerator StartBattle(TrackObj firstTurn, TrackObj secondTurn)
    {
        yield return new WaitForSeconds(1f);

        int firstHP = firstTurn.hp;
        int secondHP = secondTurn.hp;

        firstTurn.infoTM.text = firstTurn.objName + "\n HP : " + firstHP;
        secondTurn.infoTM.text = secondTurn.objName + "\n HP : " + secondHP;

        while (true)
        {
            //���� 1
            stateMsg.text = firstTurn.objName + " ����";

            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            secondHP -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP : " + secondHP;

            if(secondHP <= 0)
            {
                stateMsg.text = firstTurn.objName + "��(��) �¸��Ͽ����ϴ�.";

                yield return new WaitForSeconds(1f);
                objReplayBtn.SetActive(true);
                break;
            }

            //���� 2
            stateMsg.text = secondTurn.objName + " ����";

            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            firstHP -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP : " + firstHP;

            if (firstHP <= 0)
            {
                stateMsg.text = secondTurn.objName + "��(��) �¸��Ͽ����ϴ�.";

                yield return new WaitForSeconds(1f);
                objReplayBtn.SetActive(true);
                break;
            }
        }
    }

    // ���÷���
    public void OnclickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "ī�带 �νĽ����ּ���";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);
    }
}

// ���� ���� Enum
public enum GameState
{
    Ready,
    Battle,
    Result
}
