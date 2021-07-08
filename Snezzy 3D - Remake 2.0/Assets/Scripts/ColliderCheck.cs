using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderCheck : MonoBehaviour
{

    private ItemCheck m_itemCheck;

    [SerializeField]
    private HealthBar m_healthBar;

    private void OnCollisionEnter(Collision _col)
    {
        if(_col.gameObject.tag == "Enemy")
        {
            m_healthBar.TakeDamage();
        }

        if (_col.gameObject.tag == "HitBox")
        {
            Debug.Log("Player Killed Walker!");

            _col.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "Finish")
        {
            GameManager.m_winner = true;
        }

        if(_col.gameObject.tag == "Bullet")
        {
            m_healthBar.TakeDamage();
        }

        //if(_col.gameObject.tag == "Item")
        //{
        //    m_itemCheck.ItemBehaviour();
        //}
    }

    
}
