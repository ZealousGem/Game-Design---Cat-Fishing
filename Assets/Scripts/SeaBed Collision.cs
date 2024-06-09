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
            Debug.Log(CameraManager.confirm);
            
        }
    }
}
