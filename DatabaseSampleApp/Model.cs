
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (UseInpc)
            {
                modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
            }
        }

        private const bool UseInpc = true;
    }

    public interface IHasServerId
    {
        int? ServerId { get; }
    }

    public abstract class BaseModel : IHasServerId, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int? _serverId;

        public int? ServerId
        {
            get { return _serverId; }
            set { SetProperty(ref _serverId, value); }
        }

        public abstract int GetScopeId();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return false;

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }


    public class Website : BaseModel
    {
        private int? _websiteId;
        private string _url;
        private ICollection<Blog> _blogs = new ObservableHashSet<Blog>();
        private string _foo1;
        private string _foo2;
        private string _foo3;
        private string _foo4;
        private string _foo5;
        private string _foo6;
        private string _foo7;
        private string _foo8;
        private string _foo9;
        private string _foo10;

        public int? WebsiteId
        {
            get { return _websiteId; }
            set { SetProperty(ref _websiteId, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public ICollection<Blog> Blogs
        {
            get { return _blogs; }
            set { SetProperty(ref _blogs, value); }
        }

        public string Foo1
        {
            get { return _foo1; }
            set { SetProperty(ref _foo1, value); }
        }

        public string Foo2
        {
            get { return _foo2; }
            set { SetProperty(ref _foo2, value); }
        }

        public string Foo3
        {
            get { return _foo3; }
            set { SetProperty(ref _foo3, value); }
        }

        public string Foo4
        {
            get { return _foo4; }
            set { SetProperty(ref _foo4, value); }
        }

        public string Foo5
        {
            get { return _foo5; }
            set { SetProperty(ref _foo5, value); }
        }

        public string Foo6
        {
            get { return _foo6; }
            set { SetProperty(ref _foo6, value); }
        }

        public string Foo7
        {
            get { return _foo7; }
            set { SetProperty(ref _foo7, value); }
        }

        public string Foo8
        {
            get { return _foo8; }
            set { SetProperty(ref _foo8, value); }
        }

        public string Foo9
        {
            get { return _foo9; }
            set { SetProperty(ref _foo9, value); }
        }

        public string Foo10
        {
            get { return _foo10; }
            set { SetProperty(ref _foo10, value); }
        }

        public override int GetScopeId()
        {
            return -1;
        }
    }

    public class Blog : BaseModel
    {
        private string _foo1;
        private string _foo2;
        private string _foo3;
        private string _foo4;
        private string _foo5;
        private string _foo6;
        private string _foo7;
        private string _foo8;
        private string _foo9;
        private string _foo10;
        private int? _blogId;
        private Website _website;
        private int _websiteId;
        private string _domainUrl;
        private ICollection<Topic> _topics = new ObservableHashSet<Topic>();

        public int? BlogId
        {
            get { return _blogId; }
            set { SetProperty(ref _blogId, value); }
        }

        public Website Website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }

        public int WebsiteId
        {
            get { return _websiteId; }
            set { SetProperty(ref _websiteId, value); }
        }

        public string DomainUrl
        {
            get { return _domainUrl; }
            set { SetProperty(ref _domainUrl, value); }
        }

        public string Foo1
        {
            get { return _foo1; }
            set { SetProperty(ref _foo1, value); }
        }

        public string Foo2
        {
            get { return _foo2; }
            set { SetProperty(ref _foo2, value); }
        }

        public string Foo3
        {
            get { return _foo3; }
            set { SetProperty(ref _foo3, value); }
        }

        public string Foo4
        {
            get { return _foo4; }
            set { SetProperty(ref _foo4, value); }
        }

        public string Foo5
        {
            get { return _foo5; }
            set { SetProperty(ref _foo5, value); }
        }

        public string Foo6
        {
            get { return _foo6; }
            set { SetProperty(ref _foo6, value); }
        }

        public string Foo7
        {
            get { return _foo7; }
            set { SetProperty(ref _foo7, value); }
        }

        public string Foo8
        {
            get { return _foo8; }
            set { SetProperty(ref _foo8, value); }
        }

        public string Foo9
        {
            get { return _foo9; }
            set { SetProperty(ref _foo9, value); }
        }

        public string Foo10
        {
            get { return _foo10; }
            set { SetProperty(ref _foo10, value); }
        }

        public ICollection<Topic> Topics
        {
            get { return _topics; }
            set { SetProperty(ref _topics, value); }
        }

        public override int GetScopeId()
        {
            return WebsiteId;
        }
    }

    public class Topic : BaseModel
    {
        private string _foo1;
        private string _foo2;
        private string _foo3;
        private string _foo4;
        private string _foo5;
        private string _foo6;
        private string _foo7;
        private string _foo8;
        private string _foo9;
        private string _foo10;
        private int? _topicId;
        private Blog _blog;
        private int _blogId;
        private string _topicName;
        private string _url;
        private ICollection<Post> _posts = new ObservableHashSet<Post>();

        public int? TopicId
        {
            get { return _topicId; }
            set { SetProperty(ref _topicId, value); }
        }

        public Blog Blog
        {
            get { return _blog; }
            set { SetProperty(ref _blog, value); }
        }

        public int BlogId
        {
            get { return _blogId; }
            set { SetProperty(ref _blogId, value); }
        }

        public string TopicName
        {
            get { return _topicName; }
            set { SetProperty(ref _topicName, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public string Foo1
        {
            get { return _foo1; }
            set { SetProperty(ref _foo1, value); }
        }

        public string Foo2
        {
            get { return _foo2; }
            set { SetProperty(ref _foo2, value); }
        }

        public string Foo3
        {
            get { return _foo3; }
            set { SetProperty(ref _foo3, value); }
        }

        public string Foo4
        {
            get { return _foo4; }
            set { SetProperty(ref _foo4, value); }
        }

        public string Foo5
        {
            get { return _foo5; }
            set { SetProperty(ref _foo5, value); }
        }

        public string Foo6
        {
            get { return _foo6; }
            set { SetProperty(ref _foo6, value); }
        }

        public string Foo7
        {
            get { return _foo7; }
            set { SetProperty(ref _foo7, value); }
        }

        public string Foo8
        {
            get { return _foo8; }
            set { SetProperty(ref _foo8, value); }
        }

        public string Foo9
        {
            get { return _foo9; }
            set { SetProperty(ref _foo9, value); }
        }

        public string Foo10
        {
            get { return _foo10; }
            set { SetProperty(ref _foo10, value); }
        }

        public ICollection<Post> Posts
        {
            get { return _posts; }
            set { SetProperty(ref _posts, value); }
        }

        public override int GetScopeId()
        {
            return BlogId;
        }
    }

    public class Post : BaseModel
    {
        private string _foo1;
        private string _foo2;
        private string _foo3;
        private string _foo4;
        private string _foo5;
        private string _foo6;
        private string _foo7;
        private string _foo8;
        private string _foo9;
        private string _foo10;
        private int? _postId;
        private string _title;
        private string _content;
        private int _topicId;
        private Topic _topic;

        public int? PostId
        {
            get { return _postId; }
            set { SetProperty(ref _postId, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public int TopicId
        {
            get { return _topicId; }
            set { SetProperty(ref _topicId, value); }
        }

        public Topic Topic
        {
            get { return _topic; }
            set { SetProperty(ref _topic, value); }
        }

        public string Foo1
        {
            get { return _foo1; }
            set { SetProperty(ref _foo1, value); }
        }

        public string Foo2
        {
            get { return _foo2; }
            set { SetProperty(ref _foo2, value); }
        }

        public string Foo3
        {
            get { return _foo3; }
            set { SetProperty(ref _foo3, value); }
        }

        public string Foo4
        {
            get { return _foo4; }
            set { SetProperty(ref _foo4, value); }
        }

        public string Foo5
        {
            get { return _foo5; }
            set { SetProperty(ref _foo5, value); }
        }

        public string Foo6
        {
            get { return _foo6; }
            set { SetProperty(ref _foo6, value); }
        }

        public string Foo7
        {
            get { return _foo7; }
            set { SetProperty(ref _foo7, value); }
        }

        public string Foo8
        {
            get { return _foo8; }
            set { SetProperty(ref _foo8, value); }
        }

        public string Foo9
        {
            get { return _foo9; }
            set { SetProperty(ref _foo9, value); }
        }

        public string Foo10
        {
            get { return _foo10; }
            set { SetProperty(ref _foo10, value); }
        }

        public override int GetScopeId()
        {
            return TopicId;
        }
    }
}