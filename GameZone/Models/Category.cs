namespace GameZone.Models
{
    public class Category :BaseEntity
    {
        public ICollection<Game> Games = new List<Game>();
    }
}
