namespace src.Domain.Interface;

public interface IPrototype<T>
{
    T Clone();
}