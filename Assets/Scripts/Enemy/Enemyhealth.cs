using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealthE;
    public bool isDead= false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthE = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Takedamage(int dam)
    {
        currentHealthE -= dam;
        //Debug.Log($"{currentHealth}");
        Debug.Log("The enemy health is:" + currentHealthE + "enemy has taken " + dam + "damage");
        currentHealthE = Mathf.Clamp(currentHealthE, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealthE <= 0)
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealthE = 0;


            
            isDead = true;




        }

    }
}
