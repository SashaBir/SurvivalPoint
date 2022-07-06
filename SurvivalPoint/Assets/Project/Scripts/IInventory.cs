using System;

public interface IInventory
{
    event Action<IItem> Action; 

    void Add(IItem item);

    T Get<T>() where T : class;
    
    void Remove(IItem item);
}