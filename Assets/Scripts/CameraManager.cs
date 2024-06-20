using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cam;
   public GameObject Maincam;
    public GameObject airwall;
    public GameObject airwall2;
    public static bool confirm;
    public UnityEvent camerachange;
    void Start()
    {
        cam.SetActive(true);
        airwall.SetActive(false);
        airwall2.SetActive(true);
        Debug.Log(confirm);
        AudioManager.PlayMusic("Waves");
        AudioManager.instance.musicSource.Play();
       
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        camerachange.Invoke();
    }

    public void OnBecameInvisible()
    {
        if (SeaBedCollision.confirm)
        {
            cam.SetActive(false);
            Maincam.SetActive(true);
            airwall.SetActive(true);
            airwall2.SetActive(false);
        }

        else
        {
            cam.SetActive(true);
            Maincam.SetActive(false);
            airwall.SetActive(false);
            airwall2.SetActive(true);
        }
    }


}
