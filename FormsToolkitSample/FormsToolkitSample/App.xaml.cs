using FormsToolkitSample.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FormsToolkitSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var navigation = new NavigationPage(new TodoListSample());

            navigation.ToolbarItems.Add(new ToolbarItem("Settings", "Settings", HandleSettingsRequest));

            MainPage = navigation;
        }

        void HandleSettingsRequest()
        {
            ((NavigationPage)App.Current.MainPage).PushAsync(new SettingsPage());
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
