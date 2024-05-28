using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    public int maxHealth = 40;
    public int currentHealthE;
    public bool isDead= false;
    public Image Health;
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
        Health.fillAmount = currentHealthE / maxHealth;
        currentHealthE = Mathf.Clamp(currentHealthE, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealthE <= 0)
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealthE = 0;
            Health.fillAmount = 0;

            
            isDead = true;




        }

    }
}
