using FormsToolkitSample.Pages;
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
            if (container.BindingContext is TodoViewModel context)
            {
                switch (context.Filter)
                {
                    case "Todo":
                        return TodoTemplate;
                    case "Completed":
                        return CompletedTemplate;
                }
            }

            return AllTemplate;
        }
    }
}
