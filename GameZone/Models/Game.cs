namespace GameZone.Models
{
	// The 'Game' class represents a game entity in the application.
	public class Game : BaseEntity
    {
        // A description of the game, limited to 2500 characters.
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        // A URL or path to the game's cover image, limited to 500 characters.
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

        // The foreign key for the Category the game belongs to.
        public int CategoryId { get; set; }

        // Navigation property for the Category the game belongs to. (only one category)
        // 'default!' indicates that this property should be initialized with a default value.
        public Category Category { get; set; } = default!;

        // A collection of 'GameDevice' instances, representing the devices the game can be played on.
        // Initialized with an empty list.
        // ICollection<T> is used here for flexibility, allowing the collection to be managed in various ways
        // while providing methods to add, remove, and query devices.
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
