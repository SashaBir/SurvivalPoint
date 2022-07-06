using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    private PlayerInputSystem _playerInputSystem;
    private IInventory _inventory;
    
    public override void InstallBindings()
    {
        _playerInputSystem = new PlayerInputSystem();
        _inventory = new Inventory();
            
        BindInputSystem();
        BindInventory();
    }

    private void BindInputSystem()
    {
        Container
            .Bind<PlayerInputSystem>()
            .FromInstance(_playerInputSystem);
    }
    
    private void BindInventory()
    {
        Container
            .Bind<IInventory>()
            .FromInstance(_inventory);
    }
}