using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private Movement _movement;
    [SerializeField] private Shooting _shooting;

    [Header("Ui")] 
    [SerializeField] private PlayerInventory _playerInventory;

    private IInventory<Item> _inventory;
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    private void Construct(IInventory<Item>  inventory, PlayerInputSystem playerInputSystem)
    {
        _inventory = inventory;
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
            IShootable shootable = _playerInventory.Current?.GetComponent<IShootable>();
            if (shootable is null)
            {
                return;
            }
            
            shootable = _playerInventory.TakeCurrent<IShootable>();

            Vector2 targetOnScreen = Mouse.current.position.ReadValue();
            Vector2 target = Camera.main.ScreenToWorldPoint(targetOnScreen);
            
            _shooting.Shoot(shootable, target);
        };
        
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IItemProvider itemProvider) == true)
        {
            _inventory.Add(itemProvider.Item);
        }
    }
}