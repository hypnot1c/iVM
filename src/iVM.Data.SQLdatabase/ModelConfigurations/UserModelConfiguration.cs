using Microsoft.Data.Entity.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Model;

namespace iVM.Data.SQLdatabase.ModelConfigurations
{
  public class UserModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<User> builder)
    {
      builder.Property(p => p.ID).IsRequired();
      builder.Property(p => p.Login).IsRequired();
    }
  }
}
