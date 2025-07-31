namespace GameZone.ViewModels
{
	// ViewModel class for creating a new game
	public class CreateGameFormViewModel : GameFormViewModel
	{
		// Validate file extensions and size on the server side.
		[AllowedExtensions(FileSettings.AllowedExtensions), MaxFileSize(FileSettings.MaxFileInByte)]
		public IFormFile Cover { get; set; } = default!;
		// Represents the cover image file for the game.
		// 'IFormFile' is an abstraction for handling file uploads in ASP.NET Core.
	}
}