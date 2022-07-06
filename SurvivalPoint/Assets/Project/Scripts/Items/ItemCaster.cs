public static class ItemCaster
{
    public static T ItemConvert<T>(this object item) where T : class
    {
        return item as T;
    }
}