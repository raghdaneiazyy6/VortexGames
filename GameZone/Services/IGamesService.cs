namespace GameZone.Services
{
	public interface IGamesService
	{
		IEnumerable<Game> GetAll();

		Game? GetById(int id);
		Task Create(CreateGameFormViewModel model, string createdBy);

		Task<Game?> Update(EditGameFormViewModel model,string updatedBy);

		bool Delete(int id);
	}
}
