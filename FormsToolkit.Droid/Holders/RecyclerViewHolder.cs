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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsToolkit.Droid.Holders
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {

        Android.Views.View _itemView;

        Xamarin.Forms.View _abstractView;

        public RecyclerViewHolder(Android.Views.View itemView) : base (itemView)
        {
        }

    }
}