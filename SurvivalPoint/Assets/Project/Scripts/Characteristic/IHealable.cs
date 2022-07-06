public interface IHealable<in T>
{
    void Heal(T value);
}