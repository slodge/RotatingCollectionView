using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace Roulette
{
    public class MyViewController : UIViewController
    {
        protected UICollectionView CollectionView { get; set; }
        protected UICollectionViewFlowLayout CollectionViewLayout { get; set; }
        protected List<UIImageView> ImageViews { get; set; }

        public override void ViewDidLoad()
        {
			View = new UIView();
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.Black;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            InitImages();

			CollectionViewLayout = new CardLayoutFlow(View);
            CollectionView = new UICollectionView(new RectangleF(-20, 100, 360, 250), CollectionViewLayout)
                {
                     IndicatorStyle = UIScrollViewIndicatorStyle.White,
                     ShowsHorizontalScrollIndicator = false,
                     ShowsVerticalScrollIndicator = false,
                     AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
                };
			Add(CollectionView);
            CollectionView.Source = new CollectionSource(this);
		}

        private void InitImages()
        {
            ImageViews = new List<UIImageView>();
            for (var i=1;i<18;i++)
            {
                ImageViews.Add(new UIImageView(UIImage.FromFile("Images/" + i.ToString() + ".jpg")));
            }
            for (var i = 1; i < 18; i++)
            {
				ImageViews.Add(new UIImageView(UIImage.FromFile("Images/" + i.ToString() + ".jpg")));
			}
            for (var i = 2; i < 7; i++)
            {
				ImageViews.Add(new UIImageView(UIImage.FromFile("Images/" + i.ToString() + ".jpg")));
			}

			var maxSize = new SizeF(190,190);


			foreach(var view in ImageViews)
			{
				view.Frame = new RectangleF(new PointF(0,0), maxSize);
			}
        }

        public class CollectionSource : UICollectionViewSource
        {
            private readonly MyViewController _parent;

            public CollectionSource(MyViewController parent)
            {
                _parent = parent;
                _parent.CollectionView.RegisterClassForCell(typeof(CardLayoutCell), CardLayoutCell.CellIdentifier);
            }

            public override int NumberOfSections(UICollectionView collectionView)
            {
 	             return 1;
            }

            public override int GetItemsCount(UICollectionView collectionView, int section)
            {
                return _parent.ImageViews.Count;
            }

            public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
            {
                var cell = (CardLayoutCell)collectionView.DequeueReusableCell(CardLayoutCell.CellIdentifier, indexPath);
                cell.ImageView = _parent.ImageViews[indexPath.Item];
                return cell;
            }
        }
    }
}

