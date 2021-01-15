using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace enelex3.Helpers
{
    public static class MessageBoxHelp
    {
        public static void MessageBoxNoUser()
        {
            MessageBox.Show("Samo administrator može prostupiti podacima");
        }
        public static void MessageBoxError()
        {
            MessageBox.Show("Greška u podacima");
        }
        public static void MessageBoxErrorLogIn()
        {
            MessageBox.Show("Pogrešno korisničko ime ili šifra");
        }
        public static bool MessageBoxYesOrNO()
        {
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni", "Evidencija", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return true;
                case MessageBoxResult.No:
                    return false;
                default:
                    return false;
            }
        }
    }
}
