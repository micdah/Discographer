using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discographer.Domain.Entities
{
    public class ApplicationSettings
    {
        public int Id { get; set; }
        public string DiscogsToken { get; set; }
    }

    public class ApplicationSettingsConfiguration : IEntityTypeConfiguration<ApplicationSettings>
    {
        public void Configure(EntityTypeBuilder<ApplicationSettings> entity)
        {
            entity.HasKey(e => e.Id);
        }
    }
}
