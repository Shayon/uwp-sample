using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DatabaseSampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }



        private void Import_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Task.Run(() =>
            {
                using (var context = new BloggingContext())
                {
                    Importers.Importers.Import(context, fakeApiData);
                    context.SaveChanges();
                }
            });
        }

        private void Generate_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            fakeApiData = GenerateFakeApiData();
        }

        private static int generateInt = 0;

        private static List<Website> fakeApiData;

        public static List<Website> GenerateFakeApiData()
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
    }
}
