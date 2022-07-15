using System.Collections.Generic;

public interface IInventoryElementCollection<T>
    where T : IInventoryElement
{
    IEnumerable<T> Collection { get; }
}