using Akavache;
using CodeHero.Customs;
using CodeHero.PageModels;
using CodeHero.Services;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeHero
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            BlobCache.ApplicationName = "CodeHero";

            FreshIOC.Container.Register<IApiService, ApiService>();
            
            var page = FreshPageModelResolver.ResolvePageModel<CharacterListPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            basicNavContainer.BarTextColor = Color.FromHex("#D42026");
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
