using FormsToolkit.Extensions;
using FormsToolkit.UWP.Models;
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
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FormsToolkit.UWP.Views
{
    public sealed partial class FormsBoundTemplate : UserControl
    {

        public static readonly DependencyProperty BindingContextProperty = DependencyProperty.Register(
            nameof(BindingContext),
            typeof(ContextRendererContainer<RecyclerViewRenderer>),
            typeof(FormsBoundTemplate),
            new PropertyMetadata(null, (sender, args) => ((FormsBoundTemplate)sender).OnBindingContextApplied()));

        public ContextRendererContainer<RecyclerViewRenderer> BindingContext
        {
            get => (ContextRendererContainer<RecyclerViewRenderer>) GetValue(BindingContextProperty);
            set => SetValue(BindingContextProperty, value);
        }

        public FormsBoundTemplate()
        {
            this.InitializeComponent();
        }

        internal void OnBindingContextApplied()
        {
            // Destructure
            var renderer = BindingContext.Renderer;
            var context = BindingContext.Context;

            // Create
            var view = BindingContext.Renderer.Element.ItemTemplate.GenerateView(BindingContext.Renderer.Element, BindingContext.Context);
            var frameworkView = ConvertToWindowsView(view);

            // Append to Container
            Container.Children.Clear();
            Container.Children.Add(frameworkView);
        }

        FrameworkElement ConvertToWindowsView(View view)
        {
            if (BindingContext == null)
                goto ConvertEnd;

            var renderer = Platform.CreateRenderer(view);

            var measure = view.Measure(BindingContext.Renderer.Element.Width, double.PositiveInfinity, MeasureFlags.IncludeMargins);

            // Determine width from measure
            var width = BindingContext.Renderer.Element.Width;

            // Set margins on container
            Container.Margin = new Windows.UI.Xaml.Thickness(view.Margin.Left, view.Margin.Top, view.Margin.Right, view.Margin.Bottom);

            view.Layout(new Rectangle(0, 0, width, measure.Request.Height));
            return renderer.ContainerElement;

            ConvertEnd:
            return new Border()
            {
                Background = new SolidColorBrush(Windows.UI.Colors.Purple),
                Height = 200,
                Width = 300
            };
        }

    }
}
