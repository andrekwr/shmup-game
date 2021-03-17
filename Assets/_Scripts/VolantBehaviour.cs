using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable, IShooter
{
    
    float angle = 0;
    private float lifes;
    public GameObject tiro;
    public GameObject deathPoints;
    public GameObject DeathParticle;
    public float shootDelay = 1.0f;
   private float _lastShootTimestamp = 0.0f;
   GameManager gm;
    public GameObject healthbar;
    Vector3 escala;
   private void FixedUpdate()
   {
       //if (gm.gameState != GameManager.GameState.GAME) return;
       angle += 0.1f;
       if (angle > 2.0f * Mathf.PI) angle = 0.0f;
       Thrust(0, Mathf.Cos(angle));

       
   }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        lifes = 2f;
        escala = healthbar.transform.localScale;
        
    }

    public void Shoot()
    {
        
        if (Time.time - _lastShootTimestamp < shootDelay) return;
       _lastShootTimestamp = Time.time;
        Instantiate(tiro, transform.position - new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        lifes -= 1f;
        escala.x = lifes;
        healthbar.transform.localScale = escala;
       if (lifes <= 0) { 
           Die();
           gm.pontos += 40;
       }
    }

    public void Die()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Destroy(Instantiate(deathPoints, transform.position, Quaternion.identity), 2);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gm.gameState != GameManager.GameState.GAME) return;
        
       Shoot();
        
    }
}
