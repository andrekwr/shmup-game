using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject volantEnemy;
    public GameObject asteroid;
    public GameObject enemyPatrol;
    private GameObject player;

    GameManager gm;

    public float spawnDelay = 10.0f;
    public float astDelay = 3.0f;

    private float _lastSpawn = 0.0f;
    private float _lastAst = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.right;
        Quaternion playerRotation = player.transform.rotation;

        float spawnDistance = 10;
 
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;

        if (Time.time - _lastAst > astDelay){
            Instantiate(asteroid, new Vector3(11f, Random.Range(-4.5f, 4.5f), 0.0f), Quaternion.Euler(0,0,90));
            _lastAst = Time.time;
        } 

        if (Time.time - _lastSpawn < spawnDelay) return;

        _lastSpawn = Time.time;
        Instantiate(volantEnemy, new Vector3(11f, Random.Range(-4.5f, 4.5f), 0.0f), Quaternion.Euler(0,0,90));
        Instantiate(enemyPatrol, new Vector3(11f, Random.Range(-4.5f, 4.5f), 0.0f), Quaternion.Euler(0,0,90));
        
    }
}
