using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private int m_healthCount = 3;

    [SerializeField]
    private TMP_Text m_healthText;

    [SerializeField]
    private Image m_healthImg;

    [SerializeField]
    private Sprite m_fullHealth;

    [SerializeField]
    private Sprite m_twoHealth;

    [SerializeField]
    private Sprite m_oneHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealthPic();
        ShowHealth();
    }

    public void TakeDamage()
    {
        Debug.Log("Player took Damage!");

        if (m_healthCount > 1)
        {
            m_healthCount -= 1;
        }
        else if (m_healthCount == 1)
        {
            m_healthCount = 0;
            Debug.Log("Player has died!");
            GameManager.m_IsDead = true;
        }
    }

    private void ShowHealthPic()
    {
        if(m_healthCount == 3)
        {
            m_healthImg.sprite = m_fullHealth;
        }
        else if(m_healthCount == 2)
        {
            m_healthImg.sprite = m_twoHealth;
        }
        else if (m_healthCount == 1)
        {
            m_healthImg.sprite = m_oneHealth;
        }
    }

    private void ShowHealth()
    {
        m_healthText.text = m_healthCount.ToString();
    }
}
