using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EditorWPF.Shapes
{
    abstract class Shape
    {
        public Shape(WriteableBitmap bitmap, Color color)
        {
            this.Bitmap = bitmap;
            this.Color = color;
        }

        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Color Color { get; set; }
        protected WriteableBitmap Bitmap { get; set; }

        public void AdjustCoordinates()
        {
            int x = this.X2;
            int y = this.Y2;

            if (x < this.X1)
            {
                if (y < this.Y1)
                {
                    this.X2 = this.X1;
                    this.Y2 = this.Y1;
                    this.X1 = x;
                    this.Y1 = y;
                }
                else
                {
                    this.X2 = this.X1;
                    this.X1 = x;
                    this.Y2 = y;
                }
            }
            if (y < this.Y1 && x > this.X1)
            {
                this.Y2 = Y1;
                this.Y1 = y;
                this.X2 = x;
            }
        }

        public abstract void Draw();
    }
}
