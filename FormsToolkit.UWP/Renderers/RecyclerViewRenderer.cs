using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsToolkit.Views;
using Xamarin.Forms.Platform.UWP;

namespace FormsToolkit.UWP.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, Windows.UI.Xaml.Controls.ListView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<RecyclerView> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}
