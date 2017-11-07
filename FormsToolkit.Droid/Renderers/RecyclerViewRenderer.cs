using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsToolkit.Droid.Adapters;
using FormsToolkit.Droid.Renderers;
using System;
using FormsToolkit.Views;
using Android.Support.V7.Widget;

[assembly:ExportRenderer(typeof(FormsToolkit.Views.RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.Droid.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<Views.RecyclerView, Android.Support.V7.Widget.RecyclerView>
    {

        RecyclerAdapter Adapter;
        LinearLayoutManager Manager;

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

        void SetupElement(Views.RecyclerView newElement)
        {
            newElement.OnItemsSourceChanged += HandleItemSourceChanged;
        }

        void DestroyElement(Views.RecyclerView oldElement)
        {
            oldElement.OnItemsSourceChanged -= HandleItemSourceChanged;
        }

        void HandleItemSourceChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            // TODO - Redraw
            Adapter?.NotifyDataSetChanged();
        }

        void SetupControl()
        {
            // Initialize
            var recycler = new Android.Support.V7.Widget.RecyclerView(Forms.Context);
            Adapter = new RecyclerAdapter(this);
            Manager = new LinearLayoutManager(Forms.Context);

            // Configure
            recycler.SetLayoutManager(Manager);
            recycler.SetAdapter(Adapter);

            // Set
            SetNativeControl(recycler);
        }

    }
}