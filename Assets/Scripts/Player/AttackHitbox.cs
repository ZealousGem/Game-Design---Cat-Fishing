using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 10;
    public Enemyhealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("in attackhitbox script, there has been a collision on an enemy");
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
