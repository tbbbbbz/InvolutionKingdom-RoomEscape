using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResumer : MonoBehaviour
{
    public CanvasGroup pauseCanvasCanvasGroup;

    public void ResumeGame()
    {
        // pauseMenu.SetActive(false);
        // Time.timeScale = 1f;

        if (pauseCanvasCanvasGroup.interactable)
        {
            pauseCanvasCanvasGroup.interactable = false;
            pauseCanvasCanvasGroup.blocksRaycasts = false;
            pauseCanvasCanvasGroup.alpha = 0f;

            Time.timeScale = 1f;
        }
    }
}
