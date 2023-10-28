using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
	[HideInInspector]public bool positiveDirection;
	public float Direction => positiveDirection ? 1f : -1f;
	[HideInInspector]public bool hasHit = false;
	public float speed = 10f;
	public float lifeTime = 10f;
	public enum TypeArme { Horizontale = 0, Verticale = 1, Zone = 2 }
	public TypeArme arme = TypeArme.Horizontale;
	private Rigidbody2D _rigidbody2D;
	public float pushForce = 1f;
	public int damage = 4;
	// Update is called once per frame
    private void Start()
    {
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	    StartCoroutine(nameof(DeathCoroutine));
    }

    IEnumerator DeathCoroutine()
    {
	    yield return new WaitForSeconds(lifeTime);    
	    Destroy(gameObject);
    }
    void FixedUpdate()
    {
	    if (!hasHit)
	    {
		    _rigidbody2D.velocity = GetVelocity();
	    }
	}

    public Vector2 GetVelocity()
    {
	    switch (arme)
	    {
		    case TypeArme.Horizontale:
			    return new Vector2(Direction * speed, 0f);
		    case TypeArme.Verticale:
			    return new Vector2(0f,Direction * speed );
		    case TypeArme.Zone:
			    break;
		    default:
			    throw new ArgumentOutOfRangeException();
	    }
	    return Vector2.zero;
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		hasHit = true;
		collision.gameObject.GetComponent<EnemyHealth>().DoDamage(damage);
		collision.rigidbody.AddForce(GetVelocity() * pushForce);
		Destroy(gameObject);
	}
}
