using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timer;
    public float TimeLeft = 180f;
    private float delay = 1;
    public TextManage GOTextWin;

    public void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            TimeGoingDown(1);
            delay = 1;
        }

        if (TimeLeft == 0)
        {
            GOTextWin.AppearText();
        }

    }

    public void TimeGoingDown(float time)
    {
        TimeLeft -= time;
        timer.fillAmount = TimeLeft / 180;
    }
}
