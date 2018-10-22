using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EditorWPF.Filters.ColorBalance
{
    class GreenBalance : ColorBalance
    {
        public GreenBalance(WriteableBitmap image, MainWindow ownerForm) :
            base(image, ownerForm)
        { }

        public override int[] SetColors(int colorData, int N)
        {
            int[] RGB = new int[3];
            RGB[0] = ((colorData & 0xFF0000) >> 16);
            RGB[1] = (((colorData & 0x00FF00) >> 8) + N * 128 / 100);
            RGB[2] = (colorData & 0x0000FF);
            return RGB;
        }

        public override int[] OverflowControl(int[] RGB)
        {
            if (RGB[1] < 0) RGB[1] = 0;
            if (RGB[1] > 255) RGB[1] = 255;

            return RGB;
        }
    }
}
