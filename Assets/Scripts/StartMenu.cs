using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Startbutton()
    {
        //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Jordan Testing");
        AudioManager.instance.SFX("Button");

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        AudioManager.instance.SFX("Button");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
