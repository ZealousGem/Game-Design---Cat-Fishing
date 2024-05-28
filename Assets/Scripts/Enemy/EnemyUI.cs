using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    // Update is called once per frame
    float counter;
    private void Start()
    {
        UI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
           UI.SetActive(true);
        }

    }


   
}
