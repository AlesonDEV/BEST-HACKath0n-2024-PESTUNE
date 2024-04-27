﻿// <auto-generated />
using System;
using BloodFlow.DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodFlow.DataLayer.Migrations
{
    [DbContext(typeof(BloodFlowDbContext))]
    partial class BloodFlowDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.BloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("blood_type");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("city");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("contact_type");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("blood_type_id");

                    b.HasKey("Id");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("donor");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int")
                        .HasColumnName("house_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("StreetId")
                        .HasColumnType("int")
                        .HasColumnName("street_id");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("donor_center");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorCenterContact", b =>
                {
                    b.Property<int>("DonorCenterId")
                        .HasColumnType("int")
                        .HasColumnName("donor_center_id");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int")
                        .HasColumnName("contact_type_id");

                    b.Property<string>("ContactValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_value");

                    b.HasKey("DonorCenterId", "ContactTypeId");

                    b.HasIndex("ContactTypeId");

                    b.ToTable("donor_center_contact");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorOrder", b =>
                {
                    b.Property<int>("DonorId")
                        .HasColumnType("int")
                        .HasColumnName("donor_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.HasKey("DonorId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("donor_order");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorSession", b =>
                {
                    b.Property<int>("DonorId")
                        .HasColumnType("int")
                        .HasColumnName("donor_id");

                    b.Property<int>("SessionId")
                        .HasColumnType("int")
                        .HasColumnName("session_id");

                    b.HasKey("DonorId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("donor_session");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Importance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("importance");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodVolume")
                        .HasColumnType("int")
                        .HasColumnName("blood_volume");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("DonorCenterId")
                        .HasColumnType("int")
                        .HasColumnName("donor_center_id");

                    b.Property<int>("ImportanceId")
                        .HasColumnType("int")
                        .HasColumnName("importance_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("DonorCenterId");

                    b.HasIndex("ImportanceId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_birthday");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int")
                        .HasColumnName("house_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("PhotoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("photo_link");

                    b.Property<int>("StreetId")
                        .HasColumnType("int")
                        .HasColumnName("street_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.PersonContact", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("peson_id");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int")
                        .HasColumnName("contact_type_id");

                    b.Property<string>("ContactValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_value");

                    b.HasKey("PersonId", "ContactTypeId");

                    b.HasIndex("ContactTypeId");

                    b.ToTable("person_contact");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("blood_type_id");

                    b.Property<int>("BloodVolume")
                        .HasColumnType("int")
                        .HasColumnName("blood_volume");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int>("DonorCenterId")
                        .HasColumnType("int")
                        .HasColumnName("donor_center_id");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id");

                    b.Property<int?>("StateSessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateSessionId");

                    b.ToTable("session");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.SessionDonorCenter", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("int")
                        .HasColumnName("session_id");

                    b.Property<int>("DonorCenterId")
                        .HasColumnType("int")
                        .HasColumnName("donor_center_id");

                    b.HasKey("SessionId", "DonorCenterId");

                    b.HasIndex("DonorCenterId");

                    b.ToTable("session_donor_center");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.StateSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("state_session");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("street");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Donor", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.BloodType", "BloodType")
                        .WithMany("Donors")
                        .HasForeignKey("BloodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodType");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorCenter", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.Street", "Street")
                        .WithMany("DonorCenters")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorCenterContact", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.ContactType", "ContactType")
                        .WithMany("DonorCenterContacts")
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.DonorCenter", "DonorCenter")
                        .WithMany("DonorCenterContacts")
                        .HasForeignKey("DonorCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");

                    b.Navigation("DonorCenter");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorOrder", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.Donor", "Donor")
                        .WithMany("DonorOrders")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.Order", "Order")
                        .WithMany("DonorOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorSession", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.Donor", "Donor")
                        .WithMany("DonorSessions")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.Session", "Session")
                        .WithMany("DonorSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Order", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.DonorCenter", "DonorCenter")
                        .WithMany("Orders")
                        .HasForeignKey("DonorCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.Importance", "Importance")
                        .WithMany("Orders")
                        .HasForeignKey("ImportanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonorCenter");

                    b.Navigation("Importance");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Person", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.PersonContact", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.ContactType", "ContactType")
                        .WithMany("PersonContacts")
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.Person", "Person")
                        .WithMany("PersonContacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Session", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.StateSession", null)
                        .WithMany("Sessions")
                        .HasForeignKey("StateSessionId");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.SessionDonorCenter", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.DonorCenter", "DonorCenter")
                        .WithMany("SessionDonorCenters")
                        .HasForeignKey("DonorCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodFlow.DataLayer.Entities.Session", "Session")
                        .WithMany("SessionDonorCenters")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonorCenter");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Street", b =>
                {
                    b.HasOne("BloodFlow.DataLayer.Entities.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.BloodType", b =>
                {
                    b.Navigation("Donors");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.City", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.ContactType", b =>
                {
                    b.Navigation("DonorCenterContacts");

                    b.Navigation("PersonContacts");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Donor", b =>
                {
                    b.Navigation("DonorOrders");

                    b.Navigation("DonorSessions");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.DonorCenter", b =>
                {
                    b.Navigation("DonorCenterContacts");

                    b.Navigation("Orders");

                    b.Navigation("SessionDonorCenters");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Importance", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Order", b =>
                {
                    b.Navigation("DonorOrders");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Person", b =>
                {
                    b.Navigation("PersonContacts");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Session", b =>
                {
                    b.Navigation("DonorSessions");

                    b.Navigation("SessionDonorCenters");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.StateSession", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("BloodFlow.DataLayer.Entities.Street", b =>
                {
                    b.Navigation("DonorCenters");
                });
#pragma warning restore 612, 618
        }
    }
}
