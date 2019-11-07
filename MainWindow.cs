
// Based on API google maps https://github.com/maximn/google-maps

//icons found on https://icones8.fr/icons/" 
// Alex Degallaix for Addev Profom® all rights reserved a The & Company product.

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Addev_Profom_Estimator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public string[] customer;
        public object[] material;
        public string[] adhesive;

        public MainWindow()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTY3NzQzQDMxMzcyZTMzMmUzMGJYc2pXSDlsc1lrUHI3L2oxT2t6L2J4b2YxNk1qV3VQd0pBaDZEdXBuMG89");
            
        }


        public static class GlobalPath
        {
            public static string myPath = "";
        }

        public static class GlobalSecondPath
        {
            public static string mySecondPath = "";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Do you really want to close Addev Profom - Estimator ?", "Note", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".pdf",                // Default file extension
                Filter = "PDF (.pdf)|*.pdf"      // Filter files by extension
            };
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                GlobalPath.myPath = Path.GetFileName(dlg.FileName);

                PdfPreview NewPreview = new PdfPreview();
                NewPreview.Show();

            }

        }

        /*
        private void WebGoogleMapsAPI_Loaded(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Wait until google maps loads. Do not Click on : <Procédure à suivre> ", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        */

        public class CustomerDetails
        {
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerSector { get; set; }
            public string CustomerContact { get; set; }

            public CustomerDetails(string customerID, string customerName, string customerAddress, string customerEmail, string customerSector, string customerContact)
            {
                CustomerID = customerID;
                CustomerName = customerName;
                CustomerAddress = customerAddress;
                CustomerEmail = customerEmail;
                CustomerSector = customerSector;
                CustomerContact = customerContact;
            }


        }

        public IEnumerable<CustomerDetails> ReadCustomer(string fileName)
        {
            string[] lines = File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"));
            return lines.Select(line =>
            {
                string[] data = line.Split(';');
                return new CustomerDetails(data[0], data[1], data[3] + Environment.NewLine + data[4] + ", "
                    + data[7] + ", " + data[5] + Environment.NewLine + data[6], data[8], data[11], data[12]);
            });
        }

        private void ListViewCustomers_Initialized(object sender, EventArgs e)
        {
            ListViewCustomers.ItemsSource = ReadCustomer("data/data_clients");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewCustomers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CustomerID", ListSortDirection.Ascending));
           
        }

        public class MaterialDetails
        {
            public string MaterialID { get; set; }
            public string MaterialName { get; set; }
            public string MaterialThickness { get; set; }
            public string MaterialWidth { get; set; }
            public string MaterialLength { get; set; }
            public string MaterialSupplier { get; set; }
            public string MaterialPrice { get; set; }


            public MaterialDetails(string materialID, string materialName, string materialThickness, string materialWidth, string materialLength, string materialSupplier, string materialPrice)
            {
                MaterialID = materialID;
                MaterialName = materialName;
                MaterialThickness = materialThickness;
                MaterialWidth = materialWidth;
                MaterialLength = materialLength;
                MaterialSupplier = materialSupplier;
                MaterialPrice = materialPrice;
            }


        }

        public IEnumerable<MaterialDetails> ReadMaterial(string fileName)
        {
            string[] lines = File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"));
            return lines.Select(line =>
            {
                string[] data = line.Split(';');
                return new MaterialDetails(data[1], data[0], data[2], data[3], data[4], data[6], "CA$" + data[5]);

            });


        }

        private void ListViewMaterials_Initialized(object sender, EventArgs e)
        {
            ListViewMaterials.ItemsSource = ReadMaterial("data/data_material");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewMaterials.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Item ID", ListSortDirection.Ascending));
            
        }

        public class AdhesiveDetails
        {
            public string AdhesiveID { get; set; }
            public string AdhesiveName { get; set; }
            public string AdhesiveWidth { get; set; }
            public string AdhesiveLength { get; set; }
            public string AdhesiveSupplier { get; set; }
            public string AdhesivePrice { get; set; }

            public AdhesiveDetails(string adhesiveID, string adhesiveName, string adhesiveWidth, string adhesiveLength, string adhesiveSupplier, string adhesivePrice)
            {
                AdhesiveID = adhesiveID;
                AdhesiveName = adhesiveName;
                AdhesiveWidth = adhesiveWidth;
                AdhesiveLength = adhesiveLength;
                AdhesiveSupplier = adhesiveSupplier;
                AdhesivePrice = adhesivePrice;
            }

        }

        private void ListViewAdhesive_Initialized(object sender, EventArgs e)
        {
            ListViewAdhesive.ItemsSource = ReadAdhesive("data/data_adh");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewAdhesive.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Item ID", ListSortDirection.Ascending));
           
        }

        public IEnumerable<AdhesiveDetails> ReadAdhesive(string fileName)
        {
            string[] lines = File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"));
            return lines.Select(line =>
            {
                string[] data = line.Split(';');
                return new AdhesiveDetails(data[1], data[0], data[2], data[3], data[5], "CA$" + data[4]);
            });

        }

        private void ComboboxCustomer_Initialized(object sender, EventArgs e)
        {

            string[] lineOfContents = File.ReadAllLines("data/data_clients.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                _ = comboboxCustomer.Items.Add(tokens[1]);
            }
        }

        private void ComboMaterial_Initialized(object sender, EventArgs e)
        {

            string[] lineOfContents = File.ReadAllLines("data/data_material.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                _ = comboMaterial.Items.Add(tokens[0]);
            }

        }

        private void ComboAdhesive_Initialized(object sender, EventArgs e)
        {
            string[] lineOfContents = File.ReadAllLines("data/data_adh.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                _ = comboAdhesive.Items.Add(tokens[0]);
            }

        }

        private void Combobox_sales_rep_Initialized(object sender, EventArgs e)
        {

            string[] lineOfContents = File.ReadAllLines("data/data_rep.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                _ = combobox_sales_rep.Items.Add(tokens[0]);
            }

        }

        private void ComboboxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            combobox_sales_rep.SelectedIndex = -1;
            string[] lineOfContents = File.ReadAllLines("data/data_clients.txt");

            if (comboboxCustomer.SelectedItem != null)

            {
                string selectedCustomer = comboboxCustomer.SelectedItem.ToString();
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split(';');

                    if (selectedCustomer == tokens[1])

                    {

                        customer = new string[] { tokens[0], tokens[1], tokens[3] + Environment.NewLine + tokens[4] + ", "
                    + tokens[7] + ", " + tokens[5] + Environment.NewLine + tokens[6], tokens[8], tokens[11],tokens[12]};

                        addressText.Text = customer[2];
                        matriculeText.Text = customer[0];
                        contactNameText.Text = customer[5];
                        emailText.Text = customer[3];
                        sectorText.Text = customer[4];


                        /*
                         * Labels updated
                         */

                        companyMatricule.Content = customer[0];
                        companyName.Content = customer[1];
                        companyAddress.Content = customer[2];
                        companyEmail.Content = customer[3];
                        companySector.Content = customer[4];
                        companyContact.Content = customer[5];



                    }
                }

            }
            else
            {
                addressText.Text = "";
                matriculeText.Text = "";
                contactNameText.Text = "";
                emailText.Text = "";
                sectorText.Text = "";


                /*
                 * Labels updated
                 */

                companyMatricule.Content = "...";
                companyName.Content = "...";
                companyAddress.Content = "...";
                companyEmail.Content = "...";
                companySector.Content = "...";
                companyContact.Content = "...";
                labelSales_Rep.Content = "...";
            }

        }

        private void MatriculeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyMatricule.Content = matriculeText.Text;

            string[] lineOfContents = File.ReadAllLines("data/data_clients.txt");

            if (matriculeText.Text != null | matriculeText.Text == "")

            {
                string selectedCustomer = matriculeText.Text;
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split(';');

                    if (selectedCustomer == tokens[0])

                    {

                        customer = new string[] { tokens[0], tokens[1], tokens[3] + Environment.NewLine + tokens[4] + ", "
                    + tokens[7] + ", " + tokens[5] + Environment.NewLine + tokens[6], tokens[8], tokens[11], tokens[12]};

                        matriculeText.Text = customer[0];
                        comboboxCustomer.Text = customer[1];
                        addressText.Text = customer[2];
                        contactNameText.Text = customer[5];
                        emailText.Text = customer[3];
                        sectorText.Text = customer[4];

                        companyMatricule.Content = customer[0];
                        companyName.Content = customer[1];
                        companyAddress.Content = customer[2];
                        companyEmail.Content = customer[3];
                        companySector.Content = customer[4];
                        companyContact.Content = customer[5];
                    }
                }
            }
        }

        private void Combobox_sales_rep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_sales_rep.SelectedIndex != -1)
            {
                labelSales_Rep.Content = combobox_sales_rep.SelectedItem.ToString();
            }
        }

        private void AddressText_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyAddress.Content = addressText.Text;
        }

        private void ContactNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyContact.Content = contactNameText.Text;
        }

        private void EmailText_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyEmail.Content = emailText.Text;
        }

        private void SectorText_TextChanged(object sender, TextChangedEventArgs e)
        {
            companySector.Content = sectorText.Text;
        }

        private void ComboMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] lineOfContents = File.ReadAllLines("data/data_material.txt");

            materialItemCode.Content = "...";
            materialName.Content = "...";
            materialThickness.Content = "...";
            materialWidth.Content = "...";
            materialLength.Content = "...";
            materialSupplier.Content = "...";
            materialPrice.Content = "...";

            materialItemCode1.Content = "...";
            materialName1.Content = "...";
            materialThickness1.Content = "...";
            materialWidth1.Content = "...";
            materialLength1.Content = "...";
            materialSupplier1.Content = "...";
            materialPrice1.Content = "...";

            if (comboMaterial.SelectedItem != null)
            {
                string selectedCustomer = comboMaterial.SelectedItem.ToString();
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split(';');

                    if (selectedCustomer == tokens[0])

                    {

                        material = new string[] { tokens[1], tokens[0], tokens[2], tokens[3], tokens[4], tokens[6], tokens[5] };
                    }
                }
                materialItemCode.Content = material[0];
                materialName.Content = material[1];
                materialThickness.Content = material[2];
                materialWidth.Content = material[3];
                materialLength.Content = material[4];
                materialSupplier.Content = material[5];
                materialPrice.Content = "CA$" + material[6];

                materialItemCode1.Content = material[0];
                materialName1.Content = material[1];
                materialThickness1.Content = material[2];
                materialWidth1.Content = material[3];
                materialLength1.Content = material[4];
                materialSupplier1.Content = material[5];
                materialPrice1.Content = "CA$" + material[6];

            }
        }



        private void ComboAdhesive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] lineOfContents = File.ReadAllLines("data/data_adh.txt");

            adhesiveItemCode.Content = "...";
            adhesiveName.Content = "...";
            adhesiveWidth.Content = "...";
            adhesiveLength.Content = "...";
            adhesiveSupplier.Content = "...";
            adhesivePrice.Content = "...";

            adhesiveItemCode1.Content = "...";
            adhesiveName1.Content = "...";
            adhesiveWidth1.Content = "...";
            adhesiveLength1.Content = "...";
            adhesiveSupplier1.Content = "...";
            adhesivePrice1.Content = "...";

            if (comboAdhesive.SelectedItem != null)
            {
                string selectedCustomer = comboAdhesive.SelectedItem.ToString();
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split(';');

                    if (selectedCustomer == tokens[0])

                    {

                        adhesive = new string[] { tokens[1], tokens[0], tokens[2], tokens[3], tokens[5], tokens[4] };
                    }
                }
                adhesiveItemCode.Content = adhesive[0];
                adhesiveName.Content = adhesive[1];
                adhesiveWidth.Content = adhesive[2];
                adhesiveLength.Content = adhesive[3];
                adhesiveSupplier.Content = adhesive[4];
                adhesivePrice.Content = "CA$" + adhesive[5];

                adhesiveItemCode1.Content = adhesive[0];
                adhesiveName1.Content = adhesive[1];
                adhesiveWidth1.Content = adhesive[2];
                adhesiveLength1.Content = adhesive[3];
                adhesiveSupplier1.Content = adhesive[4];
                adhesivePrice1.Content = "CA$" + adhesive[5];

            }


        }

        private void TabControl_GotFocus(object sender, RoutedEventArgs e)
        {
            //Focus on Listview Update Customer List
            ListViewCustomers.ItemsSource = ReadCustomer("data/data_clients");
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewCustomers.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CustomerID", ListSortDirection.Ascending));
        }

        private void Delete_allCustomers_Click(object sender, RoutedEventArgs e)
        {
            comboboxCustomer.SelectedIndex = -1;
        }

        private void Todaysdate_Initialized(object sender, EventArgs e)
        {
            todaysdate.Content = DateTime.Now;
        }

        private void ComboProduct_Initialized(object sender, EventArgs e)
        {
            string[] lineOfContents = File.ReadAllLines("data/data_process.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');
                _ = comboProduct.Items.Add(tokens[0]);
            }

        }

        private void AdhesiveYesNo_Initialized(object sender, EventArgs e)
        {
            adhesiveYesNo.IsChecked = false;
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Items.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Items.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeViewItem { Header = directoryInfo.Name };
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Items.Add(CreateDirectoryNode(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Items.Add(new TreeViewItem { Header = file.Name });

            return directoryNode;

        }

        private void TreeView_Initialized(object sender, EventArgs e)
        {
            string path = "Datasheet/";
            ListDirectory(treeView, path);
        }

        private void WebGoogleMapsAPI_Initialized(object sender, EventArgs e)
        {

            webGoogleMapsAPI.Navigate("https://maps.google.com/maps/");
        }


        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                if (treeView.SelectedItem is TreeViewItem SelectedTreeViewItem)
                {
                    GlobalPath.myPath = SelectedTreeViewItem.Header.ToString();

                    if (GlobalPath.myPath.Contains(".pdf") == true)
                    {

                        PdfPreview NewPreview = new PdfPreview();

                        NewPreview.Show();

                    }

                } // perform task
            }


            finally
            {
                Mouse.OverrideCursor = null;
            }

        }

        // Display Current Quotes In File


        private void NewQuote_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                UserTab.IsEnabled = false;
                customerTab.IsEnabled = true;
                customerTab.IsSelected = true;
            }


            finally
            {
                Mouse.OverrideCursor = null;
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            User.Content = "User Logged in: " + UserLogin.GlobalUserName.myName;
            customerQty.Content = ListViewCustomers.Items.Count;
            materialQty.Content = ListViewMaterials.Items.Count;
            adhesiveQty.Content = ListViewAdhesive.Items.Count;

        }

        private void CustomerToMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Select a customer", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                materialTab.IsEnabled = true;
                materialTab.IsSelected = true;
            }

        }

        private void MaterialToAdhesiveTab_Click(object sender, RoutedEventArgs e)
        {
            if (comboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Select a material!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                adhesiveTab.IsEnabled = true;
                adhesiveTab.IsSelected = true;
            }
        }

        private void AdhesiveProductTab_Click(object sender, RoutedEventArgs e)
        {
            productTab.IsEnabled = true;
            productTab.IsSelected = true;
        }

        private void CancelNewQuote_Click(object sender, RoutedEventArgs e)
        {
            comboboxCustomer.SelectedIndex = -1;
            comboMaterial.SelectedIndex = -1;
            comboAdhesive.SelectedIndex = -1;
            comboProduct.SelectedIndex = -1;
            UserTab.IsEnabled = true;
            UserTab.IsSelected = true;
            customerTab.IsEnabled = false;
            customerTab.IsSelected = false;
            materialTab.IsEnabled = false;
            materialTab.IsSelected = false;
            adhesiveTab.IsEnabled = false;
            adhesiveTab.IsSelected = false;
            productTab.IsEnabled = false;
            productTab.IsSelected = false;

        }

        private void PreviousMaterialToCustomer_Click(object sender, RoutedEventArgs e)
        {
            customerTab.IsSelected = true;
        }

        private void PreviousAdhesiveToMaterial_Click(object sender, RoutedEventArgs e)
        {
            materialTab.IsSelected = true;
        }

        private void PreviousProductToAdhesive_Click(object sender, RoutedEventArgs e)
        {
            adhesiveTab.IsSelected = true;
        }

        private void CancelAll_Click(object sender, RoutedEventArgs e)
        {
            comboboxCustomer.SelectedIndex = -1;
            comboMaterial.SelectedIndex = -1;
            comboAdhesive.SelectedIndex = -1;
            comboProduct.SelectedIndex = -1;
            UserTab.IsEnabled = true;
            UserTab.IsSelected = true;
            customerTab.IsEnabled = false;
            customerTab.IsSelected = false;
            materialTab.IsEnabled = false;
            materialTab.IsSelected = false;
            adhesiveTab.IsEnabled = false;
            adhesiveTab.IsSelected = false;
            productTab.IsEnabled = false;
            productTab.IsSelected = false;
        }

        private void ComboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customerWidth.Clear();
            customerQuantity.Clear();
            customerNotes.Clear();

        }


        private void ListViewDataSheet_Initialized(object sender, EventArgs e)
        {
            string[] fileEntries = Directory.GetFiles(@"Quote/");
            foreach (string fileName in fileEntries)
                ListViewDataSheet.Items.Add(fileName);
        }

        private void ListViewDataSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = ListViewDataSheet.SelectedItem.ToString();
            GlobalSecondPath.mySecondPath = path;

            quoteViewer myquote = new quoteViewer();
                myquote.Show();
        }
    }
}
