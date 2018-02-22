namespace AuthorizationPolicies
{
    public interface ICondimentProvider
    {
        Condiment GetCondiment();

        void SetCondiment(Condiment conidement);
    }

    public enum Condiment
    {
        Ketchup,
        Mayo,
        Cilli
    }
}
