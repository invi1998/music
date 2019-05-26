using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationGDI
{
    public class CircleCornorPicutureBox:PictureBox
    {
        private int _Radius = 20;
        public int Randus
        {
            get { return _Radius; }
            set
            {
                _Radius = value;
                this.CreateCorner(Randus);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CreateCorner(Randus);
        }

    }

    internal static class Extension
    {
        public static PictureBox CreateCorner(this PictureBox pic, int radius)
        {
            var graphicsPath = new GraphicsPath();

            graphicsPath.StartFigure();
            graphicsPath.AddArc(pic.ClientRectangle.Left, pic.ClientRectangle.Top, radius * 2, radius * 2, 180, 90);
            graphicsPath.AddArc(pic.ClientRectangle.Right - radius * 2, pic.ClientRectangle.Top, radius * 2, radius * 2, 270, 90);
            graphicsPath.AddArc(pic.ClientRectangle.Right - radius * 2, pic.ClientRectangle.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            graphicsPath.AddArc(pic.ClientRectangle.Left, pic.ClientRectangle.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            graphicsPath.CloseFigure();

            pic.Region = new Region(graphicsPath);
            return pic;
        }
    }
}
