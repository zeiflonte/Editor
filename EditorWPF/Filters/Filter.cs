using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace EditorWPF.Filters
{
    public abstract class Filter
    {
        public Filter(WriteableBitmap bitmap, MainWindow ownerForm)
        {
            this.bitmapSaved = bitmap;
            this.ownerForm = ownerForm;
        }

        MainWindow ownerForm;
        WriteableBitmap bitmap;
        readonly WriteableBitmap bitmapSaved;   // preserves original values

        public WriteableBitmap Apply(double pos, double length)
        {
            // percentage of a parameter value
            int N = (int)Math.Round((100 / length) * pos);


            // load an original image
            bitmap = new WriteableBitmap(bitmapSaved);

            for (int j = 0; j < bitmap.Width - 1; j++)
                for (int i = 0; i < bitmap.Height - 1; i++)
                {
                    unsafe
                    {
                        // Get a pointer to the back buffer.
                        int pBackBuffer = (int)bitmap.BackBuffer;

                        // Find the address of the pixel to draw.
                        pBackBuffer += i * bitmap.BackBufferStride;
                        pBackBuffer += j * 4;

                        //bitmap.BackBufferStride

                        int colorData = ComputePixelColor(*((int*)pBackBuffer), N);

                        // Assign the color data to the pixel.
                        *((int*)pBackBuffer) = colorData;
                    }
                }

            ownerForm.UpdateImage(bitmap);

            return bitmap;
        }

        public void Save()
        {
            //ownerForm.UpdateImage(bitmap);
        }

        public void Restore()
        {
            // reset an image while closing the window
            WriteableBitmap image = new WriteableBitmap(bitmapSaved);
            //ownerForm.UpdateImage(bitmap);
        }

        public abstract int ComputePixelColor(int colorData, int N);
    }
}
