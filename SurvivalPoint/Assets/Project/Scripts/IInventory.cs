public interface IInventory
{
    void Add(IItem item);

    T Get<T>() where T : class;
    
    void Remove(IItem item);
}