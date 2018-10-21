using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

        private BitmapImage bitmap;
        private string nameOfImage;

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
            //image.Height = bitmap.Height;
            //image.Width = bitmap.Width;
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

                    bitmap = new BitmapImage();

                    // initialize and fill the bitmap
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(nameOfImage);
                    bitmap.EndInit();

                    this.image.Source = bitmap;

                    // make the window fit the image
                    ResizeWindow();
                    // make the container fit the image
                    ResizeImage();
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
    }
}
