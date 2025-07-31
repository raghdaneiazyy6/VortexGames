namespace GameZone.ViewModels
{
    public class GameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        // Represents the name of the game with a maximum length of 250 characters.

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        // Represents the ID of the selected category for the game.
        // Display attribute sets the label to "Category".

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        // A collection of categories to be used in a dropdown list in the form.
        // 'IEnumerable<SelectListItem>' is a read-only collection of items for dropdown lists.

        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        // A list of selected device IDs for the game.
        // 'List<int>' is a mutable list that allows adding and removing items.

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        // A collection of devices to be used in a dropdown list in the form.
        // 'IEnumerable<SelectListItem>' is a read-only collection of items for dropdown lists.

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        // Represents a description of the game with a maximum length of 2500 characters.
    }
}
