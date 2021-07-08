using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    private float m_timeToLive = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_timeToLive);
    }
}
