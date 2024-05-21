using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Takedamage(int dam)
    {
        currentHealth -= dam;
        //Debug.Log($"{currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealth <= 0)
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;


            Destroy(gameObject);





        }

    }
}
