using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private readonly IInventory _inventory = new Inventory();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IItem item) == true)
        {
            _inventory.Add(item);
        }
    }
}