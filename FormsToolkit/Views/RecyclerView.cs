using FormsToolkit.Builders;
using System.Collections;
using Xamarin.Forms;

namespace FormsToolkit.Views
{
    public class RecyclerView : View
    {

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(RecyclerView),
            null);

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

    }
}
