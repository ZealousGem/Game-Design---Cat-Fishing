using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Enemy"))
        {
            Enemyhealth enemyhealth = gameObject.GetComponent<Enemyhealth>();
            if (enemyhealth != null )
            {
                enemyhealth.Takedamage(damage);
            }

        }
            

        


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
