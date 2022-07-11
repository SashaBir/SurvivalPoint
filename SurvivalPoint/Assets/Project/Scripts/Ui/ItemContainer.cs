using System;

[Serializable]
public class ItemContainer
{
    public IItem Item { get; set; }
    
    public int Count { get; set; }
}