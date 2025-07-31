namespace GameZone.Models
{
    public class BaseEntity
    {
        // The unique identifier for the game.
        public int Id { get; set; }

        // The name of the game, limited to 250 characters.
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
