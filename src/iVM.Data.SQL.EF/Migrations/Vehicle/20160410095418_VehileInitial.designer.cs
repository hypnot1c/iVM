using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace iVM.Data.SQL.EF.Migrations.Vehicle
{
  [DbContext(typeof(VehicleContext))]
    [Migration("20160410095418_VehileInitial")]
    partial class VehileInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("iVM.Vehicle.Model.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.CategoryToType", b =>
                {
                    b.Property<int>("CategoryID");

                    b.Property<int>("TypeID");

                    b.HasKey("CategoryID", "TypeID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandID");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TypeID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.CategoryToType", b =>
                {
                    b.HasOne("iVM.Vehicle.Model.Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("iVM.Vehicle.Model.Type")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });

            modelBuilder.Entity("iVM.Vehicle.Model.Model", b =>
                {
                    b.HasOne("iVM.Vehicle.Model.Brand")
                        .WithMany()
                        .HasForeignKey("BrandID");

                    b.HasOne("iVM.Vehicle.Model.Type")
                        .WithMany()
                        .HasForeignKey("TypeID");
                });
        }
    }
}
