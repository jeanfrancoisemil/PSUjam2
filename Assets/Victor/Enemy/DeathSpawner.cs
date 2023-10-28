using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[DefaultExecutionOrder(-1)]
public class DeathSpawner : MonoBehaviour
{

    public static DeathSpawner Instance;
    private Animator _animator;
    private static readonly int DeathSpawn = Animator.StringToHash("DeathSpawn");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SpawnDeath()
    {
        _animator.SetTrigger(DeathSpawn);
    }
}
