﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace enelex3.Helpers.Excel
{
    internal interface IItemsSourceItems
    {
        void Insert(DependencyObject d, string dataStr, bool showErrorMessages, bool cancelWithErrors);
     //   void Insert(DependencyObject d, string v);
    }
}
