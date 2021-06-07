using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool m_IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReloadGame();

        if(m_IsDead == true)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    

    private void ReloadGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("BathroomLevel");
        }
    }
}
