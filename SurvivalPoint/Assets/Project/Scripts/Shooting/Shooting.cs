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

        Vector2 direction = (target - rigidbody.position).normalized;
        
        MoveToMinimumAttackedRadius(shootable.Self.transform, direction);
        
        float force = Calculator.GetForceWithMass(rigidbody.mass, lenght);

        shootable.Show();
        
        rigidbody.AddForce(direction * force, _forceMode);
        
        Debug.Log($"Shoot to {direction} by {gameObject.name}.");
    }

    private void MoveToMinimumAttackedRadius(Transform transform, Vector2 direction)
    {
        Vector2 position = (Vector2)transform.position + direction * _minimumRadius;
        transform.position = position;
    }
}