using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : SteerableBehaviour, IDamageable
{
    // Start is called before the first frame update
    GameManager gm;
    public GameObject deathPoints;
    public GameObject DeathParticle;
    void Start()
    {
        gm = GameManager.GetInstance();
        
    }

    public void TakeDamage()
    {
        gm.pontos += 10;
        Die();
    }

    public void Die()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Destroy(Instantiate(deathPoints, transform.position, Quaternion.identity), 2);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Thrust(-1f, 0);
    }
}
