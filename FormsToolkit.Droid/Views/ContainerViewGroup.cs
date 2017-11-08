using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsToolkit.Droid.Views
{
    public class ContainerViewGroup : ViewGroup
    {

        IVisualElementRenderer _child;

        public IVisualElementRenderer Child
        {
            get => _child;
            set
            {
                if (_child != null)
                    RemoveView(_child.View);

                _child = value;

                if (value != null)
                    AddView(_child.View);
            }
        }

        public ContainerViewGroup(Context context) : base(context)
        {

        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            _child?.UpdateLayout();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            if (_child == null)
            {
                SetMeasuredDimension(0, 0);
                return;
            }

            VisualElement element = _child.Element;

            Context ctx = Context;

            var width = (int) ctx.FromPixels(GetSize(widthMeasureSpec));

            SizeRequest request = _child.Element.Measure(width, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion(_child.Element, new Rectangle(0, 0, width, request.Request.Height));

            int widthSpec = MakeMeasureSpec((int)ctx.ToPixels(width), MeasureSpecMode.Exactly);
            int heightSpec = MakeMeasureSpec((int)ctx.ToPixels(request.Request.Height), MeasureSpecMode.Exactly);

            _child.View.Measure(widthMeasureSpec, heightMeasureSpec);

            SetMeasuredDimension(widthSpec, heightSpec);
        }

        public static int GetSize(int measureSpec)
        {
            const int modeMask = 0x3 << 30;
            return measureSpec & ~modeMask;
        }

        public static int MakeMeasureSpec(int size, MeasureSpecMode mode)
        {
            return size + (int)mode;
        }
    }
}