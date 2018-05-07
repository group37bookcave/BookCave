﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace BookCave.Migrations.Store
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Models.EntityModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("Street");

                    b.Property<int?>("ZipCodeId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ZipCodeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AgeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AgeGroups");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AudiobookNarrator", b =>
                {
                    b.Property<int>("AudiobookId");

                    b.Property<int>("NarratorId");

                    b.HasKey("AudiobookId", "NarratorId");

                    b.HasIndex("NarratorId");

                    b.ToTable("AudioBookNarrators");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookAgeGroup", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AgeGroupId");

                    b.HasKey("BookId", "AgeGroupId");

                    b.HasIndex("AgeGroupId");

                    b.ToTable("BookAgeGroups");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookGenre", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("GenreId");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookLanguage", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("LanguageId");

                    b.HasKey("BookId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("BookLanguages");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Composer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Composer");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CountryZipCode", b =>
                {
                    b.Property<int>("CountryId");

                    b.Property<int>("ZipCodeId");

                    b.HasKey("CountryId", "ZipCodeId");

                    b.HasIndex("ZipCodeId");

                    b.ToTable("CountryZipCodes");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("AddressId");

                    b.HasKey("CustomerId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Isbn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Asin");

                    b.Property<string>("Isbn10");

                    b.Property<string>("Isbn13");

                    b.HasKey("Id");

                    b.ToTable("Isbns");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.ItemOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ItemOrders");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Narrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Narrators");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<int?>("CustomerId");

                    b.Property<int?>("PromoCodeId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PromoCodeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.PromoCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<double>("Rate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.SheetMusicComposer", b =>
                {
                    b.Property<int>("SheetMusicId");

                    b.Property<int>("ComposerId");

                    b.HasKey("SheetMusicId", "ComposerId");

                    b.HasIndex("ComposerId");

                    b.ToTable("SheetMusicComposers");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.ZipCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("ZipCodes");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Book", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Product");

                    b.Property<string>("Description");

                    b.Property<int?>("IsbnId");

                    b.Property<int>("Length");

                    b.Property<int?>("PublisherId");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasIndex("IsbnId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.SheetMusic", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Product");


                    b.ToTable("SheetMusics");

                    b.HasDiscriminator().HasValue("SheetMusic");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AudioBook", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Book");

                    b.Property<double?>("Size");

                    b.ToTable("AudioBook");

                    b.HasDiscriminator().HasValue("AudioBook");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Ebook", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Book");

                    b.Property<double?>("Size")
                        .HasColumnName("Ebook_Size");

                    b.ToTable("Ebook");

                    b.HasDiscriminator().HasValue("Ebook");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Hardcover", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Book");


                    b.ToTable("Hardcover");

                    b.HasDiscriminator().HasValue("Hardcover");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Paperback", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.Book");


                    b.ToTable("Paperback");

                    b.HasDiscriminator().HasValue("Paperback");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.DigitalSheetMusic", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.SheetMusic");


                    b.ToTable("DigitalSheetMusic");

                    b.HasDiscriminator().HasValue("DigitalSheetMusic");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.PhysicalSheetMusic", b =>
                {
                    b.HasBaseType("BookCave.Models.EntityModels.SheetMusic");


                    b.ToTable("PhysicalSheetMusic");

                    b.HasDiscriminator().HasValue("PhysicalSheetMusic");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Address", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId");

                    b.HasOne("BookCave.Models.EntityModels.ZipCode", "ZipCode")
                        .WithMany()
                        .HasForeignKey("ZipCodeId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AudiobookNarrator", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.AudioBook", "Book")
                        .WithMany("AudiobookNarrators")
                        .HasForeignKey("AudiobookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Narrator", "Narrator")
                        .WithMany("AudiobookNarrators")
                        .HasForeignKey("NarratorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookAgeGroup", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.AgeGroup", "AgeGroup")
                        .WithMany("BookAgeGroups")
                        .HasForeignKey("AgeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Book", "Book")
                        .WithMany("BookAgeGroups")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookAuthor", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookGenre", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookLanguage", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book", "Book")
                        .WithMany("BookLanguages")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Language", "Language")
                        .WithMany("BookLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CountryZipCode", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Country", "Country")
                        .WithMany("CountryZipCodes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.ZipCode", "ZipCode")
                        .WithMany("CountryZipCodes")
                        .HasForeignKey("ZipCodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CustomerAddress", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Address", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.ItemOrder", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Order", "Order")
                        .WithMany("ItemOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("BookCave.Models.EntityModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Order", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId");

                    b.HasOne("BookCave.Models.EntityModels.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("BookCave.Models.EntityModels.PromoCode", "PromoCode")
                        .WithMany("Orders")
                        .HasForeignKey("PromoCodeId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.SheetMusicComposer", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Composer", "Composer")
                        .WithMany("SheetMusicComposers")
                        .HasForeignKey("ComposerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.SheetMusic", "SheetMusic")
                        .WithMany("SheetMusicComposers")
                        .HasForeignKey("SheetMusicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Book", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Isbn", "Isbn")
                        .WithMany()
                        .HasForeignKey("IsbnId");

                    b.HasOne("BookCave.Models.EntityModels.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}
