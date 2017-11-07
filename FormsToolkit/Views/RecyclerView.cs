using FormsToolkit.Builders;
using System.Collections;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

[assembly: InternalsVisibleTo("FormsToolkit.Droid")]
[assembly: InternalsVisibleTo("FormsToolkit.iOS")]
[assembly: InternalsVisibleTo("FormsToolkit.UWP")]
namespace FormsToolkit.Views
{
    public class RecyclerView : View
    {

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(RecyclerView),
            null,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnItemsSourceChanged?.Invoke((RecyclerView) bindable, new PropertyChangingEventArgs(nameof(ItemsSource))));

        public event PropertyChangingEventHandler OnItemsSourceChanged; 

        public DataTemplate ItemTemplate;

        public IEnumerable ItemsSource
        {
            get => (IEnumerable) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        
        public RecyclerView()
        {
            ItemTemplate = TemplateBuilder.GenerateDefaultTemplate();
            HorizontalOptions = VerticalOptions = LayoutOptions.FillAndExpand;
        }

        internal View GenerateView(object obj)
        {
            DataTemplate template = ItemTemplate;

            if (template is DataTemplateSelector)
                template = ((DataTemplateSelector)template).SelectTemplate(obj, this);

            return template.CreateContent() as View;
        }

    }
}
