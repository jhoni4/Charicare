using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Charicare2.Data;

namespace Charicare2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161229210209_NEWMIGRATIONS")]
    partial class NEWMIGRATIONS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Charicare2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<long>("Telephone");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Charicare2.Models.Donate", b =>
                {
                    b.Property<int>("DonateId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<int>("DonateTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("Note")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<double>("Value");

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
        }
    }
}
