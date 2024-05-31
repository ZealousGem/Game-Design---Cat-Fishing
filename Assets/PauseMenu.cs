using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuD;




    // Start is called before the first frame update


    private void Awake()
    {



    }
    void Start()
    {
        //on start the pause menu is not activated
        



    }

    // Update is called once per frame
    void Update()
    {
        //if pause control tells main menu the pausemenu is true then the pause menu is activated
        


    }

    public void QuitGame()
    {
        Debug.Log("quits the game");
        Application.Quit();
    }
    //does not work
    public void ReloadLevel()
    {

        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menuD.SetActive(false);

    }
}