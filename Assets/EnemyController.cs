using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D objRb;
    float playerZ;
    float playerX;
    float playerY;  
    GameObject[] player = null;
   
     float EnemyX;
    float EnemyY;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        player = GameObject.FindGameObjectsWithTag("Player");
        objRb=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        playerZ = player[0].GetComponent<Transform>().position.z;
        playerX = player[0].GetComponent<Transform>().position.x;
        EnemyX=GetComponent<Transform>().position.x;
        EnemyY = GetComponent<Transform>().position.y;
        playerY= player[0].GetComponent<Transform>().position.y;
        Vector2 movePos = Vector2.MoveTowards(objRb.position, new Vector2(playerX, playerY), speed * Time.fixedDeltaTime);
        objRb.MovePosition(movePos);




        if (EnemyX-playerX==3 || EnemyX - playerX == -3)
        {
            //Vector3 movepos = Vector3.MoveTowards(objRb.position, new Vector3(playerX, playerY, 0), speed * Time.fixedDeltaTime);
            //Chase();

        }
        if (EnemyY - playerY == 3 || EnemyY - playerY == -3)
        {
            //Chase();


        }
        else
        {
            //Patrol();

        }


    }
    private void Chase()
    {
        Debug.Log("should be chasing");
        Vector2 movePos = Vector2.MoveTowards(objRb.position, new Vector2(playerX, playerY), speed * Time.fixedDeltaTime);
        objRb.MovePosition(movePos);


    }
    private void Patrol()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime; ;

    }
}
