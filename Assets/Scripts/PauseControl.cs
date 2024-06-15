using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    

    private CanvasGroup pausePanelCanvasGroup;



    void Start()
    {
        

        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();

    }
    private void Awake()
    {
        //does this reset the score on a new game
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                TogglePausePanel();
                //tells the gamemanager to resume the game


            }
            else
            {
                Time.timeScale = 0f;
                TogglePausePanel();
                //tells the gamemanager to pause the game


            }

        }




    }
    public void BridgingMenuContinue()
    {
        Time.timeScale = 1f;
        TogglePausePanel();


    }
   
    public void TogglePausePanel()
    {
        //find it using the tag
        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");

        //gets the componenet
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();
        if (pausePanelCanvasGroup == null)
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot toggle visibility.");
            return;
        }
        //switches between true and false

        if (pausePanelCanvasGroup.alpha == 0f)
        {
            ShowPauseMenu();
        }
        else
        {
            HidePauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            //sets the colout to white
            pausePanelCanvasGroup.alpha = 1f;
            //you can interact with it
            pausePanelCanvasGroup.interactable = true;
            pausePanelCanvasGroup.blocksRaycasts = true;
            Debug.Log("Pause menu shown.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot show pause menu.");
        }
    }

    public void HidePauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            //sets the colout to transparent
            pausePanelCanvasGroup.alpha = 0f;
            //you can not interact with it 
            pausePanelCanvasGroup.interactable = false;
            pausePanelCanvasGroup.blocksRaycasts = false;
            Debug.Log("Pause menu hidden.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot hide pause menu.");
        }
    }
}
