using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EditorWPF.Filters.ColorBalance
{
    class BlueBalance : ColorBalance
    {
        public BlueBalance(WriteableBitmap image, MainWindow ownerForm) :
            base(image, ownerForm)
        { }

        public override int[] SetColors(int colorData, int N)
        {
            int[] RGB = new int[3];
            RGB[0] = ((colorData & 0xFF0000) >> 16);
            RGB[1] = ((colorData & 0x00FF00) >> 8);
            RGB[2] = ((colorData & 0x0000FF) + N * 128 / 100);
            return RGB;
        }

        public override int[] OverflowControl(int[] RGB)
        {
            if (RGB[2] < 0) RGB[2] = 0;
            if (RGB[2] > 255) RGB[2] = 255;

            return RGB;
        }
    }
}
