using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private ForceMode2D _forceMode;

    public void Shoot(IShootable shootable, Vector2 target)
    {
        shootable = Instantiate(shootable.SelfRigidbody.gameObject, transform.position, Quaternion.identity).GetComponent<IShootable>();
        
        Rigidbody2D rigidbody = shootable.SelfRigidbody;
        float lenght = shootable.Lenght;

        Vector2 direction = target - rigidbody.position;
        float force = Calculator.GetForceWithMass(rigidbody.mass, lenght);
        
        rigidbody.AddForce(direction.normalized * force, _forceMode);
        
        Debug.Log($"Shoot to {direction} by {gameObject.name}.");
    }
}