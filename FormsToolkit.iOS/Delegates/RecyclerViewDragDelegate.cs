using System;
using Foundation;
using UIKit;
using FormsToolkit.iOS.Renderers;
using MobileCoreServices;

namespace FormsToolkit.iOS.Delegates
{
    public class RecyclerViewDragDelegate : UICollectionViewDragDelegate
    {

        internal WeakReference<RecyclerViewRenderer> RendererReference { get; set; }

        public RecyclerViewDragDelegate(RecyclerViewRenderer renderer)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }

        public override UIDragItem[] GetItemsForBeginningDragSession(UICollectionView collectionView, IUIDragSession session, NSIndexPath indexPath)
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return new UIDragItem[] { };

            var itemProvider = new NSItemProvider();
            var data = NSData.FromString($"{indexPath.Row}#{indexPath.Section}", NSStringEncoding.UTF8);

            itemProvider.RegisterDataRepresentation(UTType.PlainText, NSItemProviderRepresentationVisibility.All, (completion) => {
                completion(data, null);
                return null;
            });

            return new UIDragItem[] { new UIDragItem(itemProvider) };
        }
    }
}
