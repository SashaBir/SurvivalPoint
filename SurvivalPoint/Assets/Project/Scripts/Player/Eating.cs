using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Eating : MonoBehaviour
{
    private IInventoryElementCollection<IItem> _elements;
    private PlayerInputSystem _playerInputSystem;
    
    [Inject]
    public void Construct(IInventoryElementCollection<IItem> elements, PlayerInputSystem playerInputSystem)
    {
        _elements = elements;
        _playerInputSystem = playerInputSystem;
        
        _playerInputSystem.Player.Health.performed += Eat;
    }

    ~Eating()
    {
        _playerInputSystem.Player.Health.performed -= Eat;
    }

    private void Eat(InputAction.CallbackContext _)
    {

        Debug.Log("Eat!");
    }
}