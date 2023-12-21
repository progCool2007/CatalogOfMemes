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

namespace CatalogOfMemes
{
    /// <summary>
    /// Логика взаимодействия для SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        private CatalogFunctions catalogFunctions;
        public SaveWindow()
        {
            InitializeComponent();
            catalogFunctions = new CatalogFunctions();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            catalogFunctions.SaveJoke(tbName, tbURL, cb_category);
        }
    }
}
