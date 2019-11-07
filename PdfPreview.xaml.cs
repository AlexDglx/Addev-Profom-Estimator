using System.Windows;


namespace Addev_Profom_Estimator
{
    /// <summary>
    /// Logique d'interaction pour PdfViewer.xaml
    /// </summary>
    public partial class PdfPreview : Window
    {

        public PdfPreview()
        {
            InitializeComponent();

            LoadingPreview();
        }

        public void LoadingPreview()
        {
            pdfViewerControl.Load("DataSheet/" + MainWindow.GlobalPath.myPath);
        }
    }

}



