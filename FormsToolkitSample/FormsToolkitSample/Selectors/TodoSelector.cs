using FormsToolkitSample.Models;
using Xamarin.Forms;

namespace FormsToolkitSample.Selectors
{
    public class TodoSelector : DataTemplateSelector
    {

        public DataTemplate CompletedTemplate { get; set; }

        public DataTemplate TodoTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Todo todo)
                return todo.Completed ? CompletedTemplate : TodoTemplate;
            return TodoTemplate;
        }
    }
}
