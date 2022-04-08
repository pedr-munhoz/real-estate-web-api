﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using real_estate_web_api.Infrastructure.Database;

#nullable disable

namespace real_estate_web_api.Migrations
{
    [DbContext(typeof(ServerDbContext))]
    partial class ServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Owners.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.People.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.RealEstates.RealEstate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GrossBuildingArea")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<int>("ParkingSpaces")
                        .HasColumnType("integer");

                    b.Property<long>("RealtorId")
                        .HasColumnType("bigint");

                    b.Property<double?>("RentAmount")
                        .HasColumnType("double precision");

                    b.Property<bool>("RentAvailable")
                        .HasColumnType("boolean");

                    b.Property<double?>("SaleAmount")
                        .HasColumnType("double precision");

                    b.Property<bool>("SaleAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RealtorId");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Realtors.Realtor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Realtors");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Rentals.Rental", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("MonthlyAmount")
                        .HasColumnType("double precision");

                    b.Property<long>("RealEstateId")
                        .HasColumnType("bigint");

                    b.Property<long>("RealtorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.HasIndex("RealtorId");

                    b.HasIndex("TenantId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Tenants.Tenant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InactivatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Income")
                        .HasColumnType("double precision");

                    b.Property<bool?>("InterestedInBuying")
                        .HasColumnType("boolean");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Owners.Owner", b =>
                {
                    b.HasOne("real_estate_web_api.Models.Entities.People.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.RealEstates.RealEstate", b =>
                {
                    b.HasOne("real_estate_web_api.Models.Entities.Owners.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate_web_api.Models.Entities.Realtors.Realtor", "Realtor")
                        .WithMany()
                        .HasForeignKey("RealtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Realtor");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Realtors.Realtor", b =>
                {
                    b.HasOne("real_estate_web_api.Models.Entities.People.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Rentals.Rental", b =>
                {
                    b.HasOne("real_estate_web_api.Models.Entities.RealEstates.RealEstate", "RealEstate")
                        .WithMany()
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate_web_api.Models.Entities.Realtors.Realtor", "Realtor")
                        .WithMany()
                        .HasForeignKey("RealtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate_web_api.Models.Entities.Tenants.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstate");

                    b.Navigation("Realtor");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("real_estate_web_api.Models.Entities.Tenants.Tenant", b =>
                {
                    b.HasOne("real_estate_web_api.Models.Entities.People.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
