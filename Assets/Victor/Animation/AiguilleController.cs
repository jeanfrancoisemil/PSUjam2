using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class AiguilleController : MonoBehaviour
{
    private Animator _animator;
    public static AiguilleController Instance;
    public float time = 3f;
    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void LaunchWheel(float rotation)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
    
}
