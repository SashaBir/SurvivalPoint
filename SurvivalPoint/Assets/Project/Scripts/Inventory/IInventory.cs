using System;

public interface IInventory<in T> 
    where T : IInventoryElement
{
    bool TryGetCurrent<TArgument>(out TArgument element)
        where TArgument : T;
    
    void Add(T item);
}