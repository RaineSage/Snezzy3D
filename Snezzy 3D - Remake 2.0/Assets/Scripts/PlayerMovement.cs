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
    private bool m_isGrounded = false;
    private bool m_isWalking = false;
    private bool m_isIdle = false;
    private bool m_isJumping = false;

    private Rigidbody m_rigidbody;
    private Animator m_animator;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(m_isWalking)
        {
            m_animator.SetBool("isWalking", true);
            m_animator.SetBool("isIdle", false);
        }
        else if(!m_isWalking && !m_isJumping && !m_isAttacking)
        {
            m_animator.SetBool("isIdle", true);
            m_animator.SetBool("isWalking", false);
            m_animator.SetBool("isAttacking", false);
            m_animator.SetBool("isJumping", false);
        }

        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        Vector3 direction = new Vector3 (- Input.GetAxisRaw("Horizontal"), 0f, - Input.GetAxisRaw("Vertical"));
        direction = direction.normalized * m_movementSpeed;

        m_isWalking = true;

        direction.y = m_rigidbody.velocity.y;
        m_rigidbody.velocity = direction;


        direction.y = 0;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            m_isJumping = true;
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.VelocityChange);
            m_isGrounded = false;
        }

        if(!m_isGrounded)
        {
            m_isJumping = false;
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

    private void OnCollisionStay(Collision _col)
    {
        m_isGrounded = true;
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
