using System.Text;
using WebApplicationDevelopment.Models.DTO;

namespace WebApplicationDevelopment.Utils
{
	public static class FilesCSV
	{
		public static string GetCsv(IEnumerable<ProductDto> productDto)
		{
			var sb = new StringBuilder();
            foreach (var item in productDto)
            {
				sb.AppendLine($"{item.Id};{item.Name};{item.Description};{item.Price};{item.CategoryId}");
            }
			return sb.ToString();
        }
	}
}
