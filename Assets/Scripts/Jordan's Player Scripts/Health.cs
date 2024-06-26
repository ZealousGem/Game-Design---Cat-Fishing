using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100f;
    public float currentHealth;
    private float HealthDisplay;
    int health;
    public GameObject player;
    //public Text healthText;
    public Image healthImage;
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
        //  HealthDisplay = currentHealth;
        //  health = (int)(HealthDisplay);
        //  healthText.text = health.ToString();
        // Debug.Log(currentHealth);
    }

    public void Takedamage(float dam)
    {
        currentHealth -= dam;
        //Debug.Log($"{currentHealth}");
        Debug.Log("The player health is:" + currentHealth + "player has taken " + dam + "damage");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds
        healthImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.instance.musicSource.Stop();
            healthImage.fillAmount = 0;
            // Destroy(gameObject);





        }

    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth >= 100)
        {
            currentHealth = 100;
            healthImage.fillAmount = 100;
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
