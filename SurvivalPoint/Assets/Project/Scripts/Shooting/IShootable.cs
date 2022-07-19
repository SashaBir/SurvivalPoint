using System;
using UnityEngine;

public interface IShootable : IItem
{
    Rigidbody2D SelfRigidbody { get; }
    
    float Speed { get; }
    
    float Lenght { get; }
    
    bool IsHitted { get;  }
}