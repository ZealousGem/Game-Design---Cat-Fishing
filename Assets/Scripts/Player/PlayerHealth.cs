using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    private float HealthDisplay;
    int health;
    public GameObject player;
    public Text healthText;
    public static bool airTime;
   // public 
    
    

   
    private void Awake()
    {
        
        currentHealth = maxHealth;
        
        
        
       
        

    }

    // Start is called before the first frame update
    void Start()
    {
        airTime = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay = currentHealth;
        health = (int)(HealthDisplay);
        healthText.text = health.ToString();
       // Debug.Log(currentHealth);
    }

    public void Takedamage(float dam)
    {
        currentHealth -=  dam;
        //Debug.Log($"{currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealth <=0) 
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;
            

           // Destroy(gameObject);
            




        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Air": airTime = true; Debug.Log(airTime); break;
            case "NoAir": airTime = false; Debug.Log(airTime); break;
        }
    }

}
