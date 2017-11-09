using Xamarin.Forms.Platform.UWP;

using System;
using System.Linq;
using System.Collections.Generic;

using FormsToolkit.Views;
using FormsToolkit.UWP.Views;
using FormsToolkit.UWP.Renderers;
using FormsToolkit.UWP.Models;

using Windows.UI.Xaml;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.UWP.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, FrameworkElement>
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
            SetNativeControl(new NativeRecyclerListView(this));
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

        void HandleOnItemTemplateChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            // TODO - Reload Content
        }

        void HandleOnItemsSourceChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            if (Element?.ItemsSource == null)
                return;

            List<ContextRendererContainer<RecyclerViewRenderer>> newSource = new List<ContextRendererContainer<RecyclerViewRenderer>>();

            foreach (var item in Element.ItemsSource)
            {
                newSource.Add(new ContextRendererContainer<RecyclerViewRenderer>()
                {
                    Context = item,
                    Renderer = this
                });
            }

            ((NativeRecyclerListView)Control).EmbeddedList.ItemsSource = newSource;
        }

    }
}
