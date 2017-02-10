
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DatabaseSampleApp
{
    public class BloggingContext : DbContext
    {
        public DbSet<Website> Websites { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Blogging.db");
        }
    }

    public interface IHasServerId
    {
        int? ServerId { get; }
    }

    public abstract class BaseModel : IHasServerId
    {
        public int? ServerId { get; set; }

        public abstract int GetScopeId();
    }


    public class Website : BaseModel
    {
        public int? WebsiteId { get; set; }

        public string Url { get; set; }

        public List<Blog> Blogs { get; set; }

        public string Foo1 { get; set; }
        public string Foo2 { get; set; }
        public string Foo3 { get; set; }
        public string Foo4 { get; set; }
        public string Foo5 { get; set; }
        public string Foo6 { get; set; }
        public string Foo7 { get; set; }
        public string Foo8 { get; set; }
        public string Foo9 { get; set; }
        public string Foo10 { get; set; }

        public override int GetScopeId()
        {
            return -1;
        }
    }

    public class Blog : BaseModel
    {
        public int? BlogId { get; set; }

        public Website Website { get; set; }

        public int WebsiteId { get; set; }

        public string DomainUrl { get; set; }

        public string Foo1 { get; set; }
        public string Foo2 { get; set; }
        public string Foo3 { get; set; }
        public string Foo4 { get; set; }
        public string Foo5 { get; set; }
        public string Foo6 { get; set; }
        public string Foo7 { get; set; }
        public string Foo8 { get; set; }
        public string Foo9 { get; set; }
        public string Foo10 { get; set; }

        public List<Topic> Topics { get; set; }

        public override int GetScopeId()
        {
            return WebsiteId;
        }
    }

    public class Topic : BaseModel
    {
        public int? TopicId { get; set; }

        public Blog Blog { get; set; }

        public int BlogId { get; set; }

        public string TopicName { get; set; }

        public string Url { get; set; }

        public string Foo1 { get; set; }
        public string Foo2 { get; set; }
        public string Foo3 { get; set; }
        public string Foo4 { get; set; }
        public string Foo5 { get; set; }
        public string Foo6 { get; set; }
        public string Foo7 { get; set; }
        public string Foo8 { get; set; }
        public string Foo9 { get; set; }
        public string Foo10 { get; set; }

        public List<Post> Posts { get; set; }

        public override int GetScopeId()
        {
            return BlogId;
        }
    }

    public class Post : BaseModel
    {
        public int? PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public string Foo1 { get; set; }
        public string Foo2 { get; set; }
        public string Foo3 { get; set; }
        public string Foo4 { get; set; }
        public string Foo5 { get; set; }
        public string Foo6 { get; set; }
        public string Foo7 { get; set; }
        public string Foo8 { get; set; }
        public string Foo9 { get; set; }
        public string Foo10 { get; set; }

        public override int GetScopeId()
        {
            return TopicId;
        }
    }
}