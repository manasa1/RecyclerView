using System;
using System.Linq;

using Android.Views;
using Android.Support.V7.Widget;

using FormsToolkit.Extensions;
using FormsToolkit.Droid.Renderers;
using Xamarin.Forms;
using FormsToolkit.Droid.Holders;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

namespace FormsToolkit.Droid.Adapters
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {

        WeakReference<RecyclerViewRenderer> RendererReference;

        public RecyclerAdapter(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        public override int ItemCount
        {
            get
            {
                if (RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                    return renderer.Element.ItemsSource?.Count() ?? 0;
                return 0;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
            {
                // Get Item
                var items = renderer.Element.ItemsSource;
                var item = items.ElementAt<object>(position);

                if (item == null)
                    return;

                // Generate from DT
                var view = renderer.Element.GenerateView(item);

                // Convert
                var factory = Platform.CreateRenderer(view);
                var measure = view.Measure(renderer.Element.Width, renderer.Element.Height, MeasureFlags.IncludeMargins);

                // Determine width from measure
                var width = measure.Request.Width;
                if (view.HorizontalOptions.Expands && width < renderer.Element.Width)
                    width = renderer.Element.Width;

                // Determine height from measure
                var height = measure.Request.Height;
                if (view.VerticalOptions.Expands && height < renderer.Element.Height)
                    height = renderer.Element.Height;

                // Layout (Using Orientation)
                int widthMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec((int) width, MeasureSpecMode.AtMost);
                int heightMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(200, MeasureSpecMode.Unspecified);
                factory.View.Measure(widthMeasureSpec, heightMeasureSpec);

                var w = factory.View.MeasuredWidth;
                var h = factory.View.MeasuredHeight;

                factory.View.SetMinimumHeight((int) height);

                // Append
                holder.ItemView = factory.View;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            FrameLayout layout = new FrameLayout(Forms.Context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layout.SetMinimumHeight(50);
            layout.SetBackgroundColor(Color.Blue.ToAndroid());

            return new RecyclerViewHolder(layout);
        }
    }
}