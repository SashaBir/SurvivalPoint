using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Zenject;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Shooting _shooting;
    
    private readonly IInventory _inventory = new Inventory();
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    private void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
    }

    private void OnEnable()
    {
        _playerInputSystem.Player.Move.performed += context =>
        {
            _movement.Direction = context.ReadValue<Vector2>();
        };
        
        _playerInputSystem.Player.Move.canceled += _ =>
        {
            _movement.Direction = Vector2.zero;
        };

        _playerInputSystem.Player.Fire.performed += _ =>
        {
            Vector2 target = Mouse.current.position.ReadValue();
            _shooting.Shoot(target);
        };
        
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IItem item) == true)
        {
            _inventory.Add(item);
        }
    }
}