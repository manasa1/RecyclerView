using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using FormsToolkit.Extensions;
using FormsToolkit.iOS.Renderers;
using CoreGraphics;
using FormsToolkit.iOS.Cells;

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
            UICollectionViewCell cell = (UICollectionViewCell) collectionView.DequeueReusableCell(RecycleCell.Key, indexPath);

            _rendererReference.TryGetTarget(out RecyclerViewRenderer renderer);

            System.Diagnostics.Debug.WriteLine($"Got {indexPath.Length} at section {indexPath.Section}");

            var w = renderer.Element.Width;
            var h = renderer.Element.Height;

            cell.Frame = new CGRect(cell.Frame.X, cell.Frame.Y, w, cell.Frame.Height);
            cell.BackgroundColor = UIColor.Red;

            UILabel li = new UILabel(new CGRect(0, 0, 10, 20))
            {
                Text = "xyz"
            };

            cell.AddSubview(li);
            return cell;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            if (!_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return 1;

            return renderer.Element.ItemsSource?.Count() ?? 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 1;

            if (!_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return 0;

            return renderer.Element.ItemsSource?.Count() ?? 0;
        }

    }
}