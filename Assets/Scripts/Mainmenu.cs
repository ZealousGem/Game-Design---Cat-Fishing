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
        AudioManager.instance.SFX("Button");
        SeaBedCollision.confirm = false;
        Time.timeScale = 1f;
        AudioManager.instance.musicSource.UnPause();


    }
    public void QuitGame()
    {
        Debug.Log("quits the game");
        AudioManager.instance.SFX("Button");
        SceneManager.LoadScene("Start");
        SeaBedCollision.confirm = false;
        Time.timeScale = 1f;
       
    }
    public void Continue()
    {
        pauseControl.BridgingMenuContinue();
        AudioManager.instance.SFX("Button");
        AudioManager.instance.musicSource.UnPause();
    }

}
