using System;
using System.Linq;

using Android.Views;
using Android.Support.V7.Widget;

using FormsToolkit.Extensions;
using FormsToolkit.Droid.Renderers;
using Xamarin.Forms;
using FormsToolkit.Droid.Holders;
using Xamarin.Forms.Platform.Android;

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
                var view = renderer.Element.ItemTemplate.GenerateView(renderer.Element, item);

                // Convert
                Platform.SetRenderer(view, Platform.CreateRenderer(view));
                var viewRenderer = Platform.GetRenderer(view);
                var aView = viewRenderer.View;

                viewRenderer.Tracker.UpdateLayout();
                var measure = viewRenderer.Element.Measure(renderer.Element.Width, double.PositiveInfinity, MeasureFlags.IncludeMargins);

                view.Layout(new Rectangle(0, 0, renderer.Element.Width, measure.Request.Height));

                var actualWidth = Forms.Context.ToPixels(renderer.Element.Width);
                var actualHeight = Forms.Context.ToPixels(measure.Request.Height);

                aView.LayoutParameters = new ViewGroup.LayoutParams((int) actualWidth, (int) actualHeight);
                aView.Layout(0, 0, (int)actualWidth, (int)actualHeight);

                holder.ItemView = aView;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new RecyclerViewHolder(new Android.Views.View(Forms.Context));
        }
    }
}