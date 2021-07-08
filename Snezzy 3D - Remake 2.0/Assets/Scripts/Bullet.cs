using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 1.5f;

    [SerializeField]
    private GameObject m_target;

    private Rigidbody m_rigidbody;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        m_rigidbody.AddForce(Vector3.forward * m_moveSpeed, ForceMode.VelocityChange);
    }
}
