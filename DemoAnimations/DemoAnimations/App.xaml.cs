using DemoAnimations.Controls;
using DemoAnimations.Views;
using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAnimations
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainNavigationPage(new MoviesPage());
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
