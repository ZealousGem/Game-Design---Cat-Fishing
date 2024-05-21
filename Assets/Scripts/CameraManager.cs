using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cam;
   public GameObject Maincam;
    public GameObject airwall;
    public static bool confirm;
    void Start()
    {
        cam.SetActive(true);
        airwall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (confirm)
        {
            cam.SetActive(false);
            Maincam.SetActive(true);
            airwall.SetActive(true);
        }
    }
}
