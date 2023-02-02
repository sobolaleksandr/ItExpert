using ItExpert.WebAPI;

using Microsoft.EntityFrameworkCore;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

WebApplication app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/values", async (ApplicationContext context) => await context.Models.ToListAsync());

app.MapPost("/api/values", async (BusinessObject[] objects, ApplicationContext context) =>
{
	await context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE [{nameof(ApplicationContext.Models)}]");

	BusinessObject[] orderedObjects = objects.OrderBy(x => x.Code).ToArray();
	var models = new List<BusinessObjectModel>();
	for (int index = 0; index < orderedObjects.Length; index++)
	{
		BusinessObject orderedObject = orderedObjects[index];
		models.Add(new BusinessObjectModel
		{
			Code = orderedObject.Code,
			Value = orderedObject.Value,
			SerialNumber = index
		});
	}

	await context.Models.AddRangeAsync(models);
	await context.SaveChangesAsync();

	return models;
});

app.Run();