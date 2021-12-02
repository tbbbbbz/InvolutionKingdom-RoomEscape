using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverMenuToggle : MonoBehaviour
{
    public HealthBarController healthBarCtrl;

    private CanvasGroup canvasGroup;
    
    // Update is called once per frame
    void Update()
    {
        if (healthBarCtrl.health <= 0f)
        {
            /*
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            */

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;

            healthBarCtrl.health = 100f;

            Time.timeScale = 0f;
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
