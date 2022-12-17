namespace Assets.Scripts
{
    public class PlayerCard
    {
        public PlayerCard(City city)
        {
            City = city;
        }

        public City City { get; private set; }
    }

}
