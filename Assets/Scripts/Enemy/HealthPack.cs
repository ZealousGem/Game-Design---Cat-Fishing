using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fish;
    public GameObject enemy;
    public Animator animator;
  
   

    private void Start()
    {
        enemy.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Enemyhealth.isDead)
        {
            StartCoroutine(Death());


        }
    }

   

    public IEnumerator Death()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(0.30f);
        enemy.transform.position = fish.transform.position;
        fish.SetActive(false);
        enemy.SetActive(true);
    }
    

   

    

}
