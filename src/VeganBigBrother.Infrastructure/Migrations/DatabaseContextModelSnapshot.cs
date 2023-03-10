// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeganBigBrother.Infrastructure.Database;

#nullable disable

namespace VeganBigBrother.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VeganBigBrother.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SensorParts");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorPartReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SensorID")
                        .HasColumnType("int");

                    b.Property<int>("SensorPartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SensorID");

                    b.HasIndex("SensorPartID");

                    b.ToTable("SensorPartReadings");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorSensorPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<int>("SensorPartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.HasIndex("SensorPartId");

                    b.ToTable("SensorPartParts");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.Sensor", b =>
                {
                    b.HasOne("VeganBigBrother.Core.Entities.Location", "Location")
                        .WithMany("Sensors")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorPartReading", b =>
                {
                    b.HasOne("VeganBigBrother.Core.Entities.Sensor", "Sensor")
                        .WithMany("SensorPartsReadings")
                        .HasForeignKey("SensorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VeganBigBrother.Core.Entities.SensorPart", "SensorPart")
                        .WithMany("SensorPartReadings")
                        .HasForeignKey("SensorPartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");

                    b.Navigation("SensorPart");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorSensorPart", b =>
                {
                    b.HasOne("VeganBigBrother.Core.Entities.Sensor", "Sensor")
                        .WithMany("SensorSensorParts")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VeganBigBrother.Core.Entities.SensorPart", "SensorPart")
                        .WithMany("SensorSensorParts")
                        .HasForeignKey("SensorPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");

                    b.Navigation("SensorPart");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.Location", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.Sensor", b =>
                {
                    b.Navigation("SensorPartsReadings");

                    b.Navigation("SensorSensorParts");
                });

            modelBuilder.Entity("VeganBigBrother.Core.Entities.SensorPart", b =>
                {
                    b.Navigation("SensorPartReadings");

                    b.Navigation("SensorSensorParts");
                });
#pragma warning restore 612, 618
        }
    }
}
