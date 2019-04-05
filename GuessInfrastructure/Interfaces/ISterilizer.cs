namespace GuessInfrastructure.Interfaces
{
    public interface ISterilizer<T>
    {
        string Sterilize(T entity);
        T DeSterilize(string str);
    }
}