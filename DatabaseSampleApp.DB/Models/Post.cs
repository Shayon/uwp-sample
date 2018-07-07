namespace DatabaseSampleApp.DB.Models
{
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
            get => _postId;
            set => SetProperty(ref _postId, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public int TopicId
        {
            get => _topicId;
            set => SetProperty(ref _topicId, value);
        }

        public Topic Topic
        {
            get => _topic;
            set => SetProperty(ref _topic, value);
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
            return TopicId;
        }
    }
}
