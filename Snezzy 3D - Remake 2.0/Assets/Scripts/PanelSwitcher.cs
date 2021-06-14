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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
