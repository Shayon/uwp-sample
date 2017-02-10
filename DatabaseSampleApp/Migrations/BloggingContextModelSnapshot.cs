using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatabaseSampleApp;

namespace DatabaseSampleApp.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("DatabaseSampleApp.Blog", b =>
                {
                    b.Property<int?>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DomainUrl");

                    b.Property<string>("Foo1");

                    b.Property<string>("Foo10");

                    b.Property<string>("Foo2");

                    b.Property<string>("Foo3");

                    b.Property<string>("Foo4");

                    b.Property<string>("Foo5");

                    b.Property<string>("Foo6");

                    b.Property<string>("Foo7");

                    b.Property<string>("Foo8");

                    b.Property<string>("Foo9");

                    b.Property<int?>("ServerId");

                    b.Property<int>("WebsiteId");

                    b.HasKey("BlogId");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("DatabaseSampleApp.Post", b =>
                {
                    b.Property<int?>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Foo1");

                    b.Property<string>("Foo10");

                    b.Property<string>("Foo2");

                    b.Property<string>("Foo3");

                    b.Property<string>("Foo4");

                    b.Property<string>("Foo5");

                    b.Property<string>("Foo6");

                    b.Property<string>("Foo7");

                    b.Property<string>("Foo8");

                    b.Property<string>("Foo9");

                    b.Property<int?>("ServerId");

                    b.Property<string>("Title");

                    b.Property<int>("TopicId");

                    b.HasKey("PostId");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DatabaseSampleApp.Topic", b =>
                {
                    b.Property<int?>("TopicId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Foo1");

                    b.Property<string>("Foo10");

                    b.Property<string>("Foo2");

                    b.Property<string>("Foo3");

                    b.Property<string>("Foo4");

                    b.Property<string>("Foo5");

                    b.Property<string>("Foo6");

                    b.Property<string>("Foo7");

                    b.Property<string>("Foo8");

                    b.Property<string>("Foo9");

                    b.Property<int?>("ServerId");

                    b.Property<string>("TopicName");

                    b.Property<string>("Url");

                    b.HasKey("TopicId");

                    b.HasIndex("BlogId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("DatabaseSampleApp.Website", b =>
                {
                    b.Property<int?>("WebsiteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Foo1");

                    b.Property<string>("Foo10");

                    b.Property<string>("Foo2");

                    b.Property<string>("Foo3");

                    b.Property<string>("Foo4");

                    b.Property<string>("Foo5");

                    b.Property<string>("Foo6");

                    b.Property<string>("Foo7");

                    b.Property<string>("Foo8");

                    b.Property<string>("Foo9");

                    b.Property<int?>("ServerId");

                    b.Property<string>("Url");

                    b.HasKey("WebsiteId");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("DatabaseSampleApp.Blog", b =>
                {
                    b.HasOne("DatabaseSampleApp.Website", "Website")
                        .WithMany("Blogs")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseSampleApp.Post", b =>
                {
                    b.HasOne("DatabaseSampleApp.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseSampleApp.Topic", b =>
                {
                    b.HasOne("DatabaseSampleApp.Blog", "Blog")
                        .WithMany("Topics")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
