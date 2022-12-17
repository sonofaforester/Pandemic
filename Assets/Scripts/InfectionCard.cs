namespace Assets.Scripts
{
    public class InfectionCard
    {
        public InfectionCard(City city)
        {
            City = city;
        }

        public City City { get; private set; }
    }

}
