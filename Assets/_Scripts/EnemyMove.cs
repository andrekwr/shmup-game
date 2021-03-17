using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    public Transform Player;
    public float speed = 2f;
    private float minDistance = 3.0f;
    
    private float range;
    

    
    void Update()
    {
         GameObject player = GameObject.FindWithTag("Player");
         if (player) {
        Player = GameObject.FindWithTag("Player").transform;
        range = Vector2.Distance(transform.position, Player.position);
        if (range > minDistance)
        {
            Player = GameObject.FindWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

        }
         }

   


    }
}