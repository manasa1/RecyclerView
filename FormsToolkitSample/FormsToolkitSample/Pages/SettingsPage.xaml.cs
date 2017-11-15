using FormsToolkitSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsToolkitSample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{

        readonly ISettingsService SettingsService;

		public SettingsPage ()
		{
            SettingsService = DependencyService.Get<ISettingsService>();
            InitializeComponent ();
		}

        void OnSaveRequest(object sender, PropertyChangingEventArgs args)
        {
            ((NavigationPage)Application.Current.MainPage).PopAsync();
        }

        protected override void OnAppearing()
        {
            CanReorderSwitch.IsToggled = SettingsService.CanReorder;
            base.OnAppearing();
        }

        void OnCanReorderToggled(object sender, PropertyChangingEventArgs args)
        {
            SettingsService.CanReorder = CanReorderSwitch.IsToggled;
        }
    }
}