using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[Serializable]
public class Eating
{
    [SerializeField] private HealthBar _healthBar;
    
    private IEnumerable<ItemCell> _itemCells;
    private PlayerInputSystem _playerInputSystem;
    
    public void Initialize(IEnumerable<ItemCell> itemCells)
    {
        _itemCells = itemCells;
    }

    ~Eating()
    {
        _playerInputSystem.Player.Health.performed -= Eat;
    }
    
    [Inject]
    private void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.Player.Health.performed += Eat;
    }
    

    private void Eat(InputAction.CallbackContext _)
    {
        
    }
}