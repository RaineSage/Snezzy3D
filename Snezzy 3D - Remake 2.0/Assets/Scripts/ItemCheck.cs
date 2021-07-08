using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    SAND,
    STOPWATCH,
    BONBON,
    WADDING,
}

public class ItemCheck : MonoBehaviour
{
    [SerializeField]
    private ItemType m_itemType;

    private Timer m_timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void ItemBehaviour()
    {
        switch (m_itemType)
        {
            case ItemType.SAND:
                AddSand();
                break;
            case ItemType.STOPWATCH:
                Stopwatch();
                break;
            case ItemType.BONBON:
                Bonbon();
                break;
            case ItemType.WADDING:
                Wadding();
                break;
            default:
                Debug.Log("Item wasn't assigned, somethig went wrong!");
                break;
        }
    }

    private void Wadding()
    {

    }

    private void Bonbon()
    {
        
    }

    private void Stopwatch()
    {
        m_timer.FreezeTime();
    }

    private void AddSand()
    {
        m_timer.AddSand();
    }
}
