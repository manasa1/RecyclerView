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
using Android.Support.V7.Widget;
using FormsToolkit.Views;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

namespace FormsToolkit.Droid.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<Views.RecyclerView, Android.Support.V7.Widget.RecyclerView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Views.RecyclerView> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}