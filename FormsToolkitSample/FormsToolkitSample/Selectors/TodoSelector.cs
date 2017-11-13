using FormsToolkitSample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormsToolkitSample.Selectors
{
    public class TodoSelector : DataTemplateSelector
    {

        public DataTemplate AllTemplate { get; set; }

        public DataTemplate CompletedTemplate { get; set; }

        public DataTemplate TodoTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Todo todo = item as Todo; // TODO TODOOOOOOOOOO TODO TODO.



            return AllTemplate;
        }
    }
}
