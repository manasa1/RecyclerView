using System;
using System.Linq;

using Android.Support.V7.Widget.Helper;
using Android.Support.V7.Widget;

using FormsToolkit.Droid.Renderers;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;

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

            // TODO - There must be a better way...
            var t = renderer.Element.ItemsSource.GetType();
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
            {
                var method = t.GetMethods().Where(m => m.Name.Equals("Move")).FirstOrDefault();
                method?.Invoke(renderer.Element.ItemsSource, new object[] { viewHolder.AdapterPosition, target.AdapterPosition });
            }

            return true;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return;

            renderer.Adapter.NotifyItemRemoved(viewHolder.AdapterPosition);
        }

        public override bool IsItemViewSwipeEnabled => false;

        public override bool IsLongPressDragEnabled
        {
            get
            {
                if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                    return false;

                return renderer.Element.CanReorder;
            }
        }
    }
}