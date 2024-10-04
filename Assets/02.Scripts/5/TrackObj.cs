using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObj : MonoBehaviour
{
    [SerializeField] public Animation objAni;
    [SerializeField] public TextMesh infoTM;
    [SerializeField] public string objName;
    [SerializeField] public int hp;
    [SerializeField] public int atk;
    [SerializeField] public int def;

    public bool isDetected;

    private void Start()
    {
        InitInfo();    
    }

    public void InitInfo()
    {
        infoTM.text = objName + "\n HP : " + hp;
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }

    public float PlayAnimation(string clipName)
    {
        objAni.Play(clipName);
        return objAni.GetClip(clipName).length;
    }
}
