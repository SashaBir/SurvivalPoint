using System;
using UnityEngine;

public interface IShootable : IItem
{
    Rigidbody2D SelfRigidbody { get; }
    
    float Lenght { get; }
}