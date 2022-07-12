using System;

public interface IInventory<T> where T : IInventoryElement
{
    event Action<T> OnAdded; 
    
    event Action<T> OnRemoved;

    void Add(T item);

    void Remove(T item);
}