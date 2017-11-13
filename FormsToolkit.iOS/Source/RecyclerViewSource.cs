﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms.Platform.iOS;

using FormsToolkit.Extensions;
using FormsToolkit.iOS.Renderers;
using FormsToolkit.iOS.Cells;
using CoreGraphics;
using Xamarin.Forms;

namespace FormsToolkit.iOS.Source
{
    public class RecyclerViewSource : UICollectionViewSource
    {

        WeakReference<RecyclerViewRenderer> _rendererReference;

        public RecyclerViewSource(RecyclerViewRenderer renderer)
        {
            _rendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Prepare
            var cell = (UICollectionViewCell) collectionView.DequeueReusableCell(RecycleCell.Key, indexPath);
            if (cell == null || !_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return new UICollectionViewCell(new CGRect(0, 0, 0, 0));

            // Get
            var item = renderer.GetItemFromNSIndex(indexPath);
            var nativeView = renderer.GetNativeViewForItem(collectionView, item);

            // Merge
            var frame = renderer.GenerateFrameForCell(nativeView, indexPath);

            cell.Frame = frame;
            cell.AddSubview(nativeView);

            // Return
            return cell;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            if (!_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return 0;

            if (renderer.Element.Orientation == Enumerations.ListOrientation.Horizontal)
                return 1;
            return renderer.Element.ItemsSource?.Count() ?? 0;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            if (!_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return 0;

            if (renderer.Element.Orientation == Enumerations.ListOrientation.Horizontal)
                return renderer.Element.ItemsSource?.Count() ?? 0;
            return 1;
        }

    }
}