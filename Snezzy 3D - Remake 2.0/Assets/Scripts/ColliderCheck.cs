using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField]
    private int m_healthCount = 3;

    [SerializeField]
    public TMP_Text m_healthText;

    private void Update()
    {
        ShowHealth();
    }

    private void ShowHealth()
    {
        m_healthText.text = m_healthCount.ToString();
    }

    
    private void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "Enemy")
        {
            Debug.Log("Player took Damage!");

            if(m_healthCount > 1)
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
    }
}