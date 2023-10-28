using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour
{
    public float initialHealth;
    [HideInInspector]public float currentHealth;
    public UnityEvent dieEvent;
    private SpriteRenderer _renderer;
    private bool _canTakeDamage;
    private bool _dead;

    private CharacterController2D _CharacterController; 
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _canTakeDamage = true;
        _CharacterController = GetComponent<CharacterController2D>();
        currentHealth = initialHealth;
    }
    public void DoDamage(int damage)
    {
        if (!_canTakeDamage || _dead || _CharacterController.isDashing) return;
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
        _renderer.color = Color.white;
    }    
    IEnumerator ChangeCanTakeDamage()
    {
        _canTakeDamage = false;
        yield return new WaitForSeconds(0.2f);
        _canTakeDamage = true;
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

    private void Die()
    {
        dieEvent.Invoke();
        StopAllCoroutines();
        _renderer.color = Color.black;
        _dead = true;
        SceneManager.LoadScene("GameOver");
    }
}
