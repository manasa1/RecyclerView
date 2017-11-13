using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace FormsToolkit.iOS.Cells
{
    public class RecycleCell : UICollectionViewCell
    {

        public const string Key = nameof(RecycleCell);

        [Export("initWithFrame:")]
        public RecycleCell(CGRect frame) : base (frame)
        {
        }

        public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
        {
            return layoutAttributes;
        }

    }
}