using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory<IItem>
{
    [SerializeField] private SelectionColorItem _selectionColorItem;
    [SerializeField] private ItemCell[] _itemCells;
    
    private ItemCellSelection _itemCellSelection;
    private ItemCell _currentItemCell;
    
    private void Awake()
    {
        _itemCellSelection = new ItemCellSelection(_itemCells);
    }

    private void OnEnable()
    {        
        _selectionColorItem.Enable();

        _itemCellSelection.OnSelected += SetCurrentItemCell;
    }

    private void OnDisable()
    {
        _selectionColorItem.Disable();

        _itemCellSelection.OnSelected -= SetCurrentItemCell;
    }

    public void Add(IItem item)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.Type == item.Type);
        if (itemCell is null)
        {
            itemCell = _itemCells.FirstOrDefault(i => i.IsEmpty == true);
            itemCell.Add(item);
            
            return;
        }
        
        itemCell.Add(item);
    }

    public bool TryGetCurrent<TArgument>(out TArgument element)
        where TArgument : IItem
    {
        if (_currentItemCell?.Current?.Self.TryGetComponent(out TArgument _) == true)
        {
            element = _currentItemCell.Pop().Self.GetComponent<TArgument>();
            return true;
        }

        element = default;
        return false;
    }

    private void SetCurrentItemCell(ItemCell itemCell)
    {
        _currentItemCell = itemCell;
    }
}