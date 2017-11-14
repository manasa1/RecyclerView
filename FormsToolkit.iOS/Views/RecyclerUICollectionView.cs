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
        
        public RecyclerUICollectionView(RecyclerViewRenderer renderer, CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
        {
            RendererReference = new WeakReference<RecyclerViewRenderer>(renderer);
        }
    }
}