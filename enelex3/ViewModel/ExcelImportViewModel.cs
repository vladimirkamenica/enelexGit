using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.ViewModel;
using enelex3.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.IO;
using ExcelDataReader;
using System.Data;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace enelex3.ViewModel
{
    public class ExcelImportViewModel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        private Action Load { get; set; }
        public ExcelImportViewModel(Action load)
        {
            Load = load;
        }
        private ObservableCollection<string> nameSheetTxt { get; set; }
        public ObservableCollection<string> NameSheetTxt
        {
            get => nameSheetTxt;
            set
            {
                if (nameSheetTxt != value)
                {
                    nameSheetTxt = value;
                    OnPropertyChanged(nameof(NameSheetTxt));
                }
            }
        }
        private string selectedSheetFileTxt { get; set; }
        public string SelectedSheetFileTxt
        {
            get => selectedSheetFileTxt;
            set
            {
                if (selectedSheetFileTxt != value)
                {
                    selectedSheetFileTxt = value;
                    LoadExcel();
                    OnPropertyChanged(nameof(SelectedSheetFileTxt));
                }
            }
        }
        private string nameFileTxt { get; set; }
        public string NameFileTxt
        {
            get => nameFileTxt;
            set
            {
                if (nameFileTxt != value)
                {
                    nameFileTxt = value;
                  
                    OnPropertyChanged(nameof(NameFileTxt));
                }
            }
        }
        private DataTable tableExcelFile { get; set; }
        public DataTable TableExcelFile
        {
            get => tableExcelFile;
            set
            {
                if(tableExcelFile != value)
                {
                    tableExcelFile = value;
                    OnPropertyChanged(nameof(TableExcelFile));
                }
            }
        }
        private ObservableCollection<ImportClassView> getImportMeasure { get; set; }

        public ObservableCollection<ImportClassView> GetImportMeasure
        {
            get => getImportMeasure;
            set
            {
                if (getImportMeasure != value)
                {
                    getImportMeasure = value;
                    OnPropertyChanged(nameof(GetImportMeasure));
                }
            }
        }
        private DataTableCollection tableCollection;
        public DataTableCollection TableCollection
        {
            get => tableCollection;
            set
            {
                if(tableCollection != value)
                {
                    tableCollection = value;
                    OnPropertyChanged(nameof(TableCollection));
                }
            }
        }
        public ICommand OpenCommand => new RelayCommand(ExcelImport);
        private void ExcelImport()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" };
           
        
            if (openFileDialog.ShowDialog() == true)
            {
                NameFileTxt = openFileDialog.FileName;
                using (var steam = File.Open(openFileDialog.FileName,FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(steam))
                    {
                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true}
                            });

                        TableCollection = result.Tables;
                        NameSheetTxt = new ObservableCollection<string>();
                        NameSheetTxt.Clear();
                       foreach (DataTable x in TableCollection)
                        {
                            NameSheetTxt.Add(x.TableName) ;
                        }
                    }
                }
            }


        }

        private void LoadExcel()
        {
          
                TableExcelFile = TableCollection[SelectedSheetFileTxt];
                if (TableExcelFile != null)
                {
                  
                    GetImportMeasure = new ObservableCollection<ImportClassView>();
                    GetImportMeasure.Clear();
                    for (int i = 0; i < TableExcelFile.Rows.Count; i++)
                    {
                    ImportClassView views = new ImportClassView();
                    if (TableExcelFile.Rows[i]["Pepeo x [GE]"].ToString() != string.Empty)
                        {
                            views.Ge = double.Parse(TableExcelFile.Rows[i]["Pepeo x [GE]"].ToString());
                        }
                        else
                        {
                            views.Ge = 0;
                        }
                       if(TableExcelFile.Rows[i]["Pepeo y [LAB]"].ToString() != string.Empty)
                        {
                            views.Lab = double.Parse(TableExcelFile.Rows[i]["Pepeo y [LAB]"].ToString());
                        }
                       else
                        {
                            views.Lab = 0;
                        }
                       if(TableExcelFile.Rows[i]["Vlaga [W]"].ToString() != string.Empty)
                        {
                            views.W = double.Parse(TableExcelFile.Rows[i]["Vlaga [W]"].ToString());
                        }
                      else
                       {
                           views.W = 0;
                       }
                     
                        GetImportMeasure.Add(views);

                    }
                }
            
           
           
        }
        public ICommand ImportCommand => new RelayCommand(ItemsExcel);
        private void ItemsExcel()
        {
            Measure measure = new Measure();
            foreach (var x in GetImportMeasure)
            {
                if(x != null)
                {
                    measure.Ge = x.Ge;
                    measure.Lab = x.Lab;
                    measure.W = x.W;
                    if (measure != null)
                    {
                        db.Measures.Add(measure);
                        db.SaveChanges();
                       
                    }
                }
            }
            Load?.Invoke();
            MessageBox.Show("Import završen");
        }
        public ICommand GetIndexCommand => new RelayCommand<DataGridRowEventArgs>(GetIndex);
        private void GetIndex(DataGridRowEventArgs e)
        {
            var x = e.Row.DataContext as ImportClassView;
            if(x != null)
            {
                x.Index = e.Row.GetIndex() + 1;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
