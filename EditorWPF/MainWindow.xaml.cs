using EditorWPF.Shapes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Stack<WriteableBitmap> bitmaps = new Stack<WriteableBitmap>();

        private WriteableBitmap bitmap;
        private string nameOfImage;

        private Color color = Colors.Black;
        private Factory factory = null;
        private Shapes.Shape shape = null;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (bitmaps.Count > 0)
            {
                WriteableBitmap bitmap = bitmaps.Pop();
                RestoreImage(bitmap);
            }
        }

        void ResizeWindow()
        {
            // set margins
            int widthMargin = 40;
            int heightMargin = 75;

            // resize window for the image inside
            this.Width = image.Width + widthMargin;
            this.Height = image.Height + heightMargin;
        }

        void ResizeImage()
        {
            image.Height = bitmap.Height;
            image.Width = bitmap.Width;
        }

        public void PreviewImage(WriteableBitmap bitmap)
        {
            this.bitmap = bitmap;
            image.Source = bitmap;
        }

        public void UpdateImage(WriteableBitmap bitmap)
        {
            this.bitmap = bitmap;
            image.Source = bitmap;
        }

        public void SaveOld(WriteableBitmap bitmap)
        {
            bitmaps.Push(this.bitmap); // save old value
        }

        public void RestoreImage(WriteableBitmap bitmap)
        {
            this.bitmap = bitmap;
            image.Source = bitmap;
            ResizeImage();
            ResizeWindow();
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "Open an image",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
            };
            if (openDialog.ShowDialog() == true)
            {
                try
                {
                    nameOfImage = openDialog.FileName;

                    // initialize and fill the bitmap
                    BitmapImage bitmapSource = new BitmapImage();
                    bitmapSource.BeginInit();
                    bitmapSource.UriSource = new Uri(nameOfImage);
                    bitmapSource.EndInit();

                    bitmap = new WriteableBitmap(bitmapSource);

                    this.image.Source = bitmap;

                    // make the container fit the image
                    ResizeImage();
                    // make the window fit the image
                    ResizeWindow();
                    
                }
                catch
                {
                    nameOfImage = null;
                    MessageBox.Show("Error opening the file",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveImage(string nameOfImage)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));
            using (FileStream stream = new FileStream(nameOfImage, FileMode.Create))
            {
                encoder.Save(stream);
            }
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            if (nameOfImage != null)
            {
                try
                {
                    SaveImage(nameOfImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the image: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void miSaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (image.Source != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Title = "Save the image As...",
                    OverwritePrompt = true,
                    CheckPathExists = true,
                    Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*",
                };
                if (saveDialog.ShowDialog() == true)
                {
                    try
                    {
                        SaveImage(saveDialog.FileName);
                        nameOfImage = saveDialog.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Unable to save the image", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void miBrightness_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                Parameter parameter = new Parameter(new Filters.Brightness(bitmap, this));
                parameter.ShowDialog();
            }
        }

        private void miContrast_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                Parameter parameter = new Parameter(new Filters.Contrast(bitmap, this));
                parameter.ShowDialog();
            }
        }

        private void miColorBalanceRed_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                Parameter parameter = new Parameter(new Filters.ColorBalance.RedBalance(bitmap, this));
                parameter.ShowDialog();
            }
        }

        private void miColorBalanceGreen_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                Parameter parameter = new Parameter(new Filters.ColorBalance.GreenBalance(bitmap, this));
                parameter.ShowDialog();
            }
        }

        private void miColorBalanceBlue_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                Parameter parameter = new Parameter(new Filters.ColorBalance.BlueBalance(bitmap, this));
                parameter.ShowDialog();
            }
        }

        private void miRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                SaveOld(bitmap);
                bitmap = bitmap.Rotate(270);
                ResizeImage();
                ResizeWindow();
                UpdateImage(bitmap);
            }
        }

        private void miRotateRight_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                SaveOld(bitmap);
                bitmap = bitmap.Rotate(90);
                ResizeImage();
                ResizeWindow();
                UpdateImage(bitmap);
            }
        }

        private void miRotate180_Click(object sender, RoutedEventArgs e)
        {
            if (this.bitmap != null)
            {
                SaveOld(this.bitmap);
                WriteableBitmap bitmap = this.bitmap.Rotate(180);
                UpdateImage(bitmap);
            }
        }

        private void miFlipVertical_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                // flip image
                SaveOld(bitmap);
                bitmap = bitmap.Flip(WriteableBitmapExtensions.FlipMode.Vertical);
                UpdateImage(bitmap);
            }
        }

        private void miFlipHorizontal_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                // flip image
                SaveOld(bitmap);
                bitmap = bitmap.Flip(WriteableBitmapExtensions.FlipMode.Horizontal);
                UpdateImage(bitmap);
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (factory != null)
            {
                shape = factory.Create(bitmap, color);
                Point p = e.GetPosition(image);
                shape.X1 = (int)Math.Round(p.X);
                shape.Y1 = (int)Math.Round(p.Y);
            }
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (shape != null)
            {
                //SaveOld(bitmap);

                Point p = e.GetPosition(image);
                shape.X2 = (int)Math.Round(p.X);
                shape.Y2 = (int)Math.Round(p.Y);

                shape.AdjustCoordinates();

                shape.Draw();
                UpdateImage(bitmap);

                shape = null;
            }
        }

        private void miRectangle_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                factory = new FactoryRectangle();
            }
        }

        private void miEllipse_Click(object sender, RoutedEventArgs e)
        {
            if (bitmap != null)
            {
                factory = new FactoryEllipse();
            }
        }

        private void miColorBlack_Click(object sender, RoutedEventArgs e)
        {
            color = Colors.Black;
        }

        private void miColorBlue_Click(object sender, RoutedEventArgs e)
        {
            color = Colors.Blue;
        }

        private void miColorGreen_Click(object sender, RoutedEventArgs e)
        {
            color = Colors.Green;
        }

        private void miColorRed_Click(object sender, RoutedEventArgs e)
        {
            color = Colors.Red;
        }  
    }
}