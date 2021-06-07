using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaschineSwitcher : MonoBehaviour
{
    private Animator m_animator;
    private bool m_followCam = true;


    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        if(m_followCam)
        {
            m_animator.Play("CrouchCam");
        }
        else
        {
            m_animator.Play("FollowCam");
        }
        m_followCam = !m_followCam;
    }
}
