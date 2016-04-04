using iVM.Data.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class UserModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.Login).IsRequired();
    }
  }
}
