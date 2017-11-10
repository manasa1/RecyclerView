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
using CoreGraphics;
using FormsToolkit.iOS.Source;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.iOS.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, UICollectionView>
    {
        
        public static void Init()
        {
            var dt = DateTime.Now;
        }

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
            var control = new UICollectionView(new CGRect(0, 0, 300, 256), new UICollectionViewFlowLayout());
            control.RegisterClassForCell(typeof(UICollectionViewCell), "MyCell");
            control.DataSource = new RecyclerViewSource(this);

            SetNativeControl(control);
        }

        void HandleOnItemsSourceChanged(object sender, PropertyChangingEventArgs e)
        {
            Control.ReloadData();
        }
    }
}