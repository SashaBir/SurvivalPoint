public class ItemStack
{
    public ItemStack(IItem item)
    {
        _item = item;
    }

    private readonly IItem _item;
    private int _count = 1;

    public IItem Item => _item;
    
    public int Count => _count;
    
    public bool IsEmpty => _count == 0;

    public void Add()
    {
        _count++;
    }

    public void Reduce()
    {
        _count--;
    }
}