using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _minimumRadius;
    [SerializeField] private ForceMode2D _forceMode;

    public void Shoot(IShootable shootable, Vector2 target)
    {
        Rigidbody2D rigidbody = shootable.SelfRigidbody;
        float lenght = shootable.Lenght;

        Vector2 direction = (target - (Vector2)transform.position).normalized;
        
        shootable.Self.transform.position = PositionMinimumAttackedRadius(direction);
        
        float force = Calculator.GetForceWithMass(rigidbody.mass, lenght);
        
        shootable.Show();

        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(direction * force, _forceMode);
        
        ///Debug.Log($"Shoot to {direction} by {gameObject.name}.");
    }

    private Vector2 PositionMinimumAttackedRadius(Vector2 direction)
    {
        return (Vector2)transform.position + direction * _minimumRadius;
    }
}