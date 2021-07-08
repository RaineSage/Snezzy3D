using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool m_IsDead = false;
    public static bool m_noTimeLeft = false;
    public static bool m_winner = false;

    // Update is called once per frame
    void Update()
    {
        ReloadGame();
        Quit();

        if(m_IsDead == true || m_winner == true || m_noTimeLeft)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void Quit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            m_winner = false;
            m_IsDead = false;
            m_noTimeLeft = false;
        }
    }
    

    private void ReloadGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("BathroomLevel");
            m_winner = false;
            m_IsDead = false;
            m_noTimeLeft = false;
        }
    }
}
