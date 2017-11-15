using FormsToolkit.Extensions;
using FormsToolkit.UWP.Renderers;

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using FormsToolkit.Views;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FormsToolkit.UWP.Views
{
    public sealed partial class NativeRecyclerListView : UserControl, IDisposable
    {

        public WeakReference<RecyclerViewRenderer> RendererReference { get; set; }

        public NativeRecyclerListView(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
            InitializeComponent();

            SetupElement(renderer.Element);

            EmbeddedList.CanReorderItems = true;
            EmbeddedList.CanDragItems = true;
            EmbeddedList.AllowDrop = true;
        }

        void SetupElement(RecyclerView element)
        {
            if (element == null)
                return;

            element.OnOrientationChanged += OnOrientationChanged;

            OnOrientationChanged(element, null);
        }

        void DestroyElement(RecyclerView element)
        {
            if (element == null)
                return;

            element.OnOrientationChanged -= OnOrientationChanged;
        }

        void OnOrientationChanged(object sender, PropertyChangingEventArgs e)
        {
            var element = sender as RecyclerView;
            if (element == null) return;
            

        }

        void OnTemplateDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer recyclerRenderer))
                return;

            var fbt = sender as FormsBoundTemplate;
            if (fbt == null) return;

            var dataContext = fbt.DataContext;
            if (dataContext == null) return;
            
            // Create
            var view = recyclerRenderer.Element.ItemTemplate.GenerateView(recyclerRenderer.Element, dataContext);
            var frameworkView = ConvertToWindowsView(fbt, view);

            // Append to Container
            fbt.Container.Children.Clear();
            fbt.Container.Children.Add(frameworkView);
        }

        FrameworkElement ConvertToWindowsView(FormsBoundTemplate template, View view)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer recyclerRenderer))
                goto ConvertEnd;

            if (template == null || view == null)
                goto ConvertEnd;

            var renderer = Platform.CreateRenderer(view);
            var measure = view.Measure(recyclerRenderer.Element.Width, double.PositiveInfinity, MeasureFlags.IncludeMargins);

            // Determine width from measure
            var width = recyclerRenderer.Element.Width;

            // Set margins on container
            template.Container.Margin = new Windows.UI.Xaml.Thickness(view.Margin.Left, view.Margin.Top, view.Margin.Right, view.Margin.Bottom);

            view.Layout(new Rectangle(0, 0, width, measure.Request.Height));
            return renderer.ContainerElement;

            ConvertEnd:
            return new Border()
            {
                Background = new SolidColorBrush(Windows.UI.Colors.Purple),
                Height = 200,
                Width = 300
            };
        }

        public void Dispose()
        {
            RendererReference.TryGetTarget(out RecyclerViewRenderer renderer);
            DestroyElement(renderer?.Element);
        }
    }
}
