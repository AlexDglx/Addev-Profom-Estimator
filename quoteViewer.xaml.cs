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

namespace Addev_Profom_Estimator
{
    /// <summary>
    /// Logique d'interaction pour quoteViewer.xaml
    /// </summary>
    public partial class quoteViewer : Window
    {
        public quoteViewer()
        {
            InitializeComponent();
            LoadingPreview();
        }

        public void LoadingPreview()
        {
            quotViewerControl.Load(MainWindow.GlobalSecondPath.mySecondPath);
        }
    }
}
