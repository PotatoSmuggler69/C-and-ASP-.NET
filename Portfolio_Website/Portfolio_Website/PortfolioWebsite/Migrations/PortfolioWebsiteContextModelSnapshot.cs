﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio_Website.Data;

#nullable disable

namespace PortfolioWebsite.Migrations
{
    [DbContext(typeof(Portfolio_WebsiteContext))]
    partial class PortfolioWebsiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Portfolio_Website.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<DateTime?>("DOA")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("full_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
