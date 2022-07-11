public class ItemSlot
{
    public ItemSlot(Item item)
    {
        _item = item;
    }

    private readonly Item _item;
    private int _count = 1;
    
    public Item Item => _item;
    
    public int Count => _count;

    public void Add()
    {
        _count++;
    }

    public void Reduce()
    {
        _count--;
    }
}