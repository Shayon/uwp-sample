using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseSampleApp.DB.Models
{
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
            get => _websiteId;
            set => SetProperty(ref _websiteId, value);
        }

        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public ICollection<Blog> Blogs
        {
            get => _blogs;
            set => SetProperty(ref _blogs, value);
        }

        public string Foo1
        {
            get => _foo1;
            set => SetProperty(ref _foo1, value);
        }

        public string Foo2
        {
            get => _foo2;
            set => SetProperty(ref _foo2, value);
        }

        public string Foo3
        {
            get => _foo3;
            set => SetProperty(ref _foo3, value);
        }

        public string Foo4
        {
            get => _foo4;
            set => SetProperty(ref _foo4, value);
        }

        public string Foo5
        {
            get => _foo5;
            set => SetProperty(ref _foo5, value);
        }

        public string Foo6
        {
            get => _foo6;
            set => SetProperty(ref _foo6, value);
        }

        public string Foo7
        {
            get => _foo7;
            set => SetProperty(ref _foo7, value);
        }

        public string Foo8
        {
            get => _foo8;
            set => SetProperty(ref _foo8, value);
        }

        public string Foo9
        {
            get => _foo9;
            set => SetProperty(ref _foo9, value);
        }

        public string Foo10
        {
            get => _foo10;
            set => SetProperty(ref _foo10, value);
        }

        public override int GetScopeId()
        {
            return -1;
        }
    }
}
