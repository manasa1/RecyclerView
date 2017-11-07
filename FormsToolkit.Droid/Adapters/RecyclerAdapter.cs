using System;
using System.Linq;

using Android.Views;
using Android.Support.V7.Widget;

using FormsToolkit.Extensions;
using FormsToolkit.Droid.Renderers;

namespace FormsToolkit.Droid.Adapters
{
    public class RecyclerAdapter : RecyclerView.Adapter
    {

        WeakReference<RecyclerViewRenderer> RendererReference;

        public RecyclerAdapter(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
            var i = ItemCount;
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
            throw new NotImplementedException();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            throw new NotImplementedException();
        }
    }
}