using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using enelex3.Helpers.Excel;

namespace enelex3.ExcelEx
{
    public  class MyExcelEx
    {
        private static IBuilderObjects builderObjects;
        private static ExcelActionsCommandGenerator excelActionsCommandGenerator;
        private static IItemsSourceItems itemsSourceInserts;
        static MyExcelEx()
        {
            builderObjects = new BuilderObjects();
            itemsSourceInserts = new ItemsSourceIntems(builderObjects);
        }
        public static readonly  DependencyProperty EnabledPasteExcelProperty =
          DependencyProperty.RegisterAttached("EnabledPasteExcel", typeof(bool), typeof(MyExcelEx), new PropertyMetadata(false, OnEnabledPasteExcelChanged));

        private static void OnEnabledPasteExcelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (GetEnabledPasteExcel(d) == false) return;

            var frameworkElement = d as FrameworkElement;
            //frameworkElement.InputBindings.Add(
            //     new KeyBinding { Key = Key.V, Modifiers = ModifierKeys.Control, Command = commands.PasteCommand }
            // );
        }
        private static ExcelActionsCommandInfo CreateCommands(DependencyObject d)
        {
          

            var result = excelActionsCommandGenerator.GenerateCommands(d);

            return result;
        }

        public static bool GetEnabledPasteExcel(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledPasteExcelProperty);
        }
        //private ICommand pasteCommand = new RelayCommands(paste1);
        //private void paste1()
        //{

        //}
        //public  ExcelActionsCommandInfo GenerateCommands(DependencyObject d)
        //{
           
        //    //ICommand pasteCommand = new RelayCommands(ActionWithAnimation(a => itemsSourceInserts.Insert(d,
        //    //                                                                       Clipboard.GetText(),
        //    //                                                                       ExcelActions.GetShowErrorMessages(d),
        //    //                                                                       ExcelActions.GetCancelWithErrors(d)), d),
        //    //                                                                a => Clipboard.ContainsText());

        //    var result = new ExcelActionsCommandInfo {PasteCommand = pasteCommand };

        //    return result;
        //}
     
    }
}
