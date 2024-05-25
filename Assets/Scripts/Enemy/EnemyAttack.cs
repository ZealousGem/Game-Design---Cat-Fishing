using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage = 10;
    public float attackCooldown = 1.5f;
    private float timeSinceLastAttack = 0f;
    public bool canAttack = false;
    public Health playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanAttackPlayer();
        }


    }
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if (canAttack == true)
        {
            AttackPlayer();
            timeSinceLastAttack = 0f;
        }


    }
    public bool CanAttackPlayer()
    {
        if (timeSinceLastAttack>attackCooldown)
        {
            //Debug.Log("time since last attack is"+timeSinceLastAttack);
            //Debug.Log("attack cooldown is"+attackCooldown);
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
        
        
        return canAttack;

    }
    private void AttackPlayer()
    {
        playerHealth.Takedamage(attackDamage);
        canAttack = false;


    }
}
