using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using FormsToolkit.iOS.Cells;

namespace FormsToolkit.iOS.Views
{
    public class NativeRecyclerListView : UICollectionView
    {
        public NativeRecyclerListView() : this (default(CGRect))
        {
        }

        public NativeRecyclerListView(CGRect frm) : base(frm, new UICollectionViewFlowLayout())
        {
            AutoresizingMask = UIViewAutoresizing.All;
            ContentMode = UIViewContentMode.ScaleToFill;
            RegisterClassForCell(typeof(RecycleCell), new NSString(RecycleCell.Key));
        }
    }
}