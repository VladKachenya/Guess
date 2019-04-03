namespace GuessCore.Interfaсes
{
    public interface IConverter<T>
    {
        T Convert(string str);
    }
}