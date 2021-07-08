using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject m_win;
    [SerializeField]
    private GameObject m_loose;
    [SerializeField]
    private GameObject m_noTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.m_IsDead == true)
        {
            m_win.gameObject.SetActive(false);

            m_loose.gameObject.SetActive(true);
        }

        if(GameManager.m_winner == true)
        {
            m_loose.gameObject.SetActive(false);

            m_win.gameObject.SetActive(true);
        }

        if(GameManager.m_noTimeLeft == true)
        {
            m_win.gameObject.SetActive(false);
            m_loose.gameObject.SetActive(false);

            m_noTimeLeft.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            GameManager.m_IsDead = false;
            GameManager.m_winner = false;
            GameManager.m_noTimeLeft = false;
        }
    }
}
