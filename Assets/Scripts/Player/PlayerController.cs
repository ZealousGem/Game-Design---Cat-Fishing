using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 6f;
    private bool isAttacking=false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(horizontalInput * movementSpeed, verticalInput * movementSpeed, 0);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        if(Input.GetButtonDown("Fire 1"))
        {
            StartCoroutine(LightAttack());
        }
        if (Input.GetButtonDown("Fire 2"))
        {
            StartCoroutine(HeavyAttack());
        }
        

    }
    private IEnumerator LightAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        isAttacking=false;
    }
    private IEnumerator HeavyAttack()
    {
        isAttacking=true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
