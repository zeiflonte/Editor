using EditorWPF.Filters;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EditorWPF
{
    /// <summary>
    /// Interaction logic for Parameter.xaml
    /// </summary>
    public partial class Parameter : Window
    {
        public Parameter(Filter filter)
        {
            this.filter = filter;
            InitializeComponent();
        }

        private Filter filter;

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            filter.Save();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var pos = this.slider.Value;
            var length = this.slider.Maximum;

            filter.Apply(pos, length);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            filter.Restore();
        }
    }
}
