using Microsoft.EntityFrameworkCore;


namespace ItExpert.WebAPI;

public sealed class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		Database.EnsureCreated(); // ������� ���� ������ ��� ������ ���������
	}

	public DbSet<BusinessObjectModel> Models { get; set; } = null!;
}