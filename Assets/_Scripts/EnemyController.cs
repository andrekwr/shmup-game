using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject deathPoints;
    public GameObject tiro;
    private float lifes;
    public GameObject DeathParticle;
    GameManager gm;
    public GameObject healthbar;
    Vector3 escala;
    private void Start()
    {
        gm = GameManager.GetInstance();
        escala = healthbar.transform.localScale;

        lifes = 2f;
    }
    public void Shoot()
    {   
        Instantiate(tiro, transform.position, Quaternion.identity);
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        lifes -= 1f;
        escala.x = lifes;
        healthbar.transform.localScale = escala;
       if (lifes <= 0) {
           Die();
           gm.pontos += 80;
       }
    }

    public void Die()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Destroy(Instantiate(deathPoints, transform.position, Quaternion.identity), 2);
        Destroy(gameObject);
    }

  

    
}
