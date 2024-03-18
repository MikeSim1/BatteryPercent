using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DISCLAIMER: The following code was derived from a solution found here:
// https://www.codeproject.com/Questions/996690/Label-forecolor-opacity
// And using ChatGPT "Solution 2" was translated into C#

namespace BatteryPercent
{
    internal class CustomLabel : Label
    {
        private int myOpacity = 255;
        private Color myBackColor = Color.Transparent;
        private Color myForeColor = Color.White;
        private Control myParent;
        private bool myParentEnabled;

        public CustomLabel()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            SetStyle(ControlStyles.ResizeRedraw, true);

            if (Program.props.OverlaySize <= 0)
            {
                // Invalid value, reset the property
                Program.props.OverlaySize = 5;
            }

            float fontSize = Program.props.OverlaySize * 5;
            Font = new Font("Microsoft Sans Serif", fontSize);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // Turn on WS_EX_TRANSPARENT
                return cp;
            }
        }

        public int Opacity
        {
            get { return myOpacity; }
            set
            {
                if (value >= 0 && value <= 255)
                {
                    myOpacity = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap myBitmap = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(myBitmap))
            {
                // Label BackColor (AKA label background)
                Color pBackColor = myBackColor;
                if (myBackColor == Color.Transparent && myParent != null)
                    pBackColor = myParent.BackColor;

                base.OnPaint(new PaintEventArgs(gr, e.ClipRectangle));

                float backgroundOpacity = (float)Program.props.BackgroundOpacity / 100;
                int backColorAlpha = (int)((float)255 * backgroundOpacity);

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Color PixelColor = myBitmap.GetPixel(x, y);
                        if (PixelColor.A != 0)
                            myBitmap.SetPixel(x, y, Color.FromArgb(backColorAlpha, PixelColor));
                        else
                            myBitmap.SetPixel(x, y, Color.FromArgb(255, pBackColor));
                    }
                }

                // Label ForeColor (AKA text color)
                Color pForeColor = myForeColor;
                if (myForeColor == Color.Transparent && myParent != null)
                    pBackColor = myParent.ForeColor;

                base.OnPaint(new PaintEventArgs(gr, e.ClipRectangle));

                float textOpacity = (float)Program.props.TextOpacity / 100;
                int colorAlpha = (int)((float)255 * textOpacity);

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        Color PixelColor = myBitmap.GetPixel(x, y);
                        if (PixelColor.A != 0)

                            myBitmap.SetPixel(x, y, Color.FromArgb(colorAlpha, PixelColor));
                        else
                            myBitmap.SetPixel(x, y, Color.FromArgb(255, pBackColor));
                    }
                }

                e.Graphics.DrawImage(myBitmap, 0, 0);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            myParent = Parent;
            if (myParent != null)
                myParentEnabled = myParent.Enabled;
        }

        public override Color BackColor
        {
            get { return myBackColor; }
            set
            {
                myBackColor = value;
                Invalidate();
            }
        }
    }
}
