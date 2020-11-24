// Decompiled with JetBrains decompiler
// Type: Addev_Profom_Estimator.MainWindow
// Assembly: Addev Profom Estimator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1469F14B-65CB-4A1A-B5F3-444216902987
// Assembly location: /Users/adegallaix/Downloads/Addev Profom Estimator.exe

using Microsoft.Win32;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Windows.PdfViewer;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Addev_Profom_Estimator
{
  public class MainWindow : Window, IComponentConnector
  {
    public static object[] customer;
    public static object[] material;
    public static object[] adhesive;
    public static object[] product;
    public double MOQ;
    public double MOQ_lin;
    public int numberToProduce;
    public static double[] process = new double[9]
    {
      10.0,
      10.0,
      8.0,
      180.0,
      80.0,
      100.0,
      17.0,
      29.0,
      9.0
    };
    public static double[] selectedProcess;
    public string processDescription;
    public static double numberofRolls;
    public static double lamTimeWorked;
    public static double slitTimeWorked;
    public static double processLabour;
    public static double lamProcessLabour;
    public static double slitLabour;
    public static double packagingLabour;
    public static double totalMaterialPrice;
    public static double totalAdhesivePrice;
    public static double bigTotal;
    public static double pricePerRoll;
    public static double linearPriceperFeet;
    public static bool normalMainWindowState = false;
    private bool calendarvisibilityState;
    private bool datavisibilityState;
    private static readonly Regex _regex = new Regex("[^0-9.,]+");
    private static readonly Regex _regex1 = new Regex("[^0-9]+");
    internal MainWindow MainWindowControl;
    internal DockPanel dockPanel1;
    internal Label User;
    internal Image CloseImage;
    internal Image MaximizeImage;
    internal Image MinimizeImage;
    internal MenuItem newMenuQuote;
    internal MenuItem Open;
    internal MenuItem Exit;
    internal MenuItem CalendarVisible;
    internal MenuItem data;
    internal MenuItem settingsManager;
    internal MenuItem aboutTheApp;
    internal CalendarEdit calendarSyncfusion;
    internal ListView ListViewDataSheet;
    internal TreeView treeView;
    internal DockPanel stackPanel1;
    internal TabControl rightDataTabItem;
    internal TabItem cusTab;
    internal ListView ListViewCustomers;
    internal TabItem matTab;
    internal ListView ListViewMaterials;
    internal TabItem adTab;
    internal ListView ListViewAdhesive;
    internal DockPanel stackPanel2;
    internal TabControl userLogin;
    internal TabItem UserTab;
    internal Button NewQuote;
    internal TabItem customerTab;
    internal ComboBoxAdv comboboxCustomer;
    internal TextBox addressText;
    internal TextBox matriculeText;
    internal TextBox contactNameText;
    internal ComboBoxAdv combobox_sales_rep;
    internal TextBox emailText;
    internal TextBox sectorText;
    internal Button cancelNewQuote;
    internal Button CustomerToMaterial;
    internal Button delete_allCustomers;
    internal TabItem materialTab;
    internal Button PreviousMaterialToCustomer;
    internal Button MaterialToAdhesiveTab;
    internal Label materialWidth;
    internal Label materialLength;
    internal Label materialThickness;
    internal Label materialPrice;
    internal Label materialItemCode;
    internal Label materialName;
    internal Label materialQty;
    internal Label todaysdate;
    internal Label adhesiveQty;
    internal Label customerQty;
    internal ComboBoxAdv comboMaterial;
    internal TextBlock materialSupplier;
    internal TabItem adhesiveTab;
    internal ComboBoxAdv comboAdhesive;
    internal CheckBox adhesiveYesNo;
    internal Label adhesiveWidth;
    internal Label adhesiveLength;
    internal Label adhesivePrice;
    internal TextBlock adhesiveSupplier;
    internal Label adhesiveItemCode;
    internal Label adhesiveName;
    internal Button PreviousAdhesiveToMaterial;
    internal Button AdhesiveProductTab;
    internal TabItem productTab;
    internal TextBlock finalName;
    internal ComboBoxAdv comboProduct;
    internal TextBox productWidth;
    internal TextBox productNotes;
    internal TextBox productQuantity;
    internal Label customerProductLength;
    internal Label customerProductThickness;
    internal Button PreviousProductToAdhesive;
    internal Button validateCalculation;
    internal Button CancelAll;
    internal Grid DataProcess;
    internal TextBox StandardLaminationSpeed;
    internal TextBox SolidLaminationSpeed;
    internal TextBox A2LaminationSpeed;
    internal TextBox StandardSlittingSpeed;
    internal TextBox SolidSlittingSpeed;
    internal TextBox A2SlittingSpeed;
    internal TextBox OperatorValue;
    internal TextBox SpecializedOperatorValue;
    internal TextBox TransportValue;
    internal PdfViewerControl resultPDFViewer;
    internal Label companyName;
    internal Label companyAddress;
    internal Label companyMatricule;
    internal Label companyContact;
    internal Label companyEmail;
    internal Label labelSales_Rep;
    internal Label companySector;
    internal Label materialWidth1;
    internal Label materialLength1;
    internal Label materialThickness1;
    internal Label materialPrice1;
    internal Label materialSupplier1;
    internal Label materialItemCode1;
    internal Label materialName1;
    internal Label adhesiveWidth1;
    internal Label adhesiveLength1;
    internal Label adhesivePrice1;
    internal Label adhesiveSupplier1;
    internal Label adhesiveItemCode1;
    internal Label adhesiveName1;
    internal Label productName1;
    internal Label productWidht1;
    internal Label productLength1;
    internal Label productThickness1;
    internal Label productQuantity1;
    internal Label productPrice1;
    private bool _contentLoaded;

    public MainWindow()
    {
      base.\u002Ector();
      this.InitializeComponent();
      SyncfusionLicenseProvider.RegisterLicense("MTY3NzQzQDMxMzcyZTMzMmUzMGJYc2pXSDlsc1lrUHI3L2oxT2t6L2J4b2YxNk1qV3VQd0pBaDZEdXBuMG89");
      ((FrameworkElement) this).set_MaxHeight(SystemParameters.get_MaximizedPrimaryScreenHeight());
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Do you really want to close Addev Profom - Estimator ?", "Note", (MessageBoxButton) 4, (MessageBoxImage) 48) != 6)
        return;
      Application.get_Current().Shutdown();
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      ((FileDialog) openFileDialog1).set_DefaultExt(".pdf");
      ((FileDialog) openFileDialog1).set_Filter("PDF (.pdf)|*.pdf");
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = ((CommonDialog) openFileDialog2).ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      MainWindow.GlobalPath.myPath = Path.GetFileName(((FileDialog) openFileDialog2).get_FileName());
      new PdfPreview().Show();
    }

    public IEnumerable<MainWindow.CustomerDetails> ReadCustomer(string fileName) => ((IEnumerable<string>) File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"))).Select<string, MainWindow.CustomerDetails>((Func<string, MainWindow.CustomerDetails>) (line =>
    {
      string[] strArray = line.Split(';');
      return new MainWindow.CustomerDetails(strArray[0], strArray[1], strArray[3] + Environment.NewLine + strArray[4] + ", " + strArray[7] + ", " + strArray[5] + Environment.NewLine + strArray[6], strArray[8], strArray[11], strArray[12]);
    }));

    public IEnumerable<MainWindow.MaterialDetails> ReadMaterial(string fileName) => ((IEnumerable<string>) File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"))).Select<string, MainWindow.MaterialDetails>((Func<string, MainWindow.MaterialDetails>) (line =>
    {
      string[] strArray = line.Split(';');
      return new MainWindow.MaterialDetails(strArray[1], strArray[0], strArray[2], strArray[3], strArray[4], strArray[6], "CA$" + strArray[5]);
    }));

    public IEnumerable<MainWindow.AdhesiveDetails> ReadAdhesive(string fileName) => ((IEnumerable<string>) File.ReadAllLines(Path.ChangeExtension(fileName, ".txt"))).Select<string, MainWindow.AdhesiveDetails>((Func<string, MainWindow.AdhesiveDetails>) (line =>
    {
      string[] strArray = line.Split(';');
      return new MainWindow.AdhesiveDetails(strArray[1], strArray[0], strArray[2], strArray[3], strArray[5], "CA$" + strArray[4]);
    }));

    private void ComboboxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ((Selector) this.combobox_sales_rep).set_SelectedIndex(-1);
      string[] strArray1 = File.ReadAllLines("data/data_clients.txt");
      if (((Selector) this.comboboxCustomer).get_SelectedIndex() != -1)
      {
        string str1 = ((Selector) this.comboboxCustomer).get_SelectedItem().ToString();
        foreach (string str2 in strArray1)
        {
          char[] chArray = new char[1]{ ';' };
          string[] strArray2 = str2.Split(chArray);
          if (str1 == strArray2[1])
          {
            MainWindow.customer = new object[6]
            {
              (object) strArray2[0],
              (object) strArray2[1],
              (object) (strArray2[3] + Environment.NewLine + strArray2[4] + ", " + strArray2[7] + ", " + strArray2[5] + Environment.NewLine + strArray2[6]),
              (object) strArray2[8],
              (object) strArray2[11],
              (object) strArray2[12]
            };
            this.addressText.set_Text(Convert.ToString(MainWindow.customer[2]));
            this.matriculeText.set_Text(Convert.ToString(MainWindow.customer[0]));
            this.contactNameText.set_Text(Convert.ToString(MainWindow.customer[5]));
            this.emailText.set_Text(Convert.ToString(MainWindow.customer[3]));
            this.sectorText.set_Text(Convert.ToString(MainWindow.customer[4]));
            ((ContentControl) this.companyMatricule).set_Content(MainWindow.customer[0]);
            ((ContentControl) this.companyName).set_Content(MainWindow.customer[1]);
            ((ContentControl) this.companyAddress).set_Content(MainWindow.customer[2]);
            ((ContentControl) this.companyEmail).set_Content(MainWindow.customer[3]);
            ((ContentControl) this.companySector).set_Content(MainWindow.customer[4]);
            ((ContentControl) this.companyContact).set_Content(MainWindow.customer[5]);
          }
        }
      }
      else
      {
        this.addressText.set_Text("");
        this.matriculeText.set_Text("");
        this.contactNameText.set_Text("");
        this.emailText.set_Text("");
        this.sectorText.set_Text("");
        ((ContentControl) this.companyMatricule).set_Content((object) "...");
        ((ContentControl) this.companyName).set_Content((object) "...");
        ((ContentControl) this.companyAddress).set_Content((object) "...");
        ((ContentControl) this.companyEmail).set_Content((object) "...");
        ((ContentControl) this.companySector).set_Content((object) "...");
        ((ContentControl) this.companyContact).set_Content((object) "...");
        ((ContentControl) this.labelSales_Rep).set_Content((object) "...");
      }
    }

    private void MatriculeText_TextChanged(object sender, TextChangedEventArgs e)
    {
      string[] strArray1 = File.ReadAllLines("data/data_clients.txt");
      if (this.matriculeText.get_Text() == null && !(this.matriculeText.get_Text() == ""))
        return;
      string text = this.matriculeText.get_Text();
      foreach (string str in strArray1)
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray2 = str.Split(chArray);
        if (text == strArray2[0])
        {
          object[] objArray = new object[6]
          {
            (object) strArray2[0],
            (object) strArray2[1],
            (object) (strArray2[3] + Environment.NewLine + strArray2[4] + ", " + strArray2[7] + ", " + strArray2[5] + Environment.NewLine + strArray2[6]),
            (object) strArray2[8],
            (object) strArray2[11],
            (object) strArray2[12]
          };
          this.comboboxCustomer.set_Text(Convert.ToString(objArray[1]));
          this.addressText.set_Text(Convert.ToString(objArray[2]));
          this.contactNameText.set_Text(Convert.ToString(objArray[5]));
          this.emailText.set_Text(Convert.ToString(objArray[3]));
          this.sectorText.set_Text(Convert.ToString(objArray[4]));
          ((ContentControl) this.companyMatricule).set_Content(objArray[0]);
          ((ContentControl) this.companyName).set_Content(objArray[1]);
          ((ContentControl) this.companyAddress).set_Content(objArray[2]);
          ((ContentControl) this.companyEmail).set_Content(objArray[3]);
          ((ContentControl) this.companySector).set_Content(objArray[4]);
          ((ContentControl) this.companyContact).set_Content(objArray[5]);
        }
      }
    }

    private void Combobox_sales_rep_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (((Selector) this.combobox_sales_rep).get_SelectedIndex() == -1)
        return;
      ((ContentControl) this.labelSales_Rep).set_Content((object) ((Selector) this.combobox_sales_rep).get_SelectedItem().ToString());
    }

    private void AddressText_TextChanged(object sender, TextChangedEventArgs e) => ((ContentControl) this.companyAddress).set_Content((object) this.addressText.get_Text());

    private void ContactNameText_TextChanged(object sender, TextChangedEventArgs e) => ((ContentControl) this.companyContact).set_Content((object) this.contactNameText.get_Text());

    private void EmailText_TextChanged(object sender, TextChangedEventArgs e) => ((ContentControl) this.companyEmail).set_Content((object) this.emailText.get_Text());

    private void SectorText_TextChanged(object sender, TextChangedEventArgs e) => ((ContentControl) this.companySector).set_Content((object) this.sectorText.get_Text());

    private void ComboMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.productWidth.Clear();
      this.productQuantity.Clear();
      string[] strArray1 = File.ReadAllLines("data/data_material.txt");
      ((ContentControl) this.materialItemCode).set_Content((object) "...");
      ((ContentControl) this.materialName).set_Content((object) "...");
      ((ContentControl) this.materialThickness).set_Content((object) "...");
      ((ContentControl) this.materialWidth).set_Content((object) "...");
      ((ContentControl) this.materialLength).set_Content((object) "...");
      this.materialSupplier.set_Text("...");
      ((ContentControl) this.materialPrice).set_Content((object) "...");
      ((ContentControl) this.materialItemCode1).set_Content((object) "...");
      ((ContentControl) this.materialName1).set_Content((object) "...");
      ((ContentControl) this.materialThickness1).set_Content((object) "...");
      ((ContentControl) this.materialWidth1).set_Content((object) "...");
      ((ContentControl) this.materialLength1).set_Content((object) "...");
      ((ContentControl) this.materialSupplier1).set_Content((object) "...");
      ((ContentControl) this.materialPrice1).set_Content((object) "...");
      ((ContentControl) this.productLength1).set_Content((object) "...");
      ((ContentControl) this.productThickness1).set_Content((object) "...");
      ((ContentControl) this.customerProductLength).set_Content((object) "...");
      ((ContentControl) this.customerProductThickness).set_Content((object) "...");
      if (((Selector) this.comboMaterial).get_SelectedIndex() != -1)
      {
        string str1 = ((Selector) this.comboMaterial).get_SelectedItem().ToString();
        foreach (string str2 in strArray1)
        {
          char[] chArray = new char[1]{ ';' };
          string[] strArray2 = str2.Split(chArray);
          if (str1 == strArray2[0])
          {
            MainWindow.material = new object[7]
            {
              (object) Convert.ToString(strArray2[1]),
              (object) strArray2[0],
              (object) strArray2[2],
              (object) strArray2[3],
              (object) strArray2[4],
              (object) strArray2[6],
              (object) strArray2[5]
            };
            ((ContentControl) this.customerProductLength).set_Content((object) strArray2[4]);
            ((ContentControl) this.customerProductThickness).set_Content((object) strArray2[2]);
            MainWindow.product = new object[5]
            {
              (object) Convert.ToDouble(strArray2[4]),
              (object) Convert.ToDouble(this.FractionToFloat(strArray2[2])),
              (object) 0,
              (object) 0,
              (object) 0
            };
          }
        }
        ((ContentControl) this.materialItemCode).set_Content(MainWindow.material[0]);
        ((ContentControl) this.materialName).set_Content(MainWindow.material[1]);
        ((ContentControl) this.materialThickness).set_Content(MainWindow.material[2]);
        ((ContentControl) this.materialWidth).set_Content(MainWindow.material[3]);
        ((ContentControl) this.materialLength).set_Content(MainWindow.material[4]);
        this.materialSupplier.set_Text(MainWindow.material[5].ToString());
        ((ContentControl) this.materialPrice).set_Content((object) ("CA$" + MainWindow.material[6]?.ToString()));
        ((ContentControl) this.materialItemCode1).set_Content(MainWindow.material[0]);
        ((ContentControl) this.materialName1).set_Content(MainWindow.material[1]);
        ((ContentControl) this.materialThickness1).set_Content(MainWindow.material[2]);
        ((ContentControl) this.materialWidth1).set_Content(MainWindow.material[3]);
        ((ContentControl) this.materialLength1).set_Content(MainWindow.material[4]);
        ((ContentControl) this.materialSupplier1).set_Content(MainWindow.material[5]);
        ((ContentControl) this.materialPrice1).set_Content((object) ("CA$" + MainWindow.material[6]?.ToString()));
        ((ContentControl) this.productLength1).set_Content(MainWindow.material[4]);
        ((ContentControl) this.productThickness1).set_Content(MainWindow.material[2]);
      }
      this.ProcessValueUpdate();
    }

    private void ComboAdhesive_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      string[] strArray1 = File.ReadAllLines("data/data_adh.txt");
      ((ContentControl) this.adhesiveItemCode).set_Content((object) "...");
      ((ContentControl) this.adhesiveName).set_Content((object) "...");
      ((ContentControl) this.adhesiveWidth).set_Content((object) "...");
      ((ContentControl) this.adhesiveLength).set_Content((object) "...");
      this.adhesiveSupplier.set_Text("...");
      ((ContentControl) this.adhesivePrice).set_Content((object) "...");
      ((ContentControl) this.adhesiveItemCode1).set_Content((object) "...");
      ((ContentControl) this.adhesiveName1).set_Content((object) "...");
      ((ContentControl) this.adhesiveWidth1).set_Content((object) "...");
      ((ContentControl) this.adhesiveLength1).set_Content((object) "...");
      ((ContentControl) this.adhesiveSupplier1).set_Content((object) "...");
      ((ContentControl) this.adhesivePrice1).set_Content((object) "...");
      if (((Selector) this.comboAdhesive).get_SelectedItem() == null)
        return;
      string str1 = ((Selector) this.comboAdhesive).get_SelectedItem().ToString();
      foreach (string str2 in strArray1)
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray2 = str2.Split(chArray);
        if (str1 == strArray2[0])
          MainWindow.adhesive = new object[6]
          {
            (object) strArray2[1],
            (object) strArray2[0],
            (object) strArray2[2],
            (object) strArray2[3],
            (object) strArray2[5],
            (object) strArray2[4]
          };
      }
      ((ContentControl) this.adhesiveItemCode).set_Content(MainWindow.adhesive[0]);
      ((ContentControl) this.adhesiveName).set_Content(MainWindow.adhesive[1]);
      ((ContentControl) this.adhesiveWidth).set_Content(MainWindow.adhesive[2]);
      ((ContentControl) this.adhesiveLength).set_Content(MainWindow.adhesive[3]);
      this.adhesiveSupplier.set_Text(Convert.ToString(MainWindow.adhesive[4]));
      ((ContentControl) this.adhesivePrice).set_Content((object) ("CA$" + MainWindow.adhesive[5]?.ToString()));
      ((ContentControl) this.adhesiveItemCode1).set_Content(MainWindow.adhesive[0]);
      ((ContentControl) this.adhesiveName1).set_Content(MainWindow.adhesive[1]);
      ((ContentControl) this.adhesiveWidth1).set_Content(MainWindow.adhesive[2]);
      ((ContentControl) this.adhesiveLength1).set_Content(MainWindow.adhesive[3]);
      ((ContentControl) this.adhesiveSupplier1).set_Content(MainWindow.adhesive[4]);
      ((ContentControl) this.adhesivePrice1).set_Content((object) ("CA$" + MainWindow.adhesive[5]?.ToString()));
    }

    private void TabControl_GotFocus(object sender, RoutedEventArgs e)
    {
      ((ItemsControl) this.ListViewCustomers).set_ItemsSource((IEnumerable) this.ReadCustomer("data/data_clients"));
      ((CollectionView) CollectionViewSource.GetDefaultView((object) ((ItemsControl) this.ListViewCustomers).get_ItemsSource())).get_SortDescriptions().Add(new SortDescription("CustomerID", ListSortDirection.Ascending));
    }

    private void Delete_allCustomers_Click(object sender, RoutedEventArgs e) => ((Selector) this.comboboxCustomer).set_SelectedIndex(-1);

    private void AdhesiveYesNo_Initialized(object sender, EventArgs e) => ((ToggleButton) this.adhesiveYesNo).set_IsChecked(new bool?(false));

    private void ListDirectory(TreeView treeView, string path)
    {
      ((ItemsControl) treeView).get_Items().Clear();
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      ((ItemsControl) treeView).get_Items().Add((object) MainWindow.CreateDirectoryNode(directoryInfo));
    }

    private static TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo)
    {
      TreeViewItem treeViewItem1 = new TreeViewItem();
      ((HeaderedItemsControl) treeViewItem1).set_Header((object) directoryInfo.Name);
      TreeViewItem treeViewItem2 = treeViewItem1;
      foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
        ((ItemsControl) treeViewItem2).get_Items().Add((object) MainWindow.CreateDirectoryNode(directory));
      foreach (FileInfo file in directoryInfo.GetFiles())
      {
        ItemCollection items = ((ItemsControl) treeViewItem2).get_Items();
        TreeViewItem treeViewItem3 = new TreeViewItem();
        ((HeaderedItemsControl) treeViewItem3).set_Header((object) file.Name);
        items.Add((object) treeViewItem3);
      }
      return treeViewItem2;
    }

    private void TreeView_SelectedItemChanged(
      object sender,
      RoutedPropertyChangedEventArgs<object> e)
    {
      Mouse.set_OverrideCursor(Cursors.get_Wait());
      try
      {
        if (!(this.treeView.get_SelectedItem() is TreeViewItem selectedItem))
          return;
        MainWindow.GlobalPath.myPath = ((HeaderedItemsControl) selectedItem).get_Header().ToString();
        if (!MainWindow.GlobalPath.myPath.Contains(".pdf"))
          return;
        new PdfPreview().Show();
      }
      finally
      {
        Mouse.set_OverrideCursor((Cursor) null);
      }
    }

    private void NewQuote_Click(object sender, RoutedEventArgs e)
    {
      Mouse.set_OverrideCursor(Cursors.get_Wait());
      try
      {
        ((UIElement) this.UserTab).set_IsEnabled(false);
        ((UIElement) this.customerTab).set_IsEnabled(true);
        this.customerTab.set_IsSelected(true);
      }
      finally
      {
        Mouse.set_OverrideCursor((Cursor) null);
      }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      ((FrameworkElement) this).set_DataContext((object) MainWindow.ProcessSpecs.GetProcess());
      ((ContentControl) this.todaysdate).set_Content((object) DateTime.Now);
      ((ContentControl) this.User).set_Content((object) ("User: " + UserLogin.GlobalUserName.myName));
      ((ItemsControl) this.ListViewDataSheet).get_Items().Clear();
      foreach (string enumerateFile in Directory.EnumerateFiles("Quote/"))
      {
        if (string.Compare(Path.GetExtension(enumerateFile), ".pdf", true) == 0)
          ((ItemsControl) this.ListViewDataSheet).get_Items().Add((object) Path.GetFileName(enumerateFile));
      }
      ((ItemsControl) this.ListViewCustomers).set_ItemsSource((IEnumerable) this.ReadCustomer("data/data_clients"));
      ((CollectionView) CollectionViewSource.GetDefaultView((object) ((ItemsControl) this.ListViewCustomers).get_ItemsSource())).get_SortDescriptions().Add(new SortDescription("CustomerID", ListSortDirection.Ascending));
      ((ItemsControl) this.ListViewCustomers).set_ItemsSource((IEnumerable) this.ReadCustomer("data/data_clients"));
      ((CollectionView) CollectionViewSource.GetDefaultView((object) ((ItemsControl) this.ListViewCustomers).get_ItemsSource())).get_SortDescriptions().Add(new SortDescription("CustomerID", ListSortDirection.Ascending));
      ((ItemsControl) this.ListViewMaterials).set_ItemsSource((IEnumerable) this.ReadMaterial("data/data_material"));
      ((CollectionView) CollectionViewSource.GetDefaultView((object) ((ItemsControl) this.ListViewMaterials).get_ItemsSource())).get_SortDescriptions().Add(new SortDescription("Item ID", ListSortDirection.Ascending));
      ((ItemsControl) this.ListViewAdhesive).set_ItemsSource((IEnumerable) this.ReadAdhesive("data/data_adh"));
      ((CollectionView) CollectionViewSource.GetDefaultView((object) ((ItemsControl) this.ListViewAdhesive).get_ItemsSource())).get_SortDescriptions().Add(new SortDescription("Item ID", ListSortDirection.Ascending));
      this.ListDirectory(this.treeView, "Datasheet/");
      foreach (string readAllLine in File.ReadAllLines("data/data_clients.txt"))
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = readAllLine.Split(chArray);
        ((ItemsControl) this.comboboxCustomer).get_Items().Add((object) strArray[1]);
      }
      foreach (string readAllLine in File.ReadAllLines("data/data_process.txt"))
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = readAllLine.Split(chArray);
        ((ItemsControl) this.comboProduct).get_Items().Add((object) strArray[0]);
      }
      foreach (string readAllLine in File.ReadAllLines("data/data_material.txt"))
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = readAllLine.Split(chArray);
        ((ItemsControl) this.comboMaterial).get_Items().Add((object) strArray[0]);
      }
      foreach (string readAllLine in File.ReadAllLines("data/data_adh.txt"))
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = readAllLine.Split(chArray);
        ((ItemsControl) this.comboAdhesive).get_Items().Add((object) strArray[0]);
      }
      foreach (string readAllLine in File.ReadAllLines("data/data_rep.txt"))
      {
        char[] chArray = new char[1]{ ';' };
        string[] strArray = readAllLine.Split(chArray);
        ((ItemsControl) this.combobox_sales_rep).get_Items().Add((object) strArray[0]);
      }
      ((ContentControl) this.customerQty).set_Content((object) ((CollectionView) ((ItemsControl) this.ListViewCustomers).get_Items()).get_Count());
      ((ContentControl) this.materialQty).set_Content((object) ((CollectionView) ((ItemsControl) this.ListViewMaterials).get_Items()).get_Count());
      ((ContentControl) this.adhesiveQty).set_Content((object) ((CollectionView) ((ItemsControl) this.ListViewAdhesive).get_Items()).get_Count());
    }

    private void CustomerToMaterial_Click(object sender, RoutedEventArgs e)
    {
      if (((Selector) this.comboboxCustomer).get_SelectedIndex() == -1)
      {
        MessageBox.Show("Select a customer", "Warning", (MessageBoxButton) 0, (MessageBoxImage) 48);
      }
      else
      {
        ((UIElement) this.materialTab).set_IsEnabled(true);
        this.materialTab.set_IsSelected(true);
      }
    }

    private void MaterialToAdhesiveTab_Click(object sender, RoutedEventArgs e)
    {
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
      {
        MessageBox.Show("Select a material!", "Warning", (MessageBoxButton) 0, (MessageBoxImage) 48);
      }
      else
      {
        ((UIElement) this.adhesiveTab).set_IsEnabled(true);
        this.adhesiveTab.set_IsSelected(true);
      }
    }

    private void AdhesiveProductTab_Click(object sender, RoutedEventArgs e)
    {
      ((UIElement) this.productTab).set_IsEnabled(true);
      this.productTab.set_IsSelected(true);
    }

    private void CancelNewQuote_Click(object sender, RoutedEventArgs e)
    {
      ((Selector) this.comboboxCustomer).set_SelectedIndex(-1);
      ((Selector) this.comboMaterial).set_SelectedIndex(-1);
      ((Selector) this.comboAdhesive).set_SelectedIndex(-1);
      ((Selector) this.comboProduct).set_SelectedIndex(-1);
      ((UIElement) this.UserTab).set_IsEnabled(true);
      this.UserTab.set_IsSelected(true);
      ((UIElement) this.customerTab).set_IsEnabled(false);
      this.customerTab.set_IsSelected(false);
      ((UIElement) this.materialTab).set_IsEnabled(false);
      this.materialTab.set_IsSelected(false);
      ((UIElement) this.adhesiveTab).set_IsEnabled(false);
      this.adhesiveTab.set_IsSelected(false);
      ((UIElement) this.productTab).set_IsEnabled(false);
      this.productTab.set_IsSelected(false);
    }

    private void PreviousMaterialToCustomer_Click(object sender, RoutedEventArgs e) => this.customerTab.set_IsSelected(true);

    private void PreviousAdhesiveToMaterial_Click(object sender, RoutedEventArgs e) => this.materialTab.set_IsSelected(true);

    private void PreviousProductToAdhesive_Click(object sender, RoutedEventArgs e) => this.adhesiveTab.set_IsSelected(true);

    private void CancelAll_Click(object sender, RoutedEventArgs e)
    {
      ((Selector) this.comboboxCustomer).set_SelectedIndex(-1);
      ((Selector) this.comboMaterial).set_SelectedIndex(-1);
      ((Selector) this.comboAdhesive).set_SelectedIndex(-1);
      ((Selector) this.comboProduct).set_SelectedIndex(-1);
      ((UIElement) this.UserTab).set_IsEnabled(true);
      this.UserTab.set_IsSelected(true);
      ((UIElement) this.customerTab).set_IsEnabled(false);
      this.customerTab.set_IsSelected(false);
      ((UIElement) this.materialTab).set_IsEnabled(false);
      this.materialTab.set_IsSelected(false);
      ((UIElement) this.adhesiveTab).set_IsEnabled(false);
      this.adhesiveTab.set_IsSelected(false);
      ((UIElement) this.productTab).set_IsEnabled(false);
      this.productTab.set_IsSelected(false);
    }

    private void ComboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.productWidth.Clear();
      this.productQuantity.Clear();
      this.productNotes.Clear();
      if (((Selector) this.comboAdhesive).get_SelectedIndex() != -1)
      {
        ((ContentControl) this.productName1).set_Content((object) (this.comboMaterial.get_Text() + "-" + this.comboAdhesive.get_Text()));
        this.finalName.set_Text(this.comboMaterial.get_Text() + "-" + this.comboAdhesive.get_Text());
      }
      else
      {
        ((ContentControl) this.productName1).set_Content((object) this.comboMaterial.get_Text());
        this.finalName.set_Text(this.comboMaterial.get_Text());
      }
    }

    private void ListViewDataSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (((Selector) this.ListViewDataSheet).get_SelectedIndex() <= -1)
        return;
      MainWindow.GlobalSecondPath.mySecondPath = "Quote/" + ((Selector) this.ListViewDataSheet).get_SelectedItem().ToString();
      new quoteViewer().Show();
    }

    private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e) => Application.get_Current().Shutdown();

    private void MaximizeImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (!MainWindow.normalMainWindowState)
      {
        MainWindow.normalMainWindowState = true;
        this.set_WindowState((WindowState) 0);
      }
      else
      {
        MainWindow.normalMainWindowState = false;
        this.set_WindowState((WindowState) 2);
      }
    }

    private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e) => this.set_WindowState((WindowState) 1);

    private void Menu_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.get_LeftButton() != 1)
        return;
      this.DragMove();
    }

    private void Menu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (((MouseEventArgs) e).get_LeftButton() == 1 && !MainWindow.normalMainWindowState)
      {
        MainWindow.normalMainWindowState = true;
        this.set_WindowState((WindowState) 0);
      }
      else
      {
        MainWindow.normalMainWindowState = false;
        this.set_WindowState((WindowState) 2);
      }
    }

    private void AdhesiveYesNo_Checked(object sender, RoutedEventArgs e)
    {
      ((Selector) this.comboAdhesive).set_SelectedIndex(-1);
      ((UIElement) this.comboAdhesive).set_IsEnabled(false);
    }

    private void AdhesiveYesNo_Unchecked(object sender, RoutedEventArgs e) => ((UIElement) this.comboAdhesive).set_IsEnabled(true);

    private void CalendarVisible_Click(object sender, RoutedEventArgs e)
    {
      if (this.calendarvisibilityState)
      {
        ((UIElement) this.calendarSyncfusion).set_Visibility((Visibility) 2);
        this.calendarvisibilityState = false;
      }
      else
      {
        ((UIElement) this.calendarSyncfusion).set_Visibility((Visibility) 0);
        this.calendarvisibilityState = true;
      }
    }

    private void Data_Click(object sender, RoutedEventArgs e)
    {
      if (this.datavisibilityState)
      {
        ((UIElement) this.rightDataTabItem).set_Visibility((Visibility) 1);
        this.datavisibilityState = false;
      }
      else
      {
        ((UIElement) this.rightDataTabItem).set_Visibility((Visibility) 0);
        this.datavisibilityState = true;
      }
    }

    private void CustomerWidth_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private static bool IsTextAllowed(string text) => !MainWindow._regex.IsMatch(text);

    private static bool QtyIsTextAllowed(string text) => !MainWindow._regex1.IsMatch(text);

    private void CustomerWidth_TextBoxPasting(object sender, DataObjectPastingEventArgs e)
    {
      if (e.get_DataObject().GetDataPresent(typeof (string)))
      {
        if (MainWindow.IsTextAllowed((string) e.get_DataObject().GetData(typeof (string))))
          return;
        ((DataObjectEventArgs) e).CancelCommand();
      }
      else
        ((DataObjectEventArgs) e).CancelCommand();
    }

    private void CustomerQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.QtyIsTextAllowed(e.get_Text()));

    private void CustomerQuantity_TextBoxPasting(object sender, DataObjectPastingEventArgs e)
    {
      if (e.get_DataObject().GetDataPresent(typeof (string)))
      {
        if (MainWindow.IsTextAllowed((string) e.get_DataObject().GetData(typeof (string))))
          return;
        ((DataObjectEventArgs) e).CancelCommand();
      }
      else
        ((DataObjectEventArgs) e).CancelCommand();
    }

    public double FractionToFloat(string fraction)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
      if (fraction.Contains("/"))
      {
        fraction = fraction.Replace(" ", string.Empty);
        fraction = fraction.Replace("/", string.Empty);
        if (fraction != "NA" && fraction != null)
        {
          double num = 0.0;
          if (fraction.Length == 2)
            num = double.Parse(fraction.Substring(0, 1), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat) / double.Parse(fraction.Substring(1, 1), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat);
          if (fraction.Length == 3)
            num = double.Parse(fraction.Substring(0, 1), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat) / double.Parse(fraction.Substring(1, 2), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat);
          if (fraction.Length == 4)
            num = double.Parse(fraction.Substring(0, 2), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat) / double.Parse(fraction.Substring(2, 2), (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat);
          return Math.Round(num, 3);
        }
      }
      else
      {
        double result;
        if (double.TryParse(fraction, out result))
          return result;
      }
      throw new FormatException("Not a valid fraction.");
    }

    private void NewMenuQuote_Click(object sender, RoutedEventArgs e) => this.CancelAll_Click(sender, e);

    private void ProductWidth_TextChanged(object sender, TextChangedEventArgs e)
    {
      ((Control) this.productWidth).set_BorderBrush((Brush) Brushes.get_Black());
      ((Control) this.productWidth).set_Foreground((Brush) Brushes.get_Black());
      double result;
      double.TryParse(this.productWidth.get_Text(), NumberStyles.Any, (IFormatProvider) CultureInfo.CurrentCulture.NumberFormat, out result);
      if (result <= Convert.ToDouble(MainWindow.material[3]))
      {
        MainWindow.product[2] = (object) Convert.ToDouble(result);
        ((ContentControl) this.productWidht1).set_Content(MainWindow.product[2]);
      }
      else
      {
        MessageBox.Show("Product width must be smaller than the selected material.", "Warning", (MessageBoxButton) 0, (MessageBoxImage) 16);
        this.productWidth.Clear();
      }
    }

    private void ProductQuantity_TextChanged(object sender, TextChangedEventArgs e)
    {
      ((Control) this.productQuantity).set_BorderBrush((Brush) Brushes.get_Black());
      ((Control) this.productQuantity).set_Foreground((Brush) Brushes.get_Black());
      double result;
      double.TryParse(this.productQuantity.get_Text(), out result);
      MainWindow.product[3] = (object) Convert.ToDouble(result);
      double num = Math.Pow(2.0, 31.0);
      if (Convert.ToDouble(MainWindow.product[3]) < num)
      {
        ((ContentControl) this.productQuantity1).set_Content(MainWindow.product[3]);
      }
      else
      {
        MessageBox.Show("Quantity must be between " + num.ToString() + " and -" + num.ToString() + ".", "Warning", (MessageBoxButton) 0, (MessageBoxImage) 16);
        this.productQuantity.Clear();
      }
    }

    private void UserLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (((Selector) this.comboAdhesive).get_SelectedIndex() != -1)
      {
        ((ContentControl) this.productName1).set_Content((object) (this.comboMaterial.get_Text() + "-" + this.comboAdhesive.get_Text()));
        this.finalName.set_Text(this.comboMaterial.get_Text() + "-" + this.comboAdhesive.get_Text());
      }
      else
      {
        ((ContentControl) this.productName1).set_Content((object) this.comboMaterial.get_Text());
        this.finalName.set_Text(this.comboMaterial.get_Text());
      }
    }

    private void ProductNotes_TextChanged(object sender, TextChangedEventArgs e) => MainWindow.product[4] = (object) this.productNotes.get_Text();

    public double[] Process
    {
      get => MainWindow.process;
      set => MainWindow.process = value;
    }

    private void ValidateCalculation_Click(object sender, RoutedEventArgs e)
    {
      if (((Selector) this.comboProduct).get_SelectedIndex() == 0 && (this.productWidth.get_Text() != "" || this.productQuantity.get_Text() != "") && (this.productWidth.get_Text() != "0" || this.productQuantity.get_Text() != "0"))
      {
        ((Control) this.productQuantity).set_BorderBrush((Brush) Brushes.get_Black());
        ((Control) this.productQuantity).set_Foreground((Brush) Brushes.get_Black());
        ((Control) this.productWidth).set_BorderBrush((Brush) Brushes.get_Black());
        ((Control) this.productWidth).set_Foreground((Brush) Brushes.get_Black());
        if (MainWindow.product[2] != null && MainWindow.product[3] != null)
        {
          this.productWidth.set_Text(MainWindow.product[2].ToString());
          this.productQuantity.set_Text(MainWindow.product[3].ToString());
          this.MOQ = Math.Floor((Convert.ToDouble(MainWindow.material[3]) - 2.0) / Convert.ToDouble(MainWindow.product[2]));
          this.MOQ_lin = this.MOQ * Convert.ToDouble(MainWindow.material[4]);
          this.numberToProduce = Convert.ToDouble(MainWindow.product[3]) / this.MOQ < 1.0 ? Convert.ToInt32(this.MOQ) : Convert.ToInt32(Convert.ToDouble(MainWindow.product[3]));
          bool? isChecked = ((ToggleButton) this.adhesiveYesNo).get_IsChecked();
          bool flag = false;
          if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
            this.DocumentCreator();
          else
            this.DocumentCreatorNoAdhesive();
        }
        else if (this.MOQ != double.PositiveInfinity && this.MOQ > 0.0)
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ);
          bool? isChecked = ((ToggleButton) this.adhesiveYesNo).get_IsChecked();
          bool flag = false;
          if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
            this.DocumentCreator();
          else
            this.DocumentCreatorNoAdhesive();
        }
        else
        {
          MessageBox.Show("Quantity and dimension can't be equal to 0.");
          ((Control) this.productQuantity).set_BorderBrush((Brush) Brushes.get_DarkRed());
          ((Control) this.productQuantity).set_Foreground((Brush) Brushes.get_DarkRed());
          ((Control) this.productWidth).set_BorderBrush((Brush) Brushes.get_DarkRed());
          ((Control) this.productWidth).set_Foreground((Brush) Brushes.get_DarkRed());
        }
      }
      else
      {
        MessageBox.Show("Select a product." + Environment.NewLine + "Value for the thickness and the quantity must be different to 0.", "Warning", (MessageBoxButton) 0, (MessageBoxImage) 16);
        this.productWidth.Clear();
        this.productQuantity.Clear();
      }
    }

    private void DocumentCreator()
    {
      Mouse.set_OverrideCursor(Cursors.get_Wait());
      try
      {
        if (((Selector) this.comboMaterial).get_SelectedIndex() != -1)
        {
          if (((Selector) this.comboMaterial).get_SelectedIndex() != -1)
          {
            if (((Selector) this.comboAdhesive).get_SelectedIndex() != -1)
            {
              if (((Selector) this.comboProduct).get_SelectedIndex() != -1)
                this.CreatePdfPreview();
            }
          }
        }
      }
      finally
      {
        Mouse.set_OverrideCursor((Cursor) null);
      }
      ((ListBox) this.ListViewDataSheet).UnselectAll();
    }

    private void DocumentCreatorNoAdhesive()
    {
      this.CalculationWithSelectedProcess();
      Mouse.set_OverrideCursor(Cursors.get_Wait());
      try
      {
        WordDocument wordDocument = new WordDocument("template/estimation-template - no adhesive.docx", (FormatType) 2);
        wordDocument.Find("$Date", false, true).GetAsOneRange().set_Text(DateTime.Now.Date.ToString("yyyy/MM/dd"));
        wordDocument.Find("$UserName", false, true).GetAsOneRange().set_Text(((ContentControl) this.User).get_Content().ToString());
        wordDocument.Find("$MATERIELNOMADHESIVENAME", false, true).GetAsOneRange().set_Text(this.finalName.get_Text());
        wordDocument.Find("$Vendeur", false, true).GetAsOneRange().set_Text(this.combobox_sales_rep.get_Text());
        string[] strArray1 = new string[6]
        {
          "$Matricule",
          "$Entreprise",
          "$Adresse",
          "$eMail",
          "$Secteur",
          "$Nom"
        };
        object[] objArray1 = new object[6]
        {
          ((ContentControl) this.companyMatricule).get_Content(),
          ((ContentControl) this.companyName).get_Content(),
          ((ContentControl) this.companyAddress).get_Content(),
          ((ContentControl) this.companyEmail).get_Content(),
          ((ContentControl) this.companySector).get_Content(),
          ((ContentControl) this.companyContact).get_Content()
        };
        for (int index = 0; index <= 5; ++index)
          wordDocument.Find(strArray1[index], false, true).GetAsOneRange().set_Text(objArray1[index].ToString());
        string[] strArray2 = new string[7]
        {
          "$MaterielItem",
          "$MaterielNom",
          "$MaterielEpaisseur",
          "$MaterielLargeur",
          "$MaterielLongueur",
          "$MaterielFournisseur",
          "$MaterielPrix"
        };
        for (int index = 0; index <= 6; ++index)
          wordDocument.Find(strArray2[index], false, true).GetAsOneRange().set_Text(MainWindow.material[index].ToString());
        string[] strArray3 = new string[3]
        {
          "$ProductLongueur",
          "$ProductEpaisseur",
          "$ProductLargeur"
        };
        for (int index = 0; index <= 2; ++index)
          wordDocument.Find(strArray3[index], false, true).GetAsOneRange().set_Text(MainWindow.product[index].ToString());
        wordDocument.Find("$SelectedProduct", false, true).GetAsOneRange().set_Text(((Selector) this.comboProduct).get_SelectedItem().ToString());
        wordDocument.Find("$MOQ", false, true).GetAsOneRange().set_Text(this.MOQ.ToString());
        wordDocument.Find("$Notes", false, true).GetAsOneRange().set_Text(this.productNotes.get_Text());
        wordDocument.Find("$Qty", false, true).GetAsOneRange().set_Text(this.productQuantity.get_Text());
        wordDocument.Find("$NumberToProduce", false, true).GetAsOneRange().set_Text(this.numberToProduce.ToString());
        wordDocument.Find("$TotalMateriel", false, true).GetAsOneRange().set_Text(MainWindow.totalMaterialPrice.ToString());
        wordDocument.Find("$PrixPiedLineaire", false, true).GetAsOneRange().set_Text(MainWindow.linearPriceperFeet.ToString());
        string[] strArray4 = new string[4]
        {
          "$SlitCadence",
          "$SlitLabour",
          "$SlitTime",
          "$PackLabour"
        };
        object[] objArray2 = new object[4]
        {
          (object) MainWindow.selectedProcess[1],
          (object) MainWindow.slitLabour,
          (object) MainWindow.slitTimeWorked,
          (object) MainWindow.packagingLabour
        };
        for (int index = 0; index < strArray4.Length; ++index)
          wordDocument.Find(strArray4[index], false, true).GetAsOneRange().set_Text(objArray2[index].ToString());
        wordDocument.Find("$TotalProduit", false, true).GetAsOneRange().set_Text(MainWindow.bigTotal.ToString());
        wordDocument.Find("$PrixParRlx", false, true).GetAsOneRange().set_Text(MainWindow.pricePerRoll.ToString());
        Syncfusion.DocToPDFConverter.DocToPDFConverter docToPdfConverter = new Syncfusion.DocToPDFConverter.DocToPDFConverter();
        PdfDocument pdf = docToPdfConverter.ConvertToPDF(wordDocument);
        docToPdfConverter.Dispose();
        wordDocument.Close();
        ((PdfDocumentBase) pdf).Save("Quote/quote-test.pdf");
        ((PdfDocumentBase) pdf).Close(true);
        ((ItemsControl) this.ListViewDataSheet).get_Items().Clear();
        foreach (string enumerateFile in Directory.EnumerateFiles("Quote/"))
        {
          if (string.Compare(Path.GetExtension(enumerateFile), ".pdf", true) == 0)
            ((ItemsControl) this.ListViewDataSheet).get_Items().Add((object) Path.GetFileName(enumerateFile));
        }
      }
      finally
      {
        Mouse.set_OverrideCursor((Cursor) null);
      }
      ((ListBox) this.ListViewDataSheet).UnselectAll();
      this.resultPDFViewer.Load("Quote/quote-test.pdf");
    }

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    internal static extern bool SetProcessWorkingSetSize(
      IntPtr pProcess,
      int dwMinimumWorkingSetSize,
      int dwMaximumWorkingSetSize);

    [DllImport("KERNEL32.DLL", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    internal static extern IntPtr GetCurrentProcess();

    private void More_Click(object sender, RoutedEventArgs e) => new LICENSE().ShowDialog();

    private void MainWindowControl_Unloaded(object sender, RoutedEventArgs e) => MainWindow.SetProcessWorkingSetSize(MainWindow.GetCurrentProcess(), -1, -1);

    private void StandardLaminationSpeed_Loaded(object sender, RoutedEventArgs e) => this.StandardLaminationSpeed.set_Text(MainWindow.process[0].ToString());

    private void StandardLaminationSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.StandardLaminationSpeed.get_Text(), out result);
        MainWindow.process[0] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void StandardLaminationSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void StandardLaminationSpeed_LostFocus(object sender, RoutedEventArgs e) => this.StandardLaminationSpeed.set_Text(MainWindow.process[0].ToString());

    private void SolidLaminationSpeed_Loaded(object sender, RoutedEventArgs e) => this.SolidLaminationSpeed.set_Text(MainWindow.process[1].ToString());

    private void SolidLaminationSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.SolidLaminationSpeed.get_Text(), out result);
        MainWindow.process[1] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void SolidLaminationSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void SolidLaminationSpeed_LostFocus(object sender, RoutedEventArgs e) => this.SolidLaminationSpeed.set_Text(MainWindow.process[1].ToString());

    private void A2LaminationSpeed_Loaded(object sender, RoutedEventArgs e) => this.A2LaminationSpeed.set_Text(MainWindow.process[2].ToString());

    private void A2LaminationSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.A2LaminationSpeed.get_Text(), out result);
        MainWindow.process[2] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void A2LaminationSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void A2LaminationSpeed_LostFocus(object sender, RoutedEventArgs e) => this.A2LaminationSpeed.set_Text(MainWindow.process[2].ToString());

    private void StandardSlittingSpeed_Loaded(object sender, RoutedEventArgs e) => this.StandardSlittingSpeed.set_Text(MainWindow.process[3].ToString());

    private void StandardSlittingSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.StandardSlittingSpeed.get_Text(), out result);
        MainWindow.process[3] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void StandardSlittingSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void StandardSlittingSpeed_LostFocus(object sender, RoutedEventArgs e) => this.StandardSlittingSpeed.set_Text(MainWindow.process[3].ToString());

    private void SolidSlittingSpeed_Loaded(object sender, RoutedEventArgs e) => this.SolidSlittingSpeed.set_Text(MainWindow.process[4].ToString());

    private void SolidSlittingSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.SolidSlittingSpeed.get_Text(), out result);
        MainWindow.process[4] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void SolidSlittingSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void SolidSlittingSpeed_LostFocus(object sender, RoutedEventArgs e) => this.SolidSlittingSpeed.set_Text(MainWindow.process[4].ToString());

    private void A2SlittingSpeed_Loaded(object sender, RoutedEventArgs e) => this.A2SlittingSpeed.set_Text(MainWindow.process[5].ToString());

    private void A2SlittingSpeed_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.A2SlittingSpeed.get_Text(), out result);
        MainWindow.process[5] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void A2SlittingSpeed_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void A2SlittingSpeed_LostFocus(object sender, RoutedEventArgs e) => this.A2SlittingSpeed.set_Text(MainWindow.process[5].ToString());

    private void OperatorValue_Loaded(object sender, RoutedEventArgs e) => this.OperatorValue.set_Text(MainWindow.process[6].ToString());

    private void OperatorValue_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.OperatorValue.get_Text(), out result);
        MainWindow.process[6] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void OperatorValue_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void OperatorValue_LostFocus(object sender, RoutedEventArgs e) => this.OperatorValue.set_Text(MainWindow.process[6].ToString());

    private void SpecializedOperatorValue_Loaded(object sender, RoutedEventArgs e) => this.SpecializedOperatorValue.set_Text(MainWindow.process[7].ToString());

    private void SpecializedOperatorValue_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.SpecializedOperatorValue.get_Text(), out result);
        MainWindow.process[7] = Convert.ToDouble(result);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void SpecializedOperatorValue_PreviewTextInput(
      object sender,
      TextCompositionEventArgs e)
    {
      ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));
    }

    private void SpecializedOperatorValue_LostFocus(object sender, RoutedEventArgs e) => this.SpecializedOperatorValue.set_Text(MainWindow.process[7].ToString());

    private void TransportValue_Loaded(object sender, RoutedEventArgs e) => this.TransportValue.set_Text(MainWindow.process[8].ToString());

    private void TransportValue_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (((FrameworkElement) this).get_IsLoaded())
      {
        double result;
        double.TryParse(this.TransportValue.get_Text(), out result);
        if (result <= 100.0 && result >= 0.0)
          MainWindow.process[8] = Convert.ToDouble(result);
        else
          MessageBox.Show("Percentage must be between [0-100]", "Typing Error", (MessageBoxButton) 0, (MessageBoxImage) 16);
      }
      if (((Selector) this.comboMaterial).get_SelectedIndex() == -1)
        return;
      this.ProcessValueUpdate();
    }

    private void TransportValue_PreviewTextInput(object sender, TextCompositionEventArgs e) => ((RoutedEventArgs) e).set_Handled(!MainWindow.IsTextAllowed(e.get_Text()));

    private void TransportValue_LostFocus(object sender, RoutedEventArgs e) => this.TransportValue.set_Text(MainWindow.process[8].ToString());

    private void CalculationWithSelectedProcess()
    {
      int int32 = Convert.ToInt32((double) this.numberToProduce / this.MOQ);
      bool? isChecked = ((ToggleButton) this.adhesiveYesNo).get_IsChecked();
      bool flag = false;
      if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
      {
        if ((double) this.numberToProduce > this.MOQ)
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ) * int32;
          MainWindow.lamTimeWorked = Math.Round(Math.Floor((double) this.numberToProduce / this.MOQ) * (Convert.ToDouble(MainWindow.material[4]) / MainWindow.selectedProcess[0]), 2);
          MainWindow.lamProcessLabour = Math.Round(MainWindow.lamTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
        }
        else
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ);
          MainWindow.lamTimeWorked = Math.Round(Convert.ToDouble(MainWindow.material[4]) / MainWindow.selectedProcess[0], 2);
          MainWindow.lamProcessLabour = Math.Round(MainWindow.lamTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
        }
        if ((double) this.numberToProduce > this.MOQ)
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ) * int32;
          MainWindow.slitTimeWorked = Math.Round((double) this.numberToProduce / MainWindow.selectedProcess[1] * 60.0, 2);
          MainWindow.slitLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
        }
        else
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ);
          MainWindow.slitTimeWorked = Math.Round((double) this.numberToProduce / MainWindow.selectedProcess[1] * 60.0, 2);
          MainWindow.slitLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
        }
        MainWindow.packagingLabour = Math.Round(15.0 * MainWindow.selectedProcess[2] / 60.0, 2);
        MainWindow.processLabour = Math.Round(MainWindow.packagingLabour * MainWindow.selectedProcess[4], 2);
        MainWindow.totalMaterialPrice = Math.Round((double) this.numberToProduce * Convert.ToDouble(MainWindow.product[2]) / 12.0 * Convert.ToDouble(MainWindow.material[4]) * Convert.ToDouble(MainWindow.material[6]), 2);
        MainWindow.totalAdhesivePrice = Math.Round((double) this.numberToProduce * Convert.ToDouble(MainWindow.product[2]) / 12.0 * Convert.ToDouble(MainWindow.material[4]) * Convert.ToDouble(MainWindow.adhesive[5]), 2);
        MainWindow.bigTotal = MainWindow.totalMaterialPrice + MainWindow.totalAdhesivePrice + MainWindow.slitLabour + MainWindow.lamProcessLabour + MainWindow.packagingLabour;
        MainWindow.pricePerRoll = Math.Round(MainWindow.bigTotal / (double) this.numberToProduce, 2);
        MainWindow.linearPriceperFeet = Math.Round(MainWindow.pricePerRoll / Convert.ToDouble(MainWindow.material[4]), 4);
      }
      else
      {
        if ((double) this.numberToProduce > this.MOQ)
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ) * int32;
          MainWindow.slitTimeWorked = MainWindow.slitTimeWorked = Math.Round((double) this.numberToProduce / MainWindow.selectedProcess[1] * 60.0, 2);
          MainWindow.slitLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
          MainWindow.packagingLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[2] / 60.0, 2);
        }
        else
        {
          this.numberToProduce = Convert.ToInt32(this.MOQ);
          MainWindow.slitTimeWorked = Math.Round((double) this.numberToProduce / MainWindow.selectedProcess[1] * 60.0, 2);
          MainWindow.slitLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[3] / 60.0, 2);
          MainWindow.packagingLabour = Math.Round(MainWindow.slitTimeWorked * MainWindow.selectedProcess[2] / 60.0, 2);
        }
        MainWindow.packagingLabour = Math.Round(15.0 * MainWindow.selectedProcess[2] / 60.0, 2);
        MainWindow.processLabour = Math.Round(MainWindow.packagingLabour * MainWindow.selectedProcess[4], 2);
        MainWindow.totalMaterialPrice = Math.Round((double) this.numberToProduce * Convert.ToDouble(MainWindow.product[2]) / 12.0 * Convert.ToDouble(MainWindow.material[4]) * Convert.ToDouble(MainWindow.material[6]), 2);
        MainWindow.bigTotal = MainWindow.totalMaterialPrice + MainWindow.slitLabour + MainWindow.packagingLabour;
        MainWindow.pricePerRoll = Math.Round(MainWindow.totalMaterialPrice / (double) this.numberToProduce, 2);
        MainWindow.linearPriceperFeet = Math.Round(MainWindow.pricePerRoll / Convert.ToDouble(MainWindow.material[4]), 4);
      }
    }

    public void ProcessValueUpdate()
    {
      MainWindow.selectedProcess = new double[5]
      {
        MainWindow.process[0],
        MainWindow.process[3],
        MainWindow.process[6],
        MainWindow.process[7],
        MainWindow.process[8]
      };
      if (((object) this.materialName).ToString().Contains("D2") || ((object) this.materialName).ToString().Contains("D4"))
        MainWindow.selectedProcess = new double[5]
        {
          MainWindow.process[1],
          MainWindow.process[4],
          MainWindow.process[6],
          MainWindow.process[7],
          MainWindow.process[8]
        };
      if (!((object) this.materialName).ToString().Contains("A2"))
        return;
      MainWindow.selectedProcess = new double[5]
      {
        MainWindow.process[2],
        MainWindow.process[5],
        MainWindow.process[6],
        MainWindow.process[7],
        MainWindow.process[8]
      };
    }

    public void CreatePdfPreview()
    {
      this.CalculationWithSelectedProcess();
      WordDocument wordDocument = new WordDocument("template/estimation-template.docx", (FormatType) 2);
      wordDocument.Find("$Date", false, true).GetAsOneRange().set_Text(DateTime.Now.Date.ToString("yyyy/MM/dd"));
      wordDocument.Find("$UserName", false, true).GetAsOneRange().set_Text(((ContentControl) this.User).get_Content().ToString());
      wordDocument.Find("$MATERIELNOMADHESIVENAME", false, true).GetAsOneRange().set_Text(this.finalName.get_Text());
      wordDocument.Find("$Vendeur", false, true).GetAsOneRange().set_Text(this.combobox_sales_rep.get_Text());
      string[] strArray1 = new string[6]
      {
        "$Matricule",
        "$Entreprise",
        "$Adresse",
        "$eMail",
        "$Secteur",
        "$Nom"
      };
      object[] objArray1 = new object[6]
      {
        ((ContentControl) this.companyMatricule).get_Content(),
        ((ContentControl) this.companyName).get_Content(),
        ((ContentControl) this.companyAddress).get_Content(),
        ((ContentControl) this.companyEmail).get_Content(),
        ((ContentControl) this.companySector).get_Content(),
        ((ContentControl) this.companyContact).get_Content()
      };
      for (int index = 0; index <= 5; ++index)
        wordDocument.Find(strArray1[index], false, true).GetAsOneRange().set_Text(objArray1[index].ToString());
      string[] strArray2 = new string[7]
      {
        "$MaterielItem",
        "$MaterielNom",
        "$MaterielEpaisseur",
        "$MaterielLargeur",
        "$MaterielLongueur",
        "$MaterielFournisseur",
        "$MaterielPrix"
      };
      for (int index = 0; index <= 6; ++index)
        wordDocument.Find(strArray2[index], false, true).GetAsOneRange().set_Text(MainWindow.material[index].ToString());
      string[] strArray3 = new string[6]
      {
        "$AdhesifItem",
        "$AdhesifName",
        "$AdhesifLargeur",
        "$AdhesifLongueur",
        "$AdhesifFournisseur",
        "$AdhesifPrix"
      };
      for (int index = 0; index <= 5; ++index)
        wordDocument.Find(strArray3[index], false, true).GetAsOneRange().set_Text(MainWindow.adhesive[index].ToString());
      string[] strArray4 = new string[3]
      {
        "$ProductLongueur",
        "$ProductEpaisseur",
        "$ProductLargeur"
      };
      for (int index = 0; index <= 2; ++index)
        wordDocument.Find(strArray4[index], false, true).GetAsOneRange().set_Text(MainWindow.product[index].ToString());
      wordDocument.Find("$SelectedProduct", false, true).GetAsOneRange().set_Text(((Selector) this.comboProduct).get_SelectedItem().ToString());
      wordDocument.Find("$MOQ", false, true).GetAsOneRange().set_Text(this.MOQ.ToString());
      wordDocument.Find("$Notes", false, true).GetAsOneRange().set_Text(this.productNotes.get_Text());
      wordDocument.Find("$Qty", false, true).GetAsOneRange().set_Text(this.productQuantity.get_Text());
      wordDocument.Find("$NumberToProduce", false, true).GetAsOneRange().set_Text(this.numberToProduce.ToString());
      wordDocument.Find("$TotalMateriel", false, true).GetAsOneRange().set_Text(MainWindow.totalMaterialPrice.ToString());
      wordDocument.Find("$TotalAdhesif", false, true).GetAsOneRange().set_Text(MainWindow.totalAdhesivePrice.ToString());
      wordDocument.Find("$TotalProduit", false, true).GetAsOneRange().set_Text(MainWindow.bigTotal.ToString());
      wordDocument.Find("$PrixParRlx", false, true).GetAsOneRange().set_Text(MainWindow.pricePerRoll.ToString());
      wordDocument.Find("$PrixPiedLineaire", false, true).GetAsOneRange().set_Text(MainWindow.linearPriceperFeet.ToString());
      string[] strArray5 = new string[7]
      {
        "$LamCadence",
        "$LamLabour",
        "$LamTime",
        "$SlitCadence",
        "$SlitLabour",
        "$SlitTime",
        "$PackLabour"
      };
      object[] objArray2 = new object[7]
      {
        (object) MainWindow.selectedProcess[0],
        (object) MainWindow.lamProcessLabour,
        (object) MainWindow.lamTimeWorked,
        (object) MainWindow.selectedProcess[1],
        (object) MainWindow.slitLabour,
        (object) MainWindow.slitTimeWorked,
        (object) MainWindow.packagingLabour
      };
      for (int index = 0; index < strArray5.Length; ++index)
        wordDocument.Find(strArray5[index], false, true).GetAsOneRange().set_Text(objArray2[index].ToString());
      Syncfusion.DocToPDFConverter.DocToPDFConverter docToPdfConverter = new Syncfusion.DocToPDFConverter.DocToPDFConverter();
      PdfDocument pdf = docToPdfConverter.ConvertToPDF(wordDocument);
      docToPdfConverter.Dispose();
      wordDocument.Close();
      ((PdfDocumentBase) pdf).Save("Quote/quote-test.pdf");
      ((PdfDocumentBase) pdf).Close(true);
      this.resultPDFViewer.Load("Quote/quote-test.pdf");
      ((ItemsControl) this.ListViewDataSheet).get_Items().Clear();
      foreach (string enumerateFile in Directory.EnumerateFiles("Quote/"))
      {
        if (string.Compare(Path.GetExtension(enumerateFile), ".pdf", true) == 0)
          ((ItemsControl) this.ListViewDataSheet).get_Items().Add((object) Path.GetFileName(enumerateFile));
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Addev Profom Estimator;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.MainWindowControl = (MainWindow) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.MainWindowControl).add_Loaded(new RoutedEventHandler((object) this, __methodptr(Window_Loaded)));
          // ISSUE: method pointer
          ((FrameworkElement) this.MainWindowControl).add_Unloaded(new RoutedEventHandler((object) this, __methodptr(MainWindowControl_Unloaded)));
          break;
        case 2:
          this.dockPanel1 = (DockPanel) target;
          break;
        case 3:
          this.User = (Label) target;
          break;
        case 4:
          // ISSUE: method pointer
          ((UIElement) target).add_MouseMove(new MouseEventHandler((object) this, __methodptr(Menu_MouseMove)));
          // ISSUE: method pointer
          ((Control) target).add_MouseDoubleClick(new MouseButtonEventHandler((object) this, __methodptr(Menu_MouseDoubleClick)));
          break;
        case 5:
          this.CloseImage = (Image) target;
          // ISSUE: method pointer
          ((UIElement) this.CloseImage).add_MouseDown(new MouseButtonEventHandler((object) this, __methodptr(CloseImage_MouseDown)));
          break;
        case 6:
          this.MaximizeImage = (Image) target;
          // ISSUE: method pointer
          ((UIElement) this.MaximizeImage).add_MouseDown(new MouseButtonEventHandler((object) this, __methodptr(MaximizeImage_MouseDown)));
          break;
        case 7:
          this.MinimizeImage = (Image) target;
          // ISSUE: method pointer
          ((UIElement) this.MinimizeImage).add_MouseDown(new MouseButtonEventHandler((object) this, __methodptr(MinimizeImage_MouseDown)));
          break;
        case 8:
          this.newMenuQuote = (MenuItem) target;
          // ISSUE: method pointer
          this.newMenuQuote.add_Click(new RoutedEventHandler((object) this, __methodptr(NewMenuQuote_Click)));
          break;
        case 9:
          this.Open = (MenuItem) target;
          // ISSUE: method pointer
          this.Open.add_Click(new RoutedEventHandler((object) this, __methodptr(Open_Click)));
          break;
        case 10:
          this.Exit = (MenuItem) target;
          // ISSUE: method pointer
          this.Exit.add_Click(new RoutedEventHandler((object) this, __methodptr(Exit_Click)));
          break;
        case 11:
          this.CalendarVisible = (MenuItem) target;
          // ISSUE: method pointer
          this.CalendarVisible.add_Click(new RoutedEventHandler((object) this, __methodptr(CalendarVisible_Click)));
          break;
        case 12:
          this.data = (MenuItem) target;
          // ISSUE: method pointer
          this.data.add_Click(new RoutedEventHandler((object) this, __methodptr(Data_Click)));
          break;
        case 13:
          this.settingsManager = (MenuItem) target;
          break;
        case 14:
          this.aboutTheApp = (MenuItem) target;
          break;
        case 15:
          // ISSUE: method pointer
          ((MenuItem) target).add_Click(new RoutedEventHandler((object) this, __methodptr(More_Click)));
          break;
        case 16:
          this.calendarSyncfusion = (CalendarEdit) target;
          break;
        case 17:
          this.ListViewDataSheet = (ListView) target;
          // ISSUE: method pointer
          ((Selector) this.ListViewDataSheet).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(ListViewDataSheet_SelectionChanged)));
          break;
        case 18:
          this.treeView = (TreeView) target;
          // ISSUE: method pointer
          this.treeView.add_SelectedItemChanged(new RoutedPropertyChangedEventHandler<object>((object) this, __methodptr(TreeView_SelectedItemChanged)));
          break;
        case 19:
          this.stackPanel1 = (DockPanel) target;
          break;
        case 20:
          this.rightDataTabItem = (TabControl) target;
          // ISSUE: method pointer
          ((UIElement) this.rightDataTabItem).add_GotFocus(new RoutedEventHandler((object) this, __methodptr(TabControl_GotFocus)));
          break;
        case 21:
          this.cusTab = (TabItem) target;
          break;
        case 22:
          this.ListViewCustomers = (ListView) target;
          break;
        case 23:
          this.matTab = (TabItem) target;
          break;
        case 24:
          this.ListViewMaterials = (ListView) target;
          break;
        case 25:
          this.adTab = (TabItem) target;
          break;
        case 26:
          this.ListViewAdhesive = (ListView) target;
          break;
        case 27:
          this.stackPanel2 = (DockPanel) target;
          break;
        case 28:
          this.userLogin = (TabControl) target;
          // ISSUE: method pointer
          ((Selector) this.userLogin).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(UserLogin_SelectionChanged)));
          break;
        case 29:
          this.UserTab = (TabItem) target;
          break;
        case 30:
          this.NewQuote = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.NewQuote).add_Click(new RoutedEventHandler((object) this, __methodptr(NewQuote_Click)));
          break;
        case 31:
          this.customerTab = (TabItem) target;
          break;
        case 32:
          this.comboboxCustomer = (ComboBoxAdv) target;
          // ISSUE: method pointer
          ((Selector) this.comboboxCustomer).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(ComboboxCustomer_SelectionChanged)));
          break;
        case 33:
          this.addressText = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.addressText).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(AddressText_TextChanged)));
          break;
        case 34:
          this.matriculeText = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.matriculeText).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(MatriculeText_TextChanged)));
          break;
        case 35:
          this.contactNameText = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.contactNameText).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(ContactNameText_TextChanged)));
          break;
        case 36:
          this.combobox_sales_rep = (ComboBoxAdv) target;
          // ISSUE: method pointer
          ((Selector) this.combobox_sales_rep).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(Combobox_sales_rep_SelectionChanged)));
          break;
        case 37:
          this.emailText = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.emailText).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(EmailText_TextChanged)));
          break;
        case 38:
          this.sectorText = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.sectorText).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(SectorText_TextChanged)));
          break;
        case 39:
          this.cancelNewQuote = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.cancelNewQuote).add_Click(new RoutedEventHandler((object) this, __methodptr(CancelNewQuote_Click)));
          break;
        case 40:
          this.CustomerToMaterial = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.CustomerToMaterial).add_Click(new RoutedEventHandler((object) this, __methodptr(CustomerToMaterial_Click)));
          break;
        case 41:
          this.delete_allCustomers = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.delete_allCustomers).add_Click(new RoutedEventHandler((object) this, __methodptr(Delete_allCustomers_Click)));
          break;
        case 42:
          this.materialTab = (TabItem) target;
          break;
        case 43:
          this.PreviousMaterialToCustomer = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.PreviousMaterialToCustomer).add_Click(new RoutedEventHandler((object) this, __methodptr(PreviousMaterialToCustomer_Click)));
          break;
        case 44:
          this.MaterialToAdhesiveTab = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.MaterialToAdhesiveTab).add_Click(new RoutedEventHandler((object) this, __methodptr(MaterialToAdhesiveTab_Click)));
          break;
        case 45:
          this.materialWidth = (Label) target;
          break;
        case 46:
          this.materialLength = (Label) target;
          break;
        case 47:
          this.materialThickness = (Label) target;
          break;
        case 48:
          this.materialPrice = (Label) target;
          break;
        case 49:
          this.materialItemCode = (Label) target;
          break;
        case 50:
          this.materialName = (Label) target;
          break;
        case 51:
          this.materialQty = (Label) target;
          break;
        case 52:
          this.todaysdate = (Label) target;
          break;
        case 53:
          this.adhesiveQty = (Label) target;
          break;
        case 54:
          this.customerQty = (Label) target;
          break;
        case 55:
          this.comboMaterial = (ComboBoxAdv) target;
          // ISSUE: method pointer
          ((Selector) this.comboMaterial).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(ComboMaterial_SelectionChanged)));
          break;
        case 56:
          this.materialSupplier = (TextBlock) target;
          break;
        case 57:
          this.adhesiveTab = (TabItem) target;
          break;
        case 58:
          this.comboAdhesive = (ComboBoxAdv) target;
          // ISSUE: method pointer
          ((Selector) this.comboAdhesive).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(ComboAdhesive_SelectionChanged)));
          break;
        case 59:
          this.adhesiveYesNo = (CheckBox) target;
          ((FrameworkElement) this.adhesiveYesNo).add_Initialized(new EventHandler(this.AdhesiveYesNo_Initialized));
          // ISSUE: method pointer
          ((ToggleButton) this.adhesiveYesNo).add_Checked(new RoutedEventHandler((object) this, __methodptr(AdhesiveYesNo_Checked)));
          // ISSUE: method pointer
          ((ToggleButton) this.adhesiveYesNo).add_Unchecked(new RoutedEventHandler((object) this, __methodptr(AdhesiveYesNo_Unchecked)));
          break;
        case 60:
          this.adhesiveWidth = (Label) target;
          break;
        case 61:
          this.adhesiveLength = (Label) target;
          break;
        case 62:
          this.adhesivePrice = (Label) target;
          break;
        case 63:
          this.adhesiveSupplier = (TextBlock) target;
          break;
        case 64:
          this.adhesiveItemCode = (Label) target;
          break;
        case 65:
          this.adhesiveName = (Label) target;
          break;
        case 66:
          this.PreviousAdhesiveToMaterial = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.PreviousAdhesiveToMaterial).add_Click(new RoutedEventHandler((object) this, __methodptr(PreviousAdhesiveToMaterial_Click)));
          break;
        case 67:
          this.AdhesiveProductTab = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.AdhesiveProductTab).add_Click(new RoutedEventHandler((object) this, __methodptr(AdhesiveProductTab_Click)));
          break;
        case 68:
          this.productTab = (TabItem) target;
          break;
        case 69:
          this.finalName = (TextBlock) target;
          break;
        case 70:
          this.comboProduct = (ComboBoxAdv) target;
          // ISSUE: method pointer
          ((Selector) this.comboProduct).add_SelectionChanged(new SelectionChangedEventHandler((object) this, __methodptr(ComboProduct_SelectionChanged)));
          break;
        case 71:
          this.productWidth = (TextBox) target;
          // ISSUE: method pointer
          ((UIElement) this.productWidth).AddHandler((RoutedEvent) DataObject.PastingEvent, (Delegate) new DataObjectPastingEventHandler((object) this, __methodptr(CustomerWidth_TextBoxPasting)));
          // ISSUE: method pointer
          ((UIElement) this.productWidth).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(CustomerWidth_PreviewTextInput)));
          // ISSUE: method pointer
          ((TextBoxBase) this.productWidth).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(ProductWidth_TextChanged)));
          break;
        case 72:
          this.productNotes = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.productNotes).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(ProductNotes_TextChanged)));
          break;
        case 73:
          this.productQuantity = (TextBox) target;
          // ISSUE: method pointer
          ((UIElement) this.productQuantity).AddHandler((RoutedEvent) DataObject.PastingEvent, (Delegate) new DataObjectPastingEventHandler((object) this, __methodptr(CustomerQuantity_TextBoxPasting)));
          // ISSUE: method pointer
          ((UIElement) this.productQuantity).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(CustomerQuantity_PreviewTextInput)));
          // ISSUE: method pointer
          ((TextBoxBase) this.productQuantity).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(ProductQuantity_TextChanged)));
          break;
        case 74:
          this.customerProductLength = (Label) target;
          break;
        case 75:
          this.customerProductThickness = (Label) target;
          break;
        case 76:
          this.PreviousProductToAdhesive = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.PreviousProductToAdhesive).add_Click(new RoutedEventHandler((object) this, __methodptr(PreviousProductToAdhesive_Click)));
          break;
        case 77:
          this.validateCalculation = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.validateCalculation).add_Click(new RoutedEventHandler((object) this, __methodptr(ValidateCalculation_Click)));
          break;
        case 78:
          this.CancelAll = (Button) target;
          // ISSUE: method pointer
          ((ButtonBase) this.CancelAll).add_Click(new RoutedEventHandler((object) this, __methodptr(CancelAll_Click)));
          break;
        case 79:
          this.DataProcess = (Grid) target;
          break;
        case 80:
          this.StandardLaminationSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.StandardLaminationSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(StandardLaminationSpeed_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.StandardLaminationSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(StandardLaminationSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.StandardLaminationSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(StandardLaminationSpeed_PreviewTextInput)));
          // ISSUE: method pointer
          ((UIElement) this.StandardLaminationSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(StandardLaminationSpeed_LostFocus)));
          break;
        case 81:
          this.SolidLaminationSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((TextBoxBase) this.SolidLaminationSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(SolidLaminationSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.SolidLaminationSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(SolidLaminationSpeed_PreviewTextInput)));
          // ISSUE: method pointer
          ((UIElement) this.SolidLaminationSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(SolidLaminationSpeed_LostFocus)));
          // ISSUE: method pointer
          ((FrameworkElement) this.SolidLaminationSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(SolidLaminationSpeed_Loaded)));
          break;
        case 82:
          this.A2LaminationSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((UIElement) this.A2LaminationSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(A2LaminationSpeed_LostFocus)));
          // ISSUE: method pointer
          ((FrameworkElement) this.A2LaminationSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(A2LaminationSpeed_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.A2LaminationSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(A2LaminationSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.A2LaminationSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(A2LaminationSpeed_PreviewTextInput)));
          break;
        case 83:
          this.StandardSlittingSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.StandardSlittingSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(StandardSlittingSpeed_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.StandardSlittingSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(StandardSlittingSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.StandardSlittingSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(StandardSlittingSpeed_PreviewTextInput)));
          // ISSUE: method pointer
          ((UIElement) this.StandardSlittingSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(StandardSlittingSpeed_LostFocus)));
          break;
        case 84:
          this.SolidSlittingSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.SolidSlittingSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(SolidSlittingSpeed_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.SolidSlittingSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(SolidSlittingSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.SolidSlittingSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(SolidSlittingSpeed_PreviewTextInput)));
          // ISSUE: method pointer
          ((UIElement) this.SolidSlittingSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(SolidSlittingSpeed_LostFocus)));
          break;
        case 85:
          this.A2SlittingSpeed = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.A2SlittingSpeed).add_Loaded(new RoutedEventHandler((object) this, __methodptr(A2SlittingSpeed_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.A2SlittingSpeed).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(A2SlittingSpeed_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.A2SlittingSpeed).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(A2SlittingSpeed_PreviewTextInput)));
          // ISSUE: method pointer
          ((UIElement) this.A2SlittingSpeed).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(A2SlittingSpeed_LostFocus)));
          break;
        case 86:
          this.OperatorValue = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.OperatorValue).add_Loaded(new RoutedEventHandler((object) this, __methodptr(OperatorValue_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.OperatorValue).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(OperatorValue_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.OperatorValue).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(OperatorValue_LostFocus)));
          // ISSUE: method pointer
          ((UIElement) this.OperatorValue).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(OperatorValue_PreviewTextInput)));
          break;
        case 87:
          this.SpecializedOperatorValue = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.SpecializedOperatorValue).add_Loaded(new RoutedEventHandler((object) this, __methodptr(SpecializedOperatorValue_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.SpecializedOperatorValue).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(SpecializedOperatorValue_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.SpecializedOperatorValue).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(SpecializedOperatorValue_LostFocus)));
          // ISSUE: method pointer
          ((UIElement) this.SpecializedOperatorValue).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(SpecializedOperatorValue_PreviewTextInput)));
          break;
        case 88:
          this.TransportValue = (TextBox) target;
          // ISSUE: method pointer
          ((FrameworkElement) this.TransportValue).add_Loaded(new RoutedEventHandler((object) this, __methodptr(TransportValue_Loaded)));
          // ISSUE: method pointer
          ((TextBoxBase) this.TransportValue).add_TextChanged(new TextChangedEventHandler((object) this, __methodptr(TransportValue_TextChanged)));
          // ISSUE: method pointer
          ((UIElement) this.TransportValue).add_LostFocus(new RoutedEventHandler((object) this, __methodptr(TransportValue_LostFocus)));
          // ISSUE: method pointer
          ((UIElement) this.TransportValue).add_PreviewTextInput(new TextCompositionEventHandler((object) this, __methodptr(TransportValue_PreviewTextInput)));
          break;
        case 89:
          this.resultPDFViewer = (PdfViewerControl) target;
          break;
        case 90:
          this.companyName = (Label) target;
          break;
        case 91:
          this.companyAddress = (Label) target;
          break;
        case 92:
          this.companyMatricule = (Label) target;
          break;
        case 93:
          this.companyContact = (Label) target;
          break;
        case 94:
          this.companyEmail = (Label) target;
          break;
        case 95:
          this.labelSales_Rep = (Label) target;
          break;
        case 96:
          this.companySector = (Label) target;
          break;
        case 97:
          this.materialWidth1 = (Label) target;
          break;
        case 98:
          this.materialLength1 = (Label) target;
          break;
        case 99:
          this.materialThickness1 = (Label) target;
          break;
        case 100:
          this.materialPrice1 = (Label) target;
          break;
        case 101:
          this.materialSupplier1 = (Label) target;
          break;
        case 102:
          this.materialItemCode1 = (Label) target;
          break;
        case 103:
          this.materialName1 = (Label) target;
          break;
        case 104:
          this.adhesiveWidth1 = (Label) target;
          break;
        case 105:
          this.adhesiveLength1 = (Label) target;
          break;
        case 106:
          this.adhesivePrice1 = (Label) target;
          break;
        case 107:
          this.adhesiveSupplier1 = (Label) target;
          break;
        case 108:
          this.adhesiveItemCode1 = (Label) target;
          break;
        case 109:
          this.adhesiveName1 = (Label) target;
          break;
        case 110:
          this.productName1 = (Label) target;
          break;
        case 111:
          this.productWidht1 = (Label) target;
          break;
        case 112:
          this.productLength1 = (Label) target;
          break;
        case 113:
          this.productThickness1 = (Label) target;
          break;
        case 114:
          this.productQuantity1 = (Label) target;
          break;
        case 115:
          this.productPrice1 = (Label) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    public static class GlobalPath
    {
      public static string myPath = "";
    }

    public static class GlobalSecondPath
    {
      public static string mySecondPath = "";
    }

    public class CustomerDetails
    {
      public string CustomerID { get; set; }

      public string CustomerName { get; set; }

      public string CustomerAddress { get; set; }

      public string CustomerEmail { get; set; }

      public string CustomerSector { get; set; }

      public string CustomerContact { get; set; }

      public CustomerDetails(
        string customerID,
        string customerName,
        string customerAddress,
        string customerEmail,
        string customerSector,
        string customerContact)
      {
        this.CustomerID = customerID;
        this.CustomerName = customerName;
        this.CustomerAddress = customerAddress;
        this.CustomerEmail = customerEmail;
        this.CustomerSector = customerSector;
        this.CustomerContact = customerContact;
      }
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

      public MaterialDetails(
        string materialID,
        string materialName,
        string materialThickness,
        string materialWidth,
        string materialLength,
        string materialSupplier,
        string materialPrice)
      {
        this.MaterialID = materialID;
        this.MaterialName = materialName;
        this.MaterialThickness = materialThickness;
        this.MaterialWidth = materialWidth;
        this.MaterialLength = materialLength;
        this.MaterialSupplier = materialSupplier;
        this.MaterialPrice = materialPrice;
      }
    }

    public class AdhesiveDetails
    {
      public string AdhesiveID { get; set; }

      public string AdhesiveName { get; set; }

      public string AdhesiveWidth { get; set; }

      public string AdhesiveLength { get; set; }

      public string AdhesiveSupplier { get; set; }

      public string AdhesivePrice { get; set; }

      public AdhesiveDetails(
        string adhesiveID,
        string adhesiveName,
        string adhesiveWidth,
        string adhesiveLength,
        string adhesiveSupplier,
        string adhesivePrice)
      {
        this.AdhesiveID = adhesiveID;
        this.AdhesiveName = adhesiveName;
        this.AdhesiveWidth = adhesiveWidth;
        this.AdhesiveLength = adhesiveLength;
        this.AdhesiveSupplier = adhesiveSupplier;
        this.AdhesivePrice = adhesivePrice;
      }
    }

    public class ProcessSpecs
    {
      public string StandardLaminationType { get; set; }

      public string SolidLaminationType { get; set; }

      public string A2LaminationType { get; set; }

      public int StandardSlittingValue { get; set; }

      public int A2SlittingValue { get; set; }

      public string OperatorPacking { get; set; }

      public string SpecializedOperatorPacking { get; set; }

      public string TransportPacking { get; set; }

      public string FeetMinUnit { get; set; }

      public string RollsPerHour { get; set; }

      public string DollarsPerHour { get; set; }

      public string PercentageTransport { get; set; }

      public static MainWindow.ProcessSpecs GetProcess() => new MainWindow.ProcessSpecs()
      {
        StandardLaminationType = "Standard",
        SolidLaminationType = " Solid ",
        A2LaminationType = " A2 ",
        OperatorPacking = "Standard Operator",
        SpecializedOperatorPacking = "Specialized Operator",
        TransportPacking = "Transport %",
        FeetMinUnit = "ft/min",
        RollsPerHour = "rll/hr",
        DollarsPerHour = "$/hr",
        PercentageTransport = "%"
      };
    }
  }
}
