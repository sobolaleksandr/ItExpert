using Microsoft.EntityFrameworkCore;


namespace ItExpert.WebAPI;

public sealed class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		Database.EnsureCreated(); // создаем базу данных при первом обращении
	}

	public DbSet<BusinessObjectModel> Models { get; set; } = null!;
}