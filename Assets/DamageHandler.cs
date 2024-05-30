using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float attackDamage = 10;
    public float attackCooldown = 2.5f;
    
    public bool canAttack = false;
    public Health playerHealth;


    public float damageCooldown = 1f;

    private float lastDamageTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") )
        {
            AttackPlayer();

        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            attackDamage = 30;
            AttackPlayer();

        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            
            attackDamage = 20;
            AttackPlayer();

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TryApplyDamage();

        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            attackDamage = 30;
            TryApplyDamage();

        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            attackDamage = 20;
            TryApplyDamage();


        }


    }
    private void TryApplyDamage()
    {
        if(Time.time>=lastDamageTime+damageCooldown)
        {
            AttackPlayer();
            lastDamageTime = Time.time;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lastDamageTime = -damageCooldown;
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void Awake()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent<Health>())
            {

                playerHealth = pl.GetComponent<Health>();
            }
        }
    }
    
    private void AttackPlayer()
    {
        
        playerHealth.Takedamage(attackDamage);
        canAttack = false;


    }
}
