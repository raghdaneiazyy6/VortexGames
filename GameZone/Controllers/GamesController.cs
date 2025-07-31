namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		private readonly ICategoriesService _categoriesService;
		private readonly IDevicesService _devicesService;
		private readonly IGamesService _gamesService;

		// Constructor for GamesController. It initializes the services used in this controller.
		public GamesController(
			ICategoriesService categoriesService,
			IDevicesService devicesService,
			IGamesService gamesService)
		{
			_categoriesService = categoriesService;
			_devicesService = devicesService;
			_gamesService = gamesService;
		}

        // Action method to display the list of games (index view).
        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

		public IActionResult Details(int id)
		{
			var game = _gamesService.GetById(id);
			if (game is null)
				return NotFound();
			return View(game);
		}

        // GET request action method to display the form for creating a new game.
        [HttpGet]
		public IActionResult Create()
		{
			// Create an instance of CreateGameFormViewModel and populate Categories and Devices.
			CreateGameFormViewModel viewModel = new()
			{
				Categories = _categoriesService.GetSelectList(), // Populates the categories dropdown list.
				Devices = _devicesService.GetSelectList() // Populates the devices dropdown list.
			};
			return View(viewModel); // Pass the view model to the Create view.
		}

		// POST request action method to handle the form submission for creating a new game.
		[HttpPost]
		[ValidateAntiForgeryToken] // Ensures that the request is coming from the original site to prevent CSRF attacks.
		public async Task<IActionResult> Create(CreateGameFormViewModel model)
		{
			// Check if the model state is valid (i.e., the form data is correct).
			if (!ModelState.IsValid)
			{
				// If the model is not valid, repopulate the dropdown lists and return the view with validation errors.
				model.Categories = _categoriesService.GetSelectList();
				model.Devices = _devicesService.GetSelectList();

				return View(model); // Return the form view with the current model state.
			}

			// Save the game and its cover to the database and server respectively.
			var createdBy = User.Identity?.Name ?? "Unknown";
			//var createdBy = "Raghda";
			await _gamesService.Create(model, createdBy);

			// Redirect to the Index action method after successful creation.
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id) 
		{ 
			var game=_gamesService.GetById(id);
			if(game is null)
				return NotFound();

			EditGameFormViewModel viewModel = new()
			{
				Id = id,
				Name = game.Name,
				Description = game.Description,
				CategoryId = game.CategoryId,
				SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
				Categories = _categoriesService.GetSelectList(),
				Devices = _devicesService.GetSelectList(),
				CurrentCover=game.Cover,
			};

			return View(viewModel);

        }

		[HttpPost]
		[ValidateAntiForgeryToken] // Ensures that the request is coming from the original site to prevent CSRF attacks.
		public async Task<IActionResult> Edit(EditGameFormViewModel model)
		{
			// Check if the model state is valid (i.e., the form data is correct).
			if (!ModelState.IsValid)
			{
				// If the model is not valid, repopulate the dropdown lists and return the view with validation errors.
				model.Categories = _categoriesService.GetSelectList();
				model.Devices = _devicesService.GetSelectList();

				return View(model); // Return the form view with the current model state.
			}

			//var updatedBy = User.Identity?.Name ?? "Unknown";
			var updatedBy = "Raghda";
			var game = await _gamesService.Update(model, updatedBy);

			if (game is null)
				return BadRequest();

			// Redirect to the Index action method after successful creation.
			return RedirectToAction(nameof(Index));
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var isDeleted=_gamesService.Delete(id);
		
			return isDeleted ? Ok() : BadRequest();
		}
	}
}
