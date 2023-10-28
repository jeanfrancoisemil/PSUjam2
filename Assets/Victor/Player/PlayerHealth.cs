using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour
{
    public float initialHealth;
    [HideInInspector]public float currentHealth;
    public UnityEvent dieEvent;
    private Color _initialColor;
    private SpriteRenderer _renderer;
    private bool canTakeDamage;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _initialColor = _renderer.color;
    }
    public void DoDamage(int damage)
    {
        if (!canTakeDamage) return;
        StartCoroutine(nameof(ChangeColor));
        StartCoroutine(nameof(ChangeCanTakeDamage));
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator ChangeColor()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = _initialColor;
    }    
    IEnumerator ChangeCanTakeDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.2f);
        canTakeDamage = true;
    }
    IEnumerator PoisonDamage(int damage, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DoDamage(damage);
    }
    public void DoPoisonDamage(int loopCount, int damageTick)
    {
        for (int i = 0; i < loopCount; i++)
        {
            StartCoroutine(PoisonDamage(damageTick, i * 0.2f));
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
        dieEvent.Invoke();
        StopAllCoroutines();
    }
}
