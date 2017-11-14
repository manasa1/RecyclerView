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

        protected override void OnElementChanged(ElementChangedEventArgs<FormsToolkit.Views.RecyclerView> e)
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
            element.PropertyChanging += OnElementPropertyChanging;

            // Initial
            HandleItemSourceChanged();
        }

        void DestroyElement(Views.RecyclerView element)
        {
            element.PropertyChanging -= OnElementPropertyChanging;
        }

        void OnElementPropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            // Cleanup events
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Create events

            // React
            switch (e.PropertyName)
            {
                case nameof(Element.ItemsSource):
                case nameof(Element.ItemTemplate):
                    HandleItemSourceChanged();
                    break;
            }
        }

        void HandleItemSourceChanged()
        {
            Adapter?.NotifyDataSetChanged();
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