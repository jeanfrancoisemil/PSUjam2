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
    public float teleportationThreshold;
    public LayerMask groundMask;
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public float force;
    private Vector2 _posCache;
    private bool _askingTeleportation;
    private float _teleportationWaitingTime;
    private bool _touchingPlayer;
    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _follow = PlayerSingleton.Instance.GetComponent<Rigidbody2D>();
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
        }
        else
        {   
            if (Mathf.Abs(_follow.transform.position.y - position.y)>1f &&  Physics2D.Raycast(transform.position, new Vector2(0f, -1), 0.3f, groundMask.value))
            {
                Debug.Log(Vector2.Distance(_follow.transform.position, transform.position));
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
                _teleportationWaitingTime = 0f;
                _touchingPlayer = true;
            } 
        }
    }

    public void Teleport()
    {
        var results = new RaycastHit2D[1];
        var count =_follow.Cast(new Vector2(0f, -1f), new ContactFilter2D()
        {
            layerMask = groundMask
        }, results, 5f);
        EnemyTeleportPlatform parent;
        if (count != 0 && (parent = results[0].transform.GetComponentInParent<EnemyTeleportPlatform>()) != null)
        {
            var teleports = parent.teleports;
            _rigidbody2D.position = teleports[UnityEngine.Random.Range(0, teleports.Length)].transform.position;
            _rigidbody2D.velocity = Vector2.zero;    
        }
        
    }
}
