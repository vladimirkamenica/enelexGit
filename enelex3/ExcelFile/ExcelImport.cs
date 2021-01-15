using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using enelex3.Helpers;

namespace enelex3.ExcelFile
{
    public static class ExcelImport
    {
        public static Tuple<DataTableCollection, string> FillExcelImport(bool view)
        {
            try
            {

           
          
            List<string> skipColumns = new List<string> { "Vlaga", "Pepeo" };
            DataTableCollection TableCollection = null;
            string NameFileTxt = "";
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" };
            if (openFileDialog.ShowDialog() == true)
            {
                NameFileTxt = openFileDialog.FileName;
             
                using (var steam = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader;
                    reader = ExcelReaderFactory.CreateReader(steam);
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true,
                        }
                    };
                    var conf2 = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true,

                            ReadHeaderRow = rowReader => {
                                rowReader.Read();

                            }
                        }
                    };
                    DataSet result;
                    if(view) result = reader.AsDataSet(conf);
                    else result = reader.AsDataSet(conf2);




                    TableCollection = result.Tables;
                        
                    
                }
            }

            return new Tuple<DataTableCollection, string>(TableCollection, NameFileTxt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Tuple<DataTableCollection, string>(null, null);
            }
        }
        public static ObservableCollection<string> SheetName(ObservableCollection<string> name, DataTableCollection table)
        {
            name = new ObservableCollection<string>();
            name.Clear();
            if(table != null)
            {
                foreach (DataTable x in table)
                {
                    name.Add(x.TableName);
                }
                return name;
            }
            return null;
        }
    }
}
