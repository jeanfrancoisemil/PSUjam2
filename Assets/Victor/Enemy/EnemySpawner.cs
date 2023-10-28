using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 2f;

    private float _timer;
    public Animator doorAnimator;
    private static readonly int DoorOpen = Animator.StringToHash("DoorOpen");

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.endWave2)
        {
            doorAnimator.SetBool(DoorOpen, false);
        }
        else
        {
            doorAnimator.SetBool(DoorOpen, true);
        }
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
