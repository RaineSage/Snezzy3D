using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_movementSpeed = 5f;
    [SerializeField]
    private float m_jumpForce = 5f;

    private bool m_isAttacking = false;

    private Rigidbody m_rigidbody;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

 

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        Vector3 direction = new Vector3 (- Input.GetAxisRaw("Horizontal"), 0f, - Input.GetAxisRaw("Vertical"));
        direction = direction.normalized * m_movementSpeed;

        direction.y = m_rigidbody.velocity.y;
        m_rigidbody.velocity = direction;

        direction.y = 0;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.VelocityChange);
        }
    }

    private void Attack()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("ATTTAAAAAAAAAAAAACK");
            m_isAttacking = true;
        }
        m_isAttacking = false;
    }

    private void OnCollisionEnter(Collision _col)
    {
       if(_col.gameObject.tag == "Enemy")
       {
            if(m_isAttacking == true)
            {
                _col.gameObject.SetActive(false);
                Debug.Log("Enemy was hit!!");
            }
       }
    }
}
