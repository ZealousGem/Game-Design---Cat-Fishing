using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

   public GameObject start;
   public GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        settings.SetActive(false);
        AudioManager.PlayMusic("Waves");
        AudioManager.instance.musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingsMenu()
    {
        settings.SetActive(true);
        AudioManager.instance.SFX("Button");
        start.SetActive(false);
    }

    public void BackSettings()
    {
        settings.SetActive(false);
        AudioManager.instance.SFX("Button");
        start.SetActive(true);
    }
}
