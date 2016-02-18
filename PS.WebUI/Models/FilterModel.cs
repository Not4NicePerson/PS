namespace PS.WebUI.Models
{
	// Объеденяет критерии фильтрации в одну сущность
	public class FilterModel
	{
		public int PageSize { get; set; }
		public int? CategoryId { get; set; }
		public int? CountryId { get; set; }
	}
}