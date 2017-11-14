using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using FormsToolkit.iOS.Renderers;

namespace FormsToolkit.iOS.Views
{
    public class RecyclerUICollectionView : UICollectionView
    {

        internal WeakReference<RecyclerViewRenderer> RendererReference { get; set; }
        
        internal UILongPressGestureRecognizer LongPressGestureRecognizer { get; set; }

        public RecyclerUICollectionView(RecyclerViewRenderer renderer, CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
            LongPressGestureRecognizer = new UILongPressGestureRecognizer(this, new ObjCRuntime.Selector(nameof(LongPressGestureRecognizer)));

            AddGestureRecognizer(LongPressGestureRecognizer);
        }

        [Export(nameof(LongPressGestureRecognizer))]
        public void HandleLongPress()
        {
            if (!RendererReference.TryGetTarget(out RecyclerViewRenderer renderer))
                return;

            var location = LongPressGestureRecognizer.LocationInView(this);
            var view = LongPressGestureRecognizer.View;

            switch (LongPressGestureRecognizer.State)
            {
                case UIGestureRecognizerState.Began:
                    BeginInteractiveMovementForItem(IndexPathForItemAtPoint(location));
                    break;

                case UIGestureRecognizerState.Changed:
                    UpdateInteractiveMovement(location);
                    break;

                case UIGestureRecognizerState.Ended:
                    EndInteractiveMovement();
                    renderer.Control.ReloadData();
                    break;

                default:
                    CancelInteractiveMovement();
                    break;
            }
        }
    }
}