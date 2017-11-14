using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget.Helper;
using Android.Support.V7.Widget;
using FormsToolkit.Droid.Adapters;
using FormsToolkit.Droid.Renderers;

namespace FormsToolkit.Droid.Helpers
{
    public class RecyclerTouchHelper : ItemTouchHelper.Callback
    {

        internal WeakReference<RecyclerViewRenderer> RendererReference;

        public RecyclerTouchHelper(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            const int dragFlags = ItemTouchHelper.Up | ItemTouchHelper.Down;
            const int swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
            return MakeMovementFlags(dragFlags, swipeFlags);
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return false;

            renderer.Adapter.NotifyItemMoved(viewHolder.AdapterPosition, target.AdapterPosition);
            return true;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return;
            
            renderer.Adapter.NotifyItemRemoved(viewHolder.AdapterPosition);
        }
    }
}