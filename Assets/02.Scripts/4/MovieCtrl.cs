using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class MovieCtrl : MonoBehaviour
{
    [SerializeField] VideoPlayer vp;
    [SerializeField] ParticleSystem ps;

    void Update()
    {
        // ���콺 ��Ŭ���� play, pause
        if (Input.GetMouseButton(0))
        {
            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
            }
        }
        else if (Input.GetMouseButton(1))
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }
        }
    }

    // �̹��� �νĽ� play
    public void OnFound()
    {
        vp.Play();
        ps.Play();
    }

    // �̹��� �ν�dl Ǯ���� pause
    public void OnLost()
    {
        vp.Pause();
        ps.Stop();
    }
}
