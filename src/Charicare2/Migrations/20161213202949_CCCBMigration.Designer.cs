using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Charicare2.Data;

namespace Charicare2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161213202949_CCCBMigration")]
    partial class CCCBMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Charicare2.Models.Donate", b =>
                {
                    b.Property<int>("DonateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DonateTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserId");

                    b.Property<int>("Value");

                    b.HasKey("DonateId");

                    b.ToTable("Donate");
                });

            modelBuilder.Entity("Charicare2.Models.DonateType", b =>
                {
                    b.Property<int>("DonateTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("DonateTypeId");

                    b.ToTable("DonateType");
                });

            modelBuilder.Entity("Charicare2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("Telephone");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
        }
    }
}
