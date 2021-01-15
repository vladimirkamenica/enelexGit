using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using enelex3.View;

namespace enelex3.Commands
{
   public class CommonCommands
    {
        public ICommand IsNewItemCommand => new RelayCommand<DataGridRowEventArgs>(BillOfMaterialsIndex);
        private void BillOfMaterialsIndex(DataGridRowEventArgs e)
        {
            var x = e.Row.DataContext as TrainTableView;
            if (x != null)
            {
                x.IsNewItem = e.Row.IsNewItem;

                if(x.IsNewItem)
                {
                    x.DateRecords = DateTime.Now;
                        
                }
              
            }
            
        }
    }
}
