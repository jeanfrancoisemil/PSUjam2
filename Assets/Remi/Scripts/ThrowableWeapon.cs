using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
	public Vector2 direction;
	public bool hasHit = false;
	public float speed = 10f;
	public enum TypeArme { Horizontale = 0, Verticale = 1, Zone = 2 }
	public TypeArme arme = TypeArme.Horizontale;
	private Rigidbody2D _rigidbody2D;

	// Update is called once per frame
    private void Start()
    {
	    _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		if ( !hasHit)
		_rigidbody2D.velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.SendMessage("ApplyDamage", Mathf.Sign(direction.x) * 2f);
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}
}
