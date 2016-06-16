using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations.Main
{
  [DbContext(typeof(MainContext))]
    [Migration("20160310124407_AddUserLogin")]
    partial class AddUserLogin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("iVM.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.HasKey("ID");
                });
        }
    }
}