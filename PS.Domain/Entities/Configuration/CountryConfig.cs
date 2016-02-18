using System.Data.Entity.ModelConfiguration;
using PS.Domain.Entities.Db;
using Locale = Resources.Resources;

namespace PS.Domain.Entities.Configuration
{
	public class CountryConfig : EntityTypeConfiguration<Country>
	{
		public CountryConfig()
		{
			Property(x => x.Id).HasColumnName(Locale.UniqueKey);
			Property(x => x.Name)
				.HasColumnName(Locale.CountryName)
				.IsRequired();
		}
	}
}