using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    private PlayerInputSystem _playerInputSystem;
    private IInventory<Item> _inventory;
    
    public override void InstallBindings()
    {
        _playerInputSystem = new PlayerInputSystem();
        _inventory = new Inventory(7);
            
        BindInputSystem();
        BindInventory();
    }

    private void BindInputSystem()
    {
        Container
            .Bind<PlayerInputSystem>()
            .FromInstance(_playerInputSystem)
            .AsCached();
    }
    
    private void BindInventory()
    {
        Container
            .Bind<IInventory<Item>>()
            .FromInstance(_inventory)
            .AsCached();
    }
}