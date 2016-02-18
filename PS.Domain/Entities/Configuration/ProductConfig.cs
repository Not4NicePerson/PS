using System.Data.Entity.ModelConfiguration;
using PS.Domain.Entities.Db;
using Locale = Resources.Resources;

namespace PS.Domain.Entities.Configuration
{
	public class ProductConfig : EntityTypeConfiguration<Product>
	{
		public ProductConfig()
		{
			Property(x => x.Id).HasColumnName(Locale.UniqueKey);

			Property(x => x.Name)
				.HasColumnName(Locale.ProductName)
				.IsRequired();


			Property(x => x.Price)
				.HasColumnName(Locale.ProductPrice)
				.IsRequired();

			Property(x => x.Image)
				.HasColumnName(Locale.UploadImage);

			Property(x => x.CategoryId)
				.HasColumnName(Locale.CategoryName)
				.IsRequired();

			Property(x => x.CountryId)
				.HasColumnName(Locale.CountryName)
				.IsRequired();

		}
	}
}
