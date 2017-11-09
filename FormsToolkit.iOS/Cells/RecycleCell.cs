using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace FormsToolkit.iOS.Cells
{
    public class RecycleCell : UICollectionViewCell
    {

        public const string Key = nameof(RecycleCell);

        View _formsView;

        UIView _nativeView;

        public View FormsView
        {
            get => _formsView;
            set
            {
                _formsView = value;
                UpdateView();
            }
        }

        [Export("initWithFrame:")]
        public RecycleCell(CGRect frame) : base(frame)
        {

        }

        void UpdateView()
        {
            // Remove legacy
            if (_nativeView != null)
                _nativeView.RemoveFromSuperview();

            // Generate new
            _nativeView = new UIView(new CGRect(0, 0, 200, 200))
            {
                BackgroundColor = UIColor.Blue,
                AutoresizingMask = UIViewAutoresizing.All,
                ContentMode = UIViewContentMode.ScaleToFill
            };

            // Insert new
            AddSubview(_nativeView);
        }

    }
}
