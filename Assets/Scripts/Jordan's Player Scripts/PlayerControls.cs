using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float movementSpeed = 6f;
    public float jumpforce = 5f;
    public Text Depth;
    private int tracker;
    private float Sharks = 0f;

    public Animator catMovement;

    public GameObject lightAttackHitbox;
    public GameObject heavyAttackHitbox;

    

    private bool isAttacking = false;

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
        if (Input.GetAxis("Horizontal")<0f)
        {
            transform.localScale = new Vector3(-1f,1f, 1f);
        }
        else if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);


        }

        if (Input.GetKeyDown(KeyCode.F)) // Default key for "Fire1" is left ctrl or mouse0
        {
            StartCoroutine(LightAttack());
        }

        // Handle heavy attack input
        if (Input.GetKeyDown(KeyCode.Q)) // Default key for "Fire2" is left alt or mouse1
        {
            StartCoroutine(HeavyAttack());
        }

    }
    private void FixedUpdate()
    {

        
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
    private IEnumerator LightAttack()
    {
        isAttacking = true;
        lightAttackHitbox.SetActive(true);
        catMovement.SetTrigger("Light");
        //animator.SetTrigger("LightAttack");
        yield return new WaitForSeconds(0.5f); // Match duration to animation
        lightAttackHitbox.SetActive(false);
        isAttacking = false;
    }

    private IEnumerator HeavyAttack()
    {
        isAttacking = true;
        heavyAttackHitbox.SetActive(true);
        catMovement.SetTrigger("Heavy");
        //animator.SetTrigger("HeavyAttack");
        yield return new WaitForSeconds(1f); // Match duration to animation
        heavyAttackHitbox.SetActive(false);
        isAttacking = false;
    }
}
