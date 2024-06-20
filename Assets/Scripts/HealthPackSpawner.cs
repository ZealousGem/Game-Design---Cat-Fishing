using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Health cat;
    public float health = 10f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Health")
        {
            StartCoroutine(HealingTime());
        }
    }

    public IEnumerator HealingTime()
    {
        yield return new WaitForSeconds(1f);
        cat.Heal(health);
        AudioManager.instance.SFX("Health");
        Debug.Log("healed");
        Destroy(enemy);
      
        //Enemyhealth.isDead = false;
    }

}

