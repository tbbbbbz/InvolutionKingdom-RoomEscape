using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuToggle : MonoBehaviour
{
    // [SerializeField] GameObject pauseMenu;

    private CanvasGroup canvasGroup;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            /*
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            */

            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;

                Time.timeScale = 1f;
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;

                Time.timeScale = 0f;
            }
        }
    }

    private void Awake()
    {
        // pauseMenu.SetActive(false);

        canvasGroup = GetComponent<CanvasGroup>();

        /*
        if (canvasGroup == null)
        {
            Debug.LogError("Do not find the component you are looking for.");
        }
        */
    }
   
}
