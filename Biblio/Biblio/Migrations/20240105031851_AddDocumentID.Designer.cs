﻿// <auto-generated />
using System;
using Biblio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblio.Migrations
{
    [DbContext(typeof(BiblioDbContext))]
    [Migration("20240105031851_AddDocumentID")]
    partial class AddDocumentID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblio.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BorrowerID")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Biblio.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("DocumentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriberID")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationID");

                    b.HasIndex("SubscriberID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Biblio.Subscriber", b =>
                {
                    b.Property<int>("SubscriberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriberID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriberID");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Biblio.Document", b =>
                {
                    b.HasOne("Biblio.Reservation", "Reservation")
                        .WithMany("Documents")
                        .HasForeignKey("ReservationID");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Biblio.Reservation", b =>
                {
                    b.HasOne("Biblio.Subscriber", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("Biblio.Reservation", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
