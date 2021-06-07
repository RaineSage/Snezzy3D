using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text m_timeTxt;
    public float m_timeLeft = 60f;
    public bool m_isTimeRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        m_isTimeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isTimeRunning)
        {
            ShowTime();
            if(m_timeLeft > 0)
            {
                m_timeLeft -= Time.deltaTime;
            }
            else
            {
                m_timeLeft = 0;
                m_isTimeRunning = false;
            }
        }
    }

    private void ShowTime()
    {
        m_timeTxt.text = m_timeLeft.ToString();
    }
}
