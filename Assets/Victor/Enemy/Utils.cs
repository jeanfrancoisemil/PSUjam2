using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void ApplyForceToReachVelocity(Rigidbody2D rigidbody, Vector2 velocity, float force = 1, ForceMode2D mode = ForceMode2D.Force)
    {
        if (force == 0 || velocity.magnitude == 0)
            return;

        velocity += velocity.normalized * (0.2f * rigidbody.drag);

        var mass = rigidbody.mass;
        force = Mathf.Clamp(force, -mass / Time.fixedDeltaTime, mass / Time.fixedDeltaTime);

        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(velocity * force, mode);
        }
        else
        {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }
}
