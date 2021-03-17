using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotVolantBehaviour : SteerableBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Inimigos")) return;
       
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }
       Destroy(gameObject);
   }

    private void Update()
   {
       //if (gm.gameState != GameManager.GameState.GAME) return;
       Thrust(-1, 0);
   }
   

}
