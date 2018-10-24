using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EditorWPF.Shapes
{
    class Ellipse : Shape
    {
        public Ellipse(WriteableBitmap bitmap, Color color) : base(bitmap, color)
        { }

        public override void Draw()
        {
            Bitmap.DrawEllipse(X1, Y1, X2, Y2, Color);
        }
    }
}
