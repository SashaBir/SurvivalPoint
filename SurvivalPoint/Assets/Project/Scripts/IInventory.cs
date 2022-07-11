using System;

public interface IInventory<T>
{
    uint Lenght { get; set; }

    uint Fullness { get; }

    bool IsEmpty => Fullness == 0 && Lenght != 0;
    
    event Action<T> OnAdded; 
    
    event Action<T> OnRemoved;

    void Add(T item);

    void Remove(T item);

    TOther Get<TOther>() where TOther : class;
}