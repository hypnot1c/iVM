using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;

namespace iVM.Data.SQL.EF.SQLdatabase.Migrations
{
  [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("iVM.Model.EventOccured", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("EventTypeID");

                    b.Property<decimal>("Expense");

                    b.Property<ulong>("Mileage");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Profit");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Model.EventType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Icon");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Model.FillUp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventOccuredID");

                    b.Property<decimal>("LiterCost");

                    b.Property<decimal>("LitresValue");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("iVM.Model.EventOccured", b =>
                {
                    b.HasOne("iVM.Model.EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeID");
                });

            modelBuilder.Entity("iVM.Model.FillUp", b =>
                {
                    b.HasOne("iVM.Model.EventOccured")
                        .WithMany()
                        .HasForeignKey("EventOccuredID");
                });
        }
    }
}
