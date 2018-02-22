namespace AuthorizationPolicies
{
    public class CondimentProvider : ICondimentProvider
    {
        Condiment _condiment = Condiment.Ketchup;

        public Condiment GetCondiment()
        {
            return _condiment;
        }

        public void SetCondiment(Condiment condiment)
        {
            _condiment = condiment;
        }
    }
}
