using FormsToolkit.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FormsToolkit.UWP.Views
{
    public sealed partial class FormsBoundTemplate : UserControl
    {

        public static readonly DependencyProperty BindingContextProperty = DependencyProperty.Register(
            nameof(BindingContext),
            typeof(object),
            typeof(FormsBoundTemplate),
            new PropertyMetadata(null, (sender, args) => ((FormsBoundTemplate)sender).OnBindingContextApplied()));

        public static readonly DependencyProperty NativeRecyclerListViewProperty = DependencyProperty.Register(
            nameof(NativeRecyclerListView),
            typeof(NativeRecyclerListView),
            typeof(FormsBoundTemplate),
            null);

        public object BindingContext
        {
            get => GetValue(BindingContextProperty);
            set => SetValue(BindingContextProperty, value);
        }

        public NativeRecyclerListView NativeRecyclerListView
        {
            get => (NativeRecyclerListView) GetValue(NativeRecyclerListViewProperty);
            set => SetValue(NativeRecyclerListViewProperty, value);
        }

        public FormsBoundTemplate()
        {
            this.InitializeComponent();
        }

        internal void OnBindingContextApplied()
        {
            // Map to object
            System.Diagnostics.Debug.WriteLine("");
        }
        
    }
}
