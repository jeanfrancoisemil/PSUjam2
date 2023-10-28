using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _follow;
    private PlayerHealth _followHealth;
    public float teleportationThreshold;
    public LayerMask groundMask;
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public float force;
    private Vector2 _posCache;
    private bool _askingTeleportation;
    private float _teleportationWaitingTime;
    private bool _touchingPlayer;
    public float pushForce = 20f;
    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _follow = PlayerSingleton.Instance.GetComponent<Rigidbody2D>();
        _followHealth = PlayerSingleton.Instance.GetComponent<PlayerHealth>();
    }

    public bool IsTouchingPlayer()
    {
        return _touchingPlayer;
    }
    public void Update()
    {
        

        var position = transform.position;
        if (Mathf.Abs(_follow.transform.position.x -position.x)>1f )
        {
            Utils.ApplyForceToReachVelocity(_rigidbody2D, new Vector2(Mathf.Sign(_follow.transform.position.x-position.x),0f) * speed, force);
            _touchingPlayer = false;
            if (_follow.transform.position.y - position.y>5f &&  Physics2D.Raycast(transform.position, new Vector2(0f, -1), 1.5f, groundMask.value))
            {
                if (teleportationThreshold < _teleportationWaitingTime)
                {
                    Teleport();
                    _teleportationWaitingTime = 0f;
                }
                else
                {
                    _teleportationWaitingTime += Time.deltaTime;
                }
                _touchingPlayer = false;
            }
        }
        else
        {   
            if (Mathf.Abs(_follow.transform.position.y - position.y)>1f &&  Physics2D.Raycast(transform.position, new Vector2(0f, -1), 1.5f, groundMask.value))
            {
                if (teleportationThreshold < _teleportationWaitingTime)
                {
                    Teleport();
                    _teleportationWaitingTime = 0f;
                }
                else
                {
                    _teleportationWaitingTime += Time.deltaTime;
                }
                _touchingPlayer = false;
            }
            else
            {
                if (Physics2D.Raycast(transform.position, new Vector2(0f, -1), 1f, groundMask.value))
                {
                    _rigidbody2D.velocity = Vector2.zero;   
                }
                _touchingPlayer = true;
            } 
        }
        if (_touchingPlayer)
        {
            Debug.Log("Touching Player");
            _follow.AddForce((_follow.transform.position-position).normalized * pushForce);
            _followHealth.DoDamage(1);
        }
    }

    public void Teleport()
    {
        var results = new RaycastHit2D[1];
        var count =_follow.Cast(new Vector2(0f, -1f), new ContactFilter2D()
        {
            layerMask = groundMask
        }, results, 20f);
        EnemyTeleportPlatform parent;
        if (count != 0 && (parent = results[0].transform.GetComponentInParent<EnemyTeleportPlatform>()) != null)
        {
            var teleports = parent.teleports;
            _rigidbody2D.position = teleports[UnityEngine.Random.Range(0, teleports.Length)].transform.position;
            _rigidbody2D.velocity = Vector2.zero;    
        }
        
    }
}
