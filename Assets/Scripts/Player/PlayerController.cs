using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 6f;
    public float jumpforce = 5f;
    public Text Depth;
    private int tracker;
    private float Sharks = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Display(verticalInput);
       

        rb.velocity = new Vector3(horizontalInput * movementSpeed, verticalInput * movementSpeed, 0);

    }

     void Display(float verticalInput)
    {
        Sharks += (verticalInput * -1) * Time.deltaTime;
        

        if ((int)Sharks > 0)
        {
            tracker = (int)Sharks;
            Depth.text = tracker.ToString() + "m";
        }

        else
        {
            tracker = 0;
            Depth.text = tracker.ToString() + "m";
        }
        
    }
}
