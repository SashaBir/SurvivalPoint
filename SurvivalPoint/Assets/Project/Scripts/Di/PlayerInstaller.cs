using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Inventory _inventory;
    
    private PlayerInputSystem _playerInputSystem;

    public override void InstallBindings()
    {
        _playerInputSystem = new PlayerInputSystem();
            
        BindInventory();
        BindInventoryElementCollection();
        BindInputSystem();
    }

    private void BindInventory()
    {
        Container
            .Bind<IInventory<IItem>>()
            .FromInstance(_inventory)
            .AsCached();
    }
    
    private void BindInventoryElementCollection()
    {
        Container
            .Bind<IInventoryElementCollection<IItem>>()
            .FromInstance(_inventory)
            .AsCached();
    }
    
    private void BindInputSystem()
    {
        Container
            .Bind<PlayerInputSystem>()
            .FromInstance(_playerInputSystem)
            .AsCached();
    }
}