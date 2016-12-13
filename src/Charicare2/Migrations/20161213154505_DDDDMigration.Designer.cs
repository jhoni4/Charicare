using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Charicare2.Data;

namespace Charicare2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161213154505_DDDDMigration")]
    partial class DDDDMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Charicare2.Models.ClothesDonate", b =>
                {
                    b.Property<int>("ClothesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DonateTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserId");

                    b.HasKey("ClothesId");

                    b.HasIndex("DonateTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("ClothesDonate");
                });

            modelBuilder.Entity("Charicare2.Models.DonateType", b =>
                {
                    b.Property<int>("DonateTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DonateTypeId");

                    b.ToTable("DonateType");
                });

            modelBuilder.Entity("Charicare2.Models.GoodsDonate", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DonateTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserId");

                    b.HasKey("GoodsId");

                    b.HasIndex("DonateTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("GoodsDonate");
                });

            modelBuilder.Entity("Charicare2.Models.MedicalDonate", b =>
                {
                    b.Property<int>("MedicalId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DonateTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 55);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserId");

                    b.HasKey("MedicalId");

                    b.HasIndex("DonateTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicalDonate");
                });

            modelBuilder.Entity("Charicare2.Models.MoneyDonate", b =>
                {
                    b.Property<int>("MoneyId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("DonateTypeId");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("UserId");

                    b.HasKey("MoneyId");

                    b.HasIndex("DonateTypeId");

                    b.ToTable("MoneyDonate");
                });

            modelBuilder.Entity("Charicare2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("Telephone");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Charicare2.Models.ClothesDonate", b =>
                {
                    b.HasOne("Charicare2.Models.DonateType")
                        .WithMany("ClothesDonates")
                        .HasForeignKey("DonateTypeId");

                    b.HasOne("Charicare2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Charicare2.Models.GoodsDonate", b =>
                {
                    b.HasOne("Charicare2.Models.DonateType")
                        .WithMany("GoodsDonates")
                        .HasForeignKey("DonateTypeId");

                    b.HasOne("Charicare2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Charicare2.Models.MedicalDonate", b =>
                {
                    b.HasOne("Charicare2.Models.DonateType")
                        .WithMany("MedicalDonates")
                        .HasForeignKey("DonateTypeId");

                    b.HasOne("Charicare2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Charicare2.Models.MoneyDonate", b =>
                {
                    b.HasOne("Charicare2.Models.DonateType")
                        .WithMany("MoneyDonates")
                        .HasForeignKey("DonateTypeId");
                });
        }
    }
}
