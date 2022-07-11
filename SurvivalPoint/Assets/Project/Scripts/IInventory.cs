using System;

public interface IInventory<T>
{
    event Action<T> OnAdded; 
    
    event Action<T> OnRemoved;

    void Add(T item);

    void Distribute(T item);
}