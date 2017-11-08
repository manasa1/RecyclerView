using FormsToolkit.UWP.Renderers;
using System;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FormsToolkit.UWP.Views
{
    public sealed partial class NativeRecyclerListView : UserControl
    {

        public WeakReference<RecyclerViewRenderer> RendererReference { get; set; }

        public NativeRecyclerListView(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
            InitializeComponent();
        }
    }
}
