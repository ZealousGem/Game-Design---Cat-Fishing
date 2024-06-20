using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.SFX("Cat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        AudioManager.instance.SFX("Button");
        // Application.Quit();
        SceneManager.LoadScene("Start");
        SeaBedCollision.confirm = false;
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene("Jordan Testing");
        AudioManager.instance.SFX("Button");
        SeaBedCollision.confirm = false;
        //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
