namespace ItExpert.WebAPI;

public class BusinessObjectModel
{
	public int Code { get; set; }

	public string Value { get; set; } = string.Empty;

	public int Id { get; set; }

	public int SerialNumber { get; set; }
}

public record struct BusinessObject(int Code, string Value);