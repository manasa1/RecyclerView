using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsToolkit.Droid.Adapters;
using FormsToolkit.Droid.Renderers;
using System;
using FormsToolkit.Views;
using Android.Support.V7.Widget;
using FormsToolkit.Droid.Helpers;
using Android.Support.V7.Widget.Helper;
using System.Collections.Specialized;

[assembly:ExportRenderer(typeof(FormsToolkit.Views.RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.Droid.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<Views.RecyclerView, Android.Support.V7.Widget.RecyclerView>
    {

        internal RecyclerAdapter Adapter { get; set; }

        internal LinearLayoutManager Manager { get; set; }

        internal ItemTouchHelper TouchHelper { get; set; }

        internal RecyclerTouchHelper TouchHelperCallback { get; set; }

        public static void Init()
        {
            var dt = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Views.RecyclerView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                    SetupControl();

                SetupElement(e.NewElement);
            }

            if (e.OldElement != null)
                DestroyElement(e.OldElement);
        }

        void SetupElement(Views.RecyclerView element)
        {
            element.OnItemSourceChanged += OnItemSourceChanged;

            // Initial
            OnItemSourceChanged(element, null, element.ItemsSource);
        }

        void DestroyElement(Views.RecyclerView element)
        {
            element.OnItemSourceChanged -= OnItemSourceChanged;
        }

        void OnItemSourceChanged(object sender, object oldSource, object newSource)
        {
            if (oldSource != null)
            {
                if (newSource is INotifyCollectionChanged)
                    ((INotifyCollectionChanged)newSource).CollectionChanged -= OnItemCollectionChanged;
            }

            if (newSource != null)
            {
                if (newSource is INotifyCollectionChanged)
                    ((INotifyCollectionChanged)newSource).CollectionChanged += OnItemCollectionChanged;

                Adapter?.NotifyDataSetChanged();
            }
        }

        void OnItemCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Adapter?.NotifyItemInserted(e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Adapter?.NotifyItemRemoved(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Move:
                    Adapter?.NotifyItemMoved(e.OldStartingIndex, e.NewStartingIndex);
                    break;
            }
        }

        void SetupControl()
        {
            // Initialize
            var recycler = new Android.Support.V7.Widget.RecyclerView(Forms.Context);
            Adapter = new RecyclerAdapter(this);
            Manager = new LinearLayoutManager(Forms.Context);
            TouchHelperCallback = new RecyclerTouchHelper(this);
            TouchHelper = new ItemTouchHelper(TouchHelperCallback);

            // Configure
            Manager.AutoMeasureEnabled = true;
            TouchHelper.AttachToRecyclerView(recycler);

            recycler.SetLayoutManager(Manager);
            recycler.SetAdapter(Adapter);
            recycler.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            // Set
            SetNativeControl(recycler);
        }

    }
}