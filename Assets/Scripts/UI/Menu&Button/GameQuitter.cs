using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            QuitGame();
        }
            
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        // pauseMenu.SetActive(false);
#else
         Application.Quit();
#endif
    }
}
