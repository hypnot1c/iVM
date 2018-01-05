using iVM.Data.Master.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class EventOccuredModelConfiguration : IEntityTypeConfiguration<EventOccuredModel>
  {
    public void Configure(EntityTypeBuilder<EventOccuredModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
