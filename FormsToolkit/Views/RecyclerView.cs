using FormsToolkit.Builders;
using FormsToolkit.Enumerations;
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

#region Bindable Properties
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
            44d,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnRowHeightChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(RowHeight))));

        public static readonly BindableProperty RowWidthProperty = BindableProperty.Create(
            nameof(RowHeight),
            typeof(double),
            typeof(RecyclerView),
            44d,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnRowWidthChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(RowWidth))));

        public static readonly BindableProperty HasUnevenRowsProperty = BindableProperty.Create(
            nameof(HasUnevenRows),
            typeof(bool),
            typeof(RecyclerView),
            true,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnHasUnevenRowsChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(HasUnevenRows))));

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
            nameof(Orientation),
            typeof(ListOrientation),
            typeof(RecyclerView),
            ListOrientation.Vertical,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnOrientationChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(Orientation))));

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(RecyclerView),
            null,
            propertyChanged: (bindable, oldValue, newValue) => ((RecyclerView)bindable).OnTemplateChanged?.Invoke(bindable, new PropertyChangingEventArgs(nameof(ItemTemplate))));
#endregion

#region Events
        public event PropertyChangingEventHandler OnRowHeightChanged;

        public event PropertyChangingEventHandler OnRowWidthChanged;

        public event PropertyChangingEventHandler OnHasUnevenRowsChanged;

        public event PropertyChangingEventHandler OnItemsSourceChanged;

        public event PropertyChangingEventHandler OnOrientationChanged;

        public event PropertyChangingEventHandler OnTemplateChanged;
#endregion

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public double RowHeight
        {
            get => (double) GetValue(RowHeightProperty);
            set => SetValue(RowHeightProperty, value);
        }
        
        public double RowWidth
        {
            get => (double)GetValue(RowWidthProperty);
            set => SetValue(RowWidthProperty, value);
        }

        public bool HasUnevenRows
        {
            get => (bool) GetValue(HasUnevenRowsProperty);
            set => SetValue(HasUnevenRowsProperty, value);
        }

        public ListOrientation Orientation
        {
            get => (ListOrientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public RecyclerView()
        {
            ItemTemplate = TemplateBuilder.GenerateDefaultTemplate();
        }

    }
}
