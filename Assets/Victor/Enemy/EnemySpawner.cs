using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 1.8f;

    private float _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > spawnTime)
        {
            GameManager.Instance.SpawnEnemy(transform.position);
            _timer = 0f;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}
