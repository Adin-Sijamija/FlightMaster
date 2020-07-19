﻿// <auto-generated />
using System;
using FlightMaster.WebAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightMaster.WebAPI.Migrations
{
    [DbContext(typeof(FlightMasterContext))]
    [Migration("20200116163032_FlightStatusUpdate2")]
    partial class FlightStatusUpdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Airfield", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Airfields");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Airfield1Id")
                        .HasColumnType("int");

                    b.Property<int>("Airfield2Id")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Airfield1Id");

                    b.HasIndex("Airfield2Id");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.FlightTicketLuxuries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightTicketTypeID")
                        .HasColumnType("int");

                    b.Property<int>("LuxuriesID")
                        .HasColumnType("int");

                    b.Property<int?>("TicketTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightTicketTypeID");

                    b.HasIndex("LuxuriesID");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("FlightTicketLuxuries");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.FlightTicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentTickets")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("MaxTickets")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("TicketTypeID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("TicketTypeID");

                    b.ToTable("FlightTicketTypes");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("EndCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalDuration")
                        .HasColumnType("real");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Luxuries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Luxuries");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.LuxuryPreferences", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("LuxuriesId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "LuxuriesId");

                    b.HasIndex("LuxuriesId");

                    b.ToTable("LuxuryPreferences");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlaneTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPassangeres")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlaneType");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("FlightTicketTypeId")
                        .HasColumnType("int");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("FlightTicketTypeId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.TicketPreferences", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "TicketTypeId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("TicketPreferences");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.TicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Tourism", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Tourisms");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Airfield", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.City", "City")
                        .WithMany("Airfields")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.City", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Customer", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Flight", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Airfield", "Airfield1")
                        .WithMany()
                        .HasForeignKey("Airfield1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Airfield", "Airfield2")
                        .WithMany()
                        .HasForeignKey("Airfield2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.FlightTicketLuxuries", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.FlightTicketType", "FlightTicketType")
                        .WithMany("FlightTicketLuxuries")
                        .HasForeignKey("FlightTicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Luxuries", "Luxuries")
                        .WithMany("FlightTicketLuxuries")
                        .HasForeignKey("LuxuriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.TicketType", null)
                        .WithMany("PlaneTicketLuxuries")
                        .HasForeignKey("TicketTypeId");
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.FlightTicketType", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Flight", "Flight")
                        .WithMany("FlightTicketTypes")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.TicketType", "TicketType")
                        .WithMany("PlaneTicketType")
                        .HasForeignKey("TicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Journey", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Customer", "Customer")
                        .WithMany("Journeys")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.LuxuryPreferences", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Customer", "Customer")
                        .WithMany("LuxuryPreferences")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Luxuries", "Luxuries")
                        .WithMany("LuxuryPreferences")
                        .HasForeignKey("LuxuriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Plane", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Company", "Company")
                        .WithMany("Planes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.PlaneType", "PlaneType")
                        .WithMany()
                        .HasForeignKey("PlaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Ticket", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.FlightTicketType", "FlightTicketType")
                        .WithMany()
                        .HasForeignKey("FlightTicketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Journey", "Journey")
                        .WithMany("Tickets")
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.TicketPreferences", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.Customer", "Customer")
                        .WithMany("TicketPreferences")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.TicketType", "TicketType")
                        .WithMany("TicketPreferences")
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightMaster.WebAPI.Database.ClassModels.Tourism", b =>
                {
                    b.HasOne("FlightMaster.WebAPI.Database.ClassModels.City", null)
                        .WithMany("Tourisms")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}