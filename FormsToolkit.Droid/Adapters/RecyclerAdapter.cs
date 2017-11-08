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
using static Android.Views.View;
using FormsToolkit.Droid.Views;

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
                Platform.SetRenderer(view, factory);

                var cvg = (ContainerViewGroup) holder.ItemView;
                cvg.Child = factory;

                System.Diagnostics.Debug.WriteLine("");
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new RecyclerViewHolder(new ContainerViewGroup(Forms.Context));
        }
    }
}