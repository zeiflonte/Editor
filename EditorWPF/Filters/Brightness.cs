using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EditorWPF.Filters
{
    class Brightness : Filter
    {
        public Brightness(WriteableBitmap image, MainWindow ownerForm) :
            base(image, ownerForm)
        { }

        public override int ComputePixelColor(int colorData, int N)
        {
            // Compute the pixel's color.
            int R = (((colorData & 0xFF0000) >> 16) + N * 128 / 100);
            int G = (((colorData & 0x00FF00) >> 8) + N * 128 / 100);
            int B = ((colorData & 0x0000FF) + N * 128 / 100);

            // overflow control
            if (R < 0) R = 0;
            if (R > 255) R = 255;
            if (G < 0) G = 0;
            if (G > 255) G = 255;
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            colorData = (int)(0x000000 | (R << 16) | (G << 8) | (B));
            //colorData = R << 16;      
            //colorData |= G << 8;      
            //colorData |= B << 0;      

            return colorData;
        }
    }
}
