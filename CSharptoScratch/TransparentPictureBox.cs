namespace CSharptoScratch
{
    internal class TransparentPictureBox : PictureBox
    {
        private static readonly Dictionary<Control, Bitmap> ParentBitmaps = new();
        private static readonly object ParentBitmapLock = new();

        public TransparentPictureBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                return base.CreateParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (Parent == null)
            {
                return;
            }

            var bmp = GetParentBitmap(Parent);
            Parent.DrawToBitmap(bmp, Parent.ClientRectangle);
            pevent.Graphics.DrawImage(bmp, -Left, -Top);
        }

        private static Bitmap GetParentBitmap(Control parent)
        {
            lock (ParentBitmapLock)
            {
                if (!ParentBitmaps.TryGetValue(parent, out var bmp) || bmp.Width != parent.Width || bmp.Height != parent.Height)
                {
                    bmp?.Dispose();
                    bmp = new Bitmap(parent.Width, parent.Height);
                    ParentBitmaps[parent] = bmp;
                }

                return bmp;
            }
        }
    }
}
