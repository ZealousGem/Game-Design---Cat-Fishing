using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    //for the player attacking the enemies
    public int damage = 10;
    public Enemyhealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            Enemyhealth enemyhealth = other.GetComponent<Enemyhealth>();
            if (enemyhealth != null )
            {
                enemyhealth.Takedamage(damage);
            }
            if (enemyhealth = null ) 
            {
                Debug.Log("enemyhealth not found");
            }

        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            Enemyhealth enemyhealth = other.GetComponent<Enemyhealth>();
            if (enemyhealth != null)
            {
                enemyhealth.Takedamage(damage);
            }
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            Enemyhealth enemyhealth = other.GetComponent<Enemyhealth>();
            if (enemyhealth != null)
            {
                enemyhealth.Takedamage(damage);
            }
        }







    }
    public void AttackEnemy()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
