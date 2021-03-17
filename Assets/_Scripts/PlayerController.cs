using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    public Loader LoaderLevel;
    public GameObject bullet;
    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    GameManager gm;

     private void Start()
    {
        
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music) {
                    
                    GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        } 
        

    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;

        GetComponent<AudioSource>().Play();
       _lastShootTimestamp = Time.time;
        Instantiate(bullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        gm.lifes--;
       if (gm.lifes <= 0) {
           Die();
           LoaderLevel.LoadNextLevel();
           gm.lifes = 5;
           gm.pontos = 0;
           
           
        };
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Update() {
        if (gm.pontos >= 10000) {
            SceneManager.LoadScene("Win");
            gm.lifes = 5;
            gm.pontos = 0;
        }
        
        
        
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
       {
            animator.SetFloat("Velocity", 1.0f);
       }
       else
       {
           animator.SetFloat("Velocity", 0.0f);
       }

       if(Input.GetAxisRaw("Jump") != 0)
       {
           
           Shoot();
       }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }


    
}
