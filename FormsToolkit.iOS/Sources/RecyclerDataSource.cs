using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormsToolkit.Extensions;

using Foundation;
using UIKit;
using FormsToolkit.iOS.Renderers;

namespace FormsToolkit.iOS.Sources
{
    public class RecyclerDataSource : UICollectionViewSource
    {

        WeakReference<RecyclerViewRenderer> RendererReference { get; set; }

        public RecyclerDataSource(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return 0;

            // Return ItemSource count
            var itemSource = renderer.Element.ItemsSource;
            return itemSource?.Count() ?? 0;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (indexPath == null)
                return null;
            return base.GetCell(collectionView, indexPath);
        }

    }
}