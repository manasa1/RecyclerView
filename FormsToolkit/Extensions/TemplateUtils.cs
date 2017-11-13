using Xamarin.Forms;

namespace FormsToolkit.Extensions
{
    public static class TemplateUtils
    {

        public static View GenerateView(this DataTemplate template, BindableObject bindable, object context)
        {
            if (template is DataTemplateSelector)
                template = ((DataTemplateSelector)template).SelectTemplate(context, bindable);

            var view = (View) template.CreateContent();
            view.BindingContext = context;

            return view;
        }

    }
}
