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
        _animator = GetComponent<Animator>();
    }

    public void LaunchWheel(string paramName)
    {
        _animator.SetBool(paramName, true);
        StartCoroutine(nameof(StopWheel));
    }

    IEnumerator StopWheel()
    {
        yield return new WaitForSeconds(time);
        _animator.SetTrigger("Launch");
    }
}
