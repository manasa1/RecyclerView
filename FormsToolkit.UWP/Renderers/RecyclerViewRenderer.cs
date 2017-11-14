﻿using Xamarin.Forms.Platform.UWP;

using System;
using System.Linq;
using System.Collections.Generic;

using FormsToolkit.Views;
using FormsToolkit.UWP.Views;
using FormsToolkit.UWP.Renderers;
using FormsToolkit.UWP.Models;

using Windows.UI.Xaml;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

[assembly: ExportRenderer(typeof(RecyclerView), typeof(RecyclerViewRenderer))]
namespace FormsToolkit.UWP.Renderers
{
    public class RecyclerViewRenderer : ViewRenderer<RecyclerView, FrameworkElement>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<RecyclerView> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                    SetupControl();

                SetupElement(e.NewElement);
            }

            if (e.OldElement != null)
                DestroyElement(e.OldElement);

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Property changed: {e.PropertyName}");

            switch (e.PropertyName)
            {
                case nameof(Element.BackgroundColor):
                    SetBackgroundColor();
                    break;

                default:
                    break;
            }

            base.OnElementPropertyChanged(sender, e);
        }

        void SetupControl()
        {
            SetNativeControl(new NativeRecyclerListView(this));
        }

        void SetupElement(RecyclerView element)
        {
            element.OnItemsSourceChanged += HandleOnItemsSourceChanged;

            SetBackgroundColor();
            HandleOnItemsSourceChanged(element, null);
            HandleOnItemTemplateChanged(element, null);
        }

        void DestroyElement(RecyclerView element)
        {
            element.OnItemsSourceChanged -= HandleOnItemsSourceChanged;
        }

        void HandleOnItemTemplateChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            // TODO - Reload Content
        }

        void HandleOnItemsSourceChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            if (Element?.ItemsSource == null)
                return;

            List<ContextRendererContainer<RecyclerViewRenderer>> newSource = new List<ContextRendererContainer<RecyclerViewRenderer>>();

            foreach (var item in Element.ItemsSource)
            {
                newSource.Add(new ContextRendererContainer<RecyclerViewRenderer>()
                {
                    Context = item,
                    Renderer = this
                });
            }

            ((NativeRecyclerListView)Control).EmbeddedList.ItemsSource = newSource;
        }

        void SetBackgroundColor()
        {
            if (Control != null && Element != null)
                ((NativeRecyclerListView)Control).EmbeddedList.Background = ToBrush(Element.BackgroundColor);
        }

        Brush ToBrush(Xamarin.Forms.Color color)
        {
            var wpColor = Color.FromArgb(
            (byte)(color.A * 255),
            (byte)(color.R * 255),
            (byte)(color.G * 255),
            (byte)(color.B * 255));

            return new SolidColorBrush(wpColor);
        }

    }
}
