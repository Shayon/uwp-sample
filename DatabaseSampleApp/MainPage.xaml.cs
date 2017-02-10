using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Microsoft.EntityFrameworkCore;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DatabaseSampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private Stopwatch StartNewStopwatch()
        {
            var sw = new Stopwatch();
            sw.Start();
            return sw;
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Import_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SetButtonState(false);
            ImporterTime = null;
            SaveChangesTime = null;

            Stopwatch swImport = new Stopwatch();
            Stopwatch swSave = new Stopwatch();

            await Task.Run(() =>
            {
                using (var context = new BloggingContext())
                {
                    swImport.Start();
                    Importers.Importers.Import(context, fakeApiData);
                    swImport.Stop();

                    swSave.Start();
                    context.SaveChanges();
                    swSave.Stop();
                }
            });

            ImporterTime = swImport.ElapsedMilliseconds;
            SaveChangesTime = swSave.ElapsedMilliseconds;
            SetButtonState(true);
        }

        private void SetButtonState(bool enabled)
        {
            GenerateButton.IsEnabled = enabled;
            ImportButton.IsEnabled = enabled;
            RetrievalButton.IsEnabled = enabled;
        }

        private void Generate_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            fakeApiData = GenerateFakeApiData();
        }

        private static int generateInt = 0;

        private static List<Website> fakeApiData;
        

        public List<Website> GenerateFakeApiData()
        {
            var sw = StartNewStopwatch();
            try
            {
                List<Website> fakeWebsites = new List<Website>();
                for (int x = 0; x < 2; x++)
                {
                    var w = new Website();
                    w.ServerId = generateInt++;
                    w.Foo1 = Guid.NewGuid().ToString();
                    w.Foo2 = Guid.NewGuid().ToString();
                    w.Foo3 = Guid.NewGuid().ToString();
                    w.Foo4 = Guid.NewGuid().ToString();
                    w.Foo5 = Guid.NewGuid().ToString();
                    w.Foo6 = Guid.NewGuid().ToString();
                    w.Foo7 = Guid.NewGuid().ToString();
                    w.Foo8 = Guid.NewGuid().ToString();
                    w.Foo9 = Guid.NewGuid().ToString();
                    w.Foo10 = Guid.NewGuid().ToString();
                    w.Url = Guid.NewGuid().ToString();
                    w.Blogs = new List<Blog>();
                    for (int i = 0; i < 3; i++)
                    {
                        var b = new Blog();
                        b.ServerId = generateInt++;
                        b.Foo1 = Guid.NewGuid().ToString();
                        b.Foo2 = Guid.NewGuid().ToString();
                        b.Foo3 = Guid.NewGuid().ToString();
                        b.Foo4 = Guid.NewGuid().ToString();
                        b.Foo5 = Guid.NewGuid().ToString();
                        b.Foo6 = Guid.NewGuid().ToString();
                        b.Foo7 = Guid.NewGuid().ToString();
                        b.Foo8 = Guid.NewGuid().ToString();
                        b.Foo9 = Guid.NewGuid().ToString();
                        b.Foo10 = Guid.NewGuid().ToString();
                        b.DomainUrl = Guid.NewGuid().ToString();
                        b.Topics = new List<Topic>();
                        for (int j = 0; j < 7; j++)
                        {
                            var t = new Topic();
                            t.ServerId = generateInt++;
                            t.Foo1 = Guid.NewGuid().ToString();
                            t.Foo2 = Guid.NewGuid().ToString();
                            t.Foo3 = Guid.NewGuid().ToString();
                            t.Foo4 = Guid.NewGuid().ToString();
                            t.Foo5 = Guid.NewGuid().ToString();
                            t.Foo6 = Guid.NewGuid().ToString();
                            t.Foo7 = Guid.NewGuid().ToString();
                            t.Foo8 = Guid.NewGuid().ToString();
                            t.Foo9 = Guid.NewGuid().ToString();
                            t.Foo10 = Guid.NewGuid().ToString();
                            t.TopicName = Guid.NewGuid().ToString();
                            t.Url = Guid.NewGuid().ToString();
                            t.Posts = new List<Post>();
                            for (int k = 0; k < 20; k++)
                            {
                                var p = new Post();
                                p.ServerId = generateInt++;
                                p.Foo1 = Guid.NewGuid().ToString();
                                p.Foo2 = Guid.NewGuid().ToString();
                                p.Foo3 = Guid.NewGuid().ToString();
                                p.Foo4 = Guid.NewGuid().ToString();
                                p.Foo5 = Guid.NewGuid().ToString();
                                p.Foo6 = Guid.NewGuid().ToString();
                                p.Foo7 = Guid.NewGuid().ToString();
                                p.Foo8 = Guid.NewGuid().ToString();
                                p.Foo9 = Guid.NewGuid().ToString();
                                p.Foo10 = Guid.NewGuid().ToString();
                                p.Content = Guid.NewGuid().ToString();
                                p.Title = Guid.NewGuid().ToString();
                                t.Posts.Add(p);
                            }
                            b.Topics.Add(t);
                        }
                        w.Blogs.Add(b);
                    }
                    fakeWebsites.Add(w);
                }
                return fakeWebsites;
            }
            finally
            {
                sw.Stop();
                GeneratationTime = sw.ElapsedMilliseconds;
            }
        }


        private long? _generationTime;

        public long? GeneratationTime
        {
            get { return _generationTime; }
            set { SetProperty(ref _generationTime, value); }
        }

        private long? _importerTime;

        public long? ImporterTime
        {
            get { return _importerTime; }
            set { SetProperty(ref _importerTime, value); }
        }

        private long? _saveChangesTime;

        public long? SaveChangesTime
        {
            get { return _saveChangesTime; }
            set { SetProperty(ref _saveChangesTime, value); }
        }

        private long? _retrievalNoTrackingTime;

        public long? RetrievalNoTrackingTime
        {
            get { return _retrievalNoTrackingTime; }
            set { SetProperty(ref _retrievalNoTrackingTime, value); }
        }

        private long? _retrievalTrackingTime;

        public long? RetrievalTrackingTime
        {
            get { return _retrievalTrackingTime; }
            set { SetProperty(ref _retrievalTrackingTime, value); }
        }

        private long? _queryTime;
        
        public long? QueryTime
        {
            get { return _queryTime; }
            set { SetProperty(ref _queryTime, value); }
        }

        private async void RetrievalButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SetButtonState(false);
            RetrievalTrackingTime = null;
            RetrievalNoTrackingTime = null;

            Stopwatch swQuery = new Stopwatch();
            Stopwatch swRetrieval1 = new Stopwatch();
            Stopwatch swRetrieval2 = new Stopwatch();

            await Task.Run(() =>
            {
                using (var context = new BloggingContext())
                {
                    swQuery.Start();
                    var query = context.Websites.Include(w => w.Blogs).ThenInclude(b => b.Topics).ThenInclude(t => t.Posts);
                    var expressionTree = query.Expression;
                    swQuery.Stop();

                    swRetrieval1.Start();
                    var data1 = query.AsNoTracking().ToList();
                    swRetrieval1.Stop();

                    swRetrieval2.Start();
                    var data2 = query.AsTracking().ToList();
                    swRetrieval2.Stop();
                }
            });

            QueryTime = swQuery.ElapsedMilliseconds;
            RetrievalNoTrackingTime = swRetrieval1.ElapsedMilliseconds;
            RetrievalTrackingTime = swRetrieval2.ElapsedMilliseconds;
            SetButtonState(true);
        }


        #region PropertyChangeImplementation

        public event PropertyChangedEventHandler PropertyChanged;

        private bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return false;

            member = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
