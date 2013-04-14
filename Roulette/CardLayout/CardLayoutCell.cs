using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace Roulette
{
    public class CardLayoutCell : UICollectionViewCell
    {
        public static NSString CellIdentifier = new NSString("CardLayoutCell");

        private UIImageView _imageView;

        public CardLayoutCell ()
        {			
        }

        public CardLayoutCell (IntPtr handle)
            : base(handle)
        {			
        }

        public CardLayoutCell(RectangleF frame)
            : base(frame)   
        {
        }

        public UIImageView ImageView
        {
            get { return _imageView; }
            set 
            { 
                // not sure out
                //if (_imageView != null)
                //    throw new Exception("You can only set image once!");
                _imageView = value;
                AddSubview(_imageView);
            }
        }
    }
}