using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CoreGraphics;

using FormsToolkit.Extensions;
using FormsToolkit.Views;
using FormsToolkit.iOS.Renderers;
using FormsToolkit.iOS.Source;
using FormsToolkit.iOS.Cells;
using FormsToolkit.iOS.Delegates;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.iOS.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, UICollectionView>
    {

        Dictionary<object, UIView> _viewCache = new Dictionary<object, UIView>();

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
            var control = new UICollectionView(new CGRect(Element.X, Element.Y, Element.Width, Element.Height), new UICollectionViewFlowLayout());

            control.RegisterClassForCell(typeof(RecycleCell), RecycleCell.Key);
            control.DataSource = new RecyclerViewSource(this);

            control.Delegate = new RecyclerViewDelegateFlowLayout(this);

            control.TranslatesAutoresizingMaskIntoConstraints = true;
            control.AlwaysBounceHorizontal = false;
            control.AlwaysBounceVertical = true;

            SetNativeControl(control);
        }

        void HandleOnItemsSourceChanged(object sender, PropertyChangingEventArgs e)
        {
            Control.ReloadData();
        }

        internal CGRect GenerateFrameForCell(UIView nativeView, NSIndexPath indexPath)
        {
            var x = nativeView.Frame.Width * indexPath.Row;
            var y = nativeView.Frame.Height * indexPath.Section;

            if (Element.Orientation == Enumerations.ListOrientation.Horizontal)
                return new CGRect(x, 0, nativeView.Frame.Width, Element.Height);
            return new CGRect(0, y, Element.Width, nativeView.Frame.Height);
        }

        internal UIView GetNativeViewForItem(UICollectionView collectionView, object item)
        {
            // Check cache
            if (_viewCache.ContainsKey(item))
                return _viewCache[item];

            // Generate from DT
            var view = Element.ItemTemplate.GenerateView(Element, item);

            // Convert
            Platform.SetRenderer(view, Platform.CreateRenderer(view));
            var viewRenderer = Platform.GetRenderer(view);

            var eView = viewRenderer.Element;
            var iView = viewRenderer.NativeView;

            var measure = viewRenderer.Element.Measure(Element.Width, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            iView.Frame = new CGRect(0, 0, Element.Width, measure.Request.Height);

            iView.AutoresizingMask = UIViewAutoresizing.All;
            iView.ContentMode = UIViewContentMode.ScaleToFill;
            eView.Layout(iView.Frame.ToRectangle());

            iView.SetNeedsLayout();

            _viewCache.Add(item, iView);
            return iView;
        }

        internal object GetItemFromNSIndex(NSIndexPath indexPath)
        {
            if (Element.Orientation == Enumerations.ListOrientation.Horizontal)
                return Element.ItemsSource.ElementAt<object>(indexPath.Row);
            return Element.ItemsSource.ElementAt<object>(indexPath.Section);
        }
    }
}