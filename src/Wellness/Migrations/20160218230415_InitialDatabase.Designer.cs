using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Wellness.Models;

namespace Wellness.Migrations
{
    [DbContext(typeof(WellnessContext))]
    [Migration("20160218230415_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Wellness.Models.Excercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ExcerciseTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.ExcerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Resource");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("BodyType");

                    b.Property<double>("BoneMass");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("GenderType");

                    b.Property<double>("Height");

                    b.Property<double>("IdealBodyWeight");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PersonName");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("TeamId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserExcercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<int>("ExcerciseId");

                    b.Property<int>("Reps");

                    b.Property<int>("Sets");

                    b.Property<int>("Slot");

                    b.Property<int?>("WellnessUserWorkoutId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserExcerciseMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Reps");

                    b.Property<int>("Result");

                    b.Property<int>("Sets");

                    b.Property<int>("Slot");

                    b.Property<int>("Week");

                    b.Property<int?>("WellnessUserExcerciseId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BasalMetabolicRate");

                    b.Property<double>("BodyMassIndex");

                    b.Property<int>("ClothesWeight");

                    b.Property<DateTime>("Created");

                    b.Property<double>("FatFreeMass");

                    b.Property<double>("FatMass");

                    b.Property<double>("MuscleMass");

                    b.Property<string>("UserName");

                    b.Property<double>("Weight");

                    b.Property<string>("WellnessUserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.Property<int>("Weeks");

                    b.Property<string>("WellnessUserId");

                    b.Property<string>("WorkoutName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Wellness.Models.WellnessUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Wellness.Models.Excercise", b =>
                {
                    b.HasOne("Wellness.Models.ExcerciseType")
                        .WithMany()
                        .HasForeignKey("ExcerciseTypeId");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUser", b =>
                {
                    b.HasOne("Wellness.Models.Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserExcercise", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUserWorkout")
                        .WithMany()
                        .HasForeignKey("WellnessUserWorkoutId");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserExcerciseMetric", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUserExcercise")
                        .WithMany()
                        .HasForeignKey("WellnessUserExcerciseId");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserMetric", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUser")
                        .WithMany()
                        .HasForeignKey("WellnessUserId");
                });

            modelBuilder.Entity("Wellness.Models.WellnessUserWorkout", b =>
                {
                    b.HasOne("Wellness.Models.WellnessUser")
                        .WithMany()
                        .HasForeignKey("WellnessUserId");
                });
        }
    }
}
