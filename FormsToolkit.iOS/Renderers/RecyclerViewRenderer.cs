using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using FormsToolkit.Views;
using FormsToolkit.iOS.Renderers;
using FormsToolkit.iOS.Views;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.iOS.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, UICollectionView>
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

        void DestroyElement(RecyclerView element)
        {
            element.OnItemsSourceChanged -= HandleOnItemsSourceChanged;
        }

        void SetupElement(RecyclerView element)
        {
            element.OnItemsSourceChanged += HandleOnItemsSourceChanged;

            HandleOnItemsSourceChanged(null, null);
        }

        void SetupControl()
        {
            SetNativeControl(new NativeRecyclerListView());
        }

        void HandleOnItemsSourceChanged(object sender, PropertyChangingEventArgs e)
        {
            Control.ReloadData();
        }
    }
}