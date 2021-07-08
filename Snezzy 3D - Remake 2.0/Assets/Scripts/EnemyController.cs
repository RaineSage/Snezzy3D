using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyType
{
    WALKER,
    SHOOTER,
}


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float m_radius = 5f;
    [SerializeField]
    private float m_distance;

    [SerializeField]
    private float m_fireRate;
    [SerializeField]        
    private float m_nextShot;

    [SerializeField]
    private EnemyType m_enemyType;
    [SerializeField]
    private GameObject m_target;
    [SerializeField]
    private GameObject m_bullet;
    [SerializeField]
    private GameObject m_bulletSpawnPoint;


    private NavMeshAgent m_meshAgent;



    void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();

        m_fireRate = 1f;
        m_nextShot = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        // check distance between Enemy and Player (target)
        m_distance = Vector3.Magnitude(m_target.transform.position - transform.position);

        AIBehaviour();
    }

    private void AIBehaviour()
    {
        if (m_enemyType == EnemyType.WALKER)
        {
            Walker();
        }
        else if (m_enemyType == EnemyType.SHOOTER)
        {
            Shooter();
        }
    }

    private void Walker()
    {
        // if Player inside radius
        if(m_distance <= m_radius)
        {
            m_meshAgent.SetDestination(m_target.transform.position);
        }
    }

    private void Shooter()
    {
          if (Time.time > m_nextShot)
          {
              Instantiate(m_bullet, m_bulletSpawnPoint.transform.position, Quaternion.identity);
              m_nextShot = Time.time + m_fireRate;
          }
    }

}
