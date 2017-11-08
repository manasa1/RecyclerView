using Xamarin.Forms.Platform.UWP;

using FormsToolkit.Views;
using FormsToolkit.UWP.Views;
using FormsToolkit.UWP.Renderers;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.UWP.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, Windows.UI.Xaml.Controls.ListView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<RecyclerView> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                    SetupControl();

                SetupElement(e.NewElement);
            }

            if (e.OldElement != null)
                DestroyElement(e.OldElement);

            base.OnElementChanged(e);
        }

        void SetupControl()
        {
            SetNativeControl(new NativeRecyclerListView());
        }

        void SetupElement(RecyclerView element)
        {
            element.OnItemsSourceChanged += HandleOnItemsSourceChanged;

            HandleOnItemsSourceChanged(element, null);
            HandleOnItemTemplateChanged(element, null);
        }

        void DestroyElement(RecyclerView element)
        {
            element.OnItemsSourceChanged -= HandleOnItemsSourceChanged;
        }

        void HandleOnItemsSourceChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            Control.ItemsSource = Element.ItemsSource;
        }

        void HandleOnItemTemplateChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
        }

    }
}
