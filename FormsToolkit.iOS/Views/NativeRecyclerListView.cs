using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

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
            // RegisterClassForCell(typeof(GridViewCell), new NSString(GridViewCell.Key));
        }
    }
}