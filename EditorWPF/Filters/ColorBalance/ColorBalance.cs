using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EditorWPF.Filters.ColorBalance
{
    abstract class ColorBalance : Filter
    {
        public ColorBalance(WriteableBitmap image, MainWindow ownerForm) :
            base(image, ownerForm)
        { }

        public override int ComputePixelColor(int colorData, int N)
        {
            int[] RGB = SetColors(colorData, N);
            RGB = OverflowControl(RGB);

            int R = RGB[0];
            int G = RGB[1];
            int B = RGB[2];

            colorData = (int)(0x000000 | (R << 16) | (G << 8) | (B));

            return colorData;
        }

        public abstract int[] SetColors(int colorData, int N);
        public abstract int[] OverflowControl(int[] RGB);
    }
}
