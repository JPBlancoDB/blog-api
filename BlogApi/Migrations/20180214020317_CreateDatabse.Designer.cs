using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlogApi.Repositories;

namespace BlogApi.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20180214020317_CreateDatabse")]
    partial class CreateDatabse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4");

            modelBuilder.Entity("BlogApi.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Slug");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("BlogApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("LastLoggedAt");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BlogApi.Entities.Post", b =>
                {
                    b.HasOne("BlogApi.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });
        }
    }
}
