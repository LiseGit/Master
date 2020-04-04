using Master.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MenuPage();
            var masterNavigation = new MenuNavigationContainer("Container");

            MainPage = masterNavigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
