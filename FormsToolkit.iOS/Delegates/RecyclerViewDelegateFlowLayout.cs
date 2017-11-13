using System;

using CoreGraphics;
using Foundation;
using UIKit;

using FormsToolkit.iOS.Renderers;

namespace FormsToolkit.iOS.Delegates
{
    public class RecyclerViewDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {

        WeakReference<RecyclerViewRenderer> _rendererReference;

        public RecyclerViewDelegateFlowLayout(RecyclerViewRenderer renderer)
        {
            _rendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            if (!_rendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return new CGSize(0, 0);

            // Test hack
            return new CGSize(renderer.Element.Width, 200);
        }

    }
}