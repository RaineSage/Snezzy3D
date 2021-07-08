using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text m_timeTxt;
    public float m_timeLeft = 60f;
    public bool m_isTimeRunning = false;

    [SerializeField]
    private float m_addSandTime = 15f;

    [SerializeField]
    private float m_freezeTime = 10f;

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

        if(!m_isTimeRunning)
        {
            GameManager.m_noTimeLeft = true;
        }
    }

    private void ShowTime()
    {
        m_timeTxt.text = m_timeLeft.ToString("00");
    }

    public void AddSand()
    {
        m_timeLeft = m_addSandTime;
    }

    public IEnumerable FreezeTime()
    {
        m_isTimeRunning = false;
        while(!m_isTimeRunning)
        {
            yield return new WaitForSeconds(10f);
            m_isTimeRunning = true;
        }
    }
}
