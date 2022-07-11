using UnityEngine;

public interface IShootable
{
    Rigidbody2D SelfRigidbody { get; }
    
    float Lenght { get; }
}