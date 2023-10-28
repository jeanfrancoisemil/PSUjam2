using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int initialHealth;

    [HideInInspector]public int currentHealth;
    private SpriteRenderer _renderer;
    private Color _color;
    private void Start()
    {
        currentHealth = initialHealth;
        _renderer = GetComponent<SpriteRenderer>();
        _color = _renderer.color;
    }

    public void DoDamage(int damage)
    {
        StartCoroutine(nameof(ChangeColor));
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
        _renderer.color = _color;
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
