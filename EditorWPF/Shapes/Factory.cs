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
    abstract class Factory
    {
        public abstract Shape Create(WriteableBitmap image, Color color);
    }

    class FactoryRectangle : Factory
    {
        public override Shape Create(WriteableBitmap image, Color color)
        {
            return new Shapes.Rectangle(image, color);
        }
    }

    class FactoryEllipse : Factory
    {
        public override Shape Create(WriteableBitmap image, Color color)
        {
            return new Shapes.Ellipse(image, color);
        }
    }
}
