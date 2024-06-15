using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;
    
   
    

    // Start is called before the first frame update
    void Start()
    {
        
        

    }
    private void Awake()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent<Transform>())
            {

                player = pl.GetComponent<Transform>();
                Debug.Log(player);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //the enemy move towards the player
        if (player !=null)
        {
            Vector2 direction =(player.position - transform.position).normalized;
            transform.position=Vector2.MoveTowards(transform.position,player.position, moveSpeed *Time.deltaTime);

        }
        




       


    }
   
}
