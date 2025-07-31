namespace GameZone.Data
{
	// ApplicationDbContext is derived from DbContext, which is the primary class for interacting with the database in Entity Framework.
	public class ApplicationDbContext : DbContext
	{
		// Constructor for ApplicationDbContext that takes DbContextOptions as a parameter.
		// This allows configuration of the context, such as the database connection string.
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// DbSet properties represent collections of the specified entity types in the context.
		// These are mapped to corresponding tables in the database.

		// Represents the 'Games' table in the database.
		public DbSet<Game> Games { get; set; }

		// Represents the 'Categories' table in the database.
		public DbSet<Category> Categories { get; set; }

		// Represents the 'Devices' table in the database.
		public DbSet<Device> Devices { get; set; }

		// Represents the 'GameDevices' table in the database, used for many-to-many relationship between Games and Devices.
		public DbSet<GameDevice> GameDevices { get; set; }

		// OnModelCreating is used to configure the model and relationships between entities.
		// This method is called by the Entity Framework Core when the model for the context is being created.
		// By overriding this method, you can customize the way the Entity Framework Core configures the database schema.
		// The 'protected' keyword makes this method accessible within the class itself and by derived classes, but not from outside of these classes.
		// The 'override' keyword indicates that this method is providing a new implementation for a method defined in the base DbContext class.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed data for Categories table.
			modelBuilder.Entity<Category>().HasData(new Category[]
			{
				new Category {Id=1, Name="Sports"},
				new Category {Id=2, Name="Action"},
				new Category {Id=3, Name="Adventure"},
				new Category {Id=4, Name="Racing"},
				new Category {Id=5, Name="Fighting"},
				new Category {Id=6, Name="Film"},
				new Category {Id=7, Name="Horror"}
			});

			// Seed data for Devices table.
			modelBuilder.Entity<Device>().HasData(new Device[]
			{
				new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
				new Device { Id = 2, Name = "xbox", Icon = "bi bi-xbox" },
				new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
				new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }

			});

			// Configuring the GameDevice entity to use a composite primary key consisting of GameId and DeviceId.
			modelBuilder.Entity<GameDevice>()
				.HasKey(e => new { e.GameId, e.DeviceId });

			// Call the base class's OnModelCreating method to ensure any additional configuration is applied.
			base.OnModelCreating(modelBuilder);
		}
	}
}
