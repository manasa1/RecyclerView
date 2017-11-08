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

        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create(
            nameof(RowHeight),
            typeof(double),
            typeof(RecyclerView),
            -1d,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnRowHeightChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(RowHeight))));

        public static readonly BindableProperty RowWidthProperty = BindableProperty.Create(
            nameof(RowHeight),
            typeof(double),
            typeof(RecyclerView),
            -1d,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnRowWidthChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(RowWidth))));

        public event PropertyChangingEventHandler OnRowHeightChanged;

        public event PropertyChangingEventHandler OnRowWidthChanged;

        public event PropertyChangingEventHandler OnHasUnevenRowsChanged;

        public event PropertyChangingEventHandler OnItemsSourceChanged; 

        public DataTemplate ItemTemplate;

        public IEnumerable ItemsSource
        {
            get => (IEnumerable) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public double RowHeight { get; set; }
        
        public double RowWidth { get; set; }

        public bool HasUnevenRows { get; set; }

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
