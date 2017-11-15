using FormsToolkitSample.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SettingsService))]
namespace FormsToolkitSample.Services
{
    public class SettingsService : ISettingsService
    {

        bool _canReorder;

        public bool CanReorder
        {
            get => _canReorder;
            set => _canReorder = value;
        }

    }
}
