using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace FormsToolkit.iOS.Delegates
{
    public class RecyclerViewDropDelegate : UICollectionViewDropDelegate
    {

        public override bool CanHandleDropSession(UICollectionView collectionView, IUIDropSession session)
        {
            return true;
        }

        public override UICollectionViewDropProposal DropSessionDidUpdate(UICollectionView collectionView, IUIDropSession session, NSIndexPath destinationIndexPath)
        {
            return new UICollectionViewDropProposal(UIDropOperation.Move, UICollectionViewDropIntent.InsertAtDestinationIndexPath);
        }

        public override void PerformDrop(UICollectionView collectionView, IUICollectionViewDropCoordinator coordinator)
        {
        }
    }
}
