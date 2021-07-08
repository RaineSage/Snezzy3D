using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaschineSwitcher : MonoBehaviour
{
    private Animator m_animator;
    private bool m_followCam = true;

    public bool m_isCornerRight = false;
    public bool m_isCornerLeft = false;
    public bool m_isCornerBackward = false;
    public bool m_isCornerForward = false;

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

        CornerSwitch();
       
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

    private void CornerSwitch()
    {
        if(m_isCornerRight)
        {
            m_animator.Play("CornerCam_Right");
        }
        else if (m_isCornerLeft)
        {
            m_animator.Play("CornerCam_Left");
        }
        else if (m_isCornerForward)
        {
            m_animator.Play("FollowCam");
        }
        else if (m_isCornerBackward)
        {
            m_animator.Play("BackwardCam");
        }
    }
}
