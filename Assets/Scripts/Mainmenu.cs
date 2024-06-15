using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    private PauseControl pauseControl;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        pauseControl = player.GetComponent<PauseControl>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SeaBedCollision.confirm = false;
        Time.timeScale = 1f;


    }
    public void QuitGame()
    {
        Debug.Log("quits the game");
        Application.Quit();
    }
    public void Continue()
    {
        pauseControl.BridgingMenuContinue();
        
    }

}
