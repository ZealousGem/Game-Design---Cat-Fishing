using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTank : MonoBehaviour
{
    // Start is called before the first frame update

  //  public GameObject Text;
    public Image foreground;
    public PlayerHealth health;
    bool takehealth;
    float timer;
    float maxTime = 50f;
    float damage = 1f;
    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.airTime is true)
        {
            gainOxygen();
        }

        else
        {
            LosinigOxygen();
        }

       if(takehealth is true)
        {
            health.Takedamage(damage = Time.deltaTime);
        }

       
      
    }

    void LosinigOxygen()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            foreground.fillAmount = timer / maxTime;
             
            
        }

        else
        {
            foreground.fillAmount = 0;
            takehealth = true;
           

        }
    }

    void gainOxygen()
    {
        takehealth = false;
        if (timer <= 50)
        {
            timer += Time.deltaTime * 2;
           // Debug.Log(timer);
            foreground.fillAmount = timer / maxTime;
        }

        else
        {
            foreground.fillAmount = 50;
        }
    }
}
// https://www.youtube.com/watch?v=4g7YY9tLxEE&t=332s 