using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBedCollision : MonoBehaviour
{
    public static bool confirm = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraManager.confirm = true;
            confirm = true;
           // AudioManager.instance.SFX("");
            Debug.Log(CameraManager.confirm);
            AudioManager.instance.SFX("Splash");
            AudioManager.instance.musicSource.Stop();
            AudioManager.PlayMusic("Ocean");
            AudioManager.instance.musicSource.Play();

        }
    }
}
