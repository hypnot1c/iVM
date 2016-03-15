using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using iVM.Data.SQLdatabase;

namespace iVM.Data.SQLdatabase.Migrations
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

                    b.Property<uint>("Expense");

                    b.Property<long>("Mileage");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<uint>("Profit");

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
        }
    }
}
