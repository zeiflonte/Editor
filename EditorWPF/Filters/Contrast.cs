using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EditorWPF.Filters
{
    class Contrast : Filter
    {
        public Contrast(WriteableBitmap image, MainWindow ownerForm) :
            base(image, ownerForm)
        { }

        public override int ComputePixelColor(int colorData, int N)
        {
            // Compute the pixel's color.
            if (N == 100) N = 99;
            int R = (((colorData & 0xFF0000) >> 16) * 100 - 128 * N) / (100 - N);
            int G = (((colorData & 0x00FF00) >> 8) * 100 - 128 * N) / (100 - N);
            int B = ((colorData & 0x0000FF) * 100 - 128 * N) / (100 - N);

            // overflow control
            if (R < 0) R = 0;
            if (R > 255) R = 255;
            if (G < 0) G = 0;
            if (G > 255) G = 255;
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            colorData = (int)(0x000000 | (R << 16) | (G << 8) | (B));

            return colorData;
        }
    }
}
