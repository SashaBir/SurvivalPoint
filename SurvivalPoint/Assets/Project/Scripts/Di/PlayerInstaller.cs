using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    private PlayerInputSystem _playerInputSystem;

    public override void InstallBindings()
    {
        _playerInputSystem = new PlayerInputSystem();
            
        BindPlayerInputSystem();
    }

    private void BindPlayerInputSystem()
    {
        Container
            .Bind<PlayerInputSystem>()
            .FromInstance(_playerInputSystem);
    }
}