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
    public static bool confirm;
    public UnityEvent camerachange;
    void Start()
    {
        cam.SetActive(true);
        airwall.SetActive(false);
        Debug.Log(confirm);
       
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
        }

        else
        {
            cam.SetActive(true);
            Maincam.SetActive(false);
            airwall.SetActive(false);
        }
    }


}
