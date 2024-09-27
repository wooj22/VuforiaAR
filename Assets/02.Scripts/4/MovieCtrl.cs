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
        // 마우스 좌클릭시 play, pause
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

    // 이미지 인식시 play
    public void OnFound()
    {
        vp.Play();
        ps.Play();
    }

    // 이미지 인식dl 풀리면 pause
    public void OnLost()
    {
        vp.Pause();
        ps.Stop();
    }
}
