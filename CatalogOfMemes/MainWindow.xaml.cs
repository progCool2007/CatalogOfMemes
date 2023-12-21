using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CatalogOfMemes
{
    public partial class MainWindow : Window
    {
        private CatalogFunctions catalogFunctions;
        private SaveWindow saveWindow;
        public MainWindow()
        {
            InitializeComponent();
            catalogFunctions = new CatalogFunctions();
            catalogFunctions.LoadJokes();
            catalogFunctions.UpdateJokeList(lb_joke);
        }
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            saveWindow = new SaveWindow();
            saveWindow.Show();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            catalogFunctions.DeleteJoke(lb_joke);
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            catalogFunctions.LoadJokes();
            catalogFunctions.UpdateJokeList(lb_joke);
        }

        private void ListBoxMem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            catalogFunctions.ChangeSelectedJoke(lb_joke, ImageMem);
        }

        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            catalogFunctions.SortJoke(lb_joke, ComboBoxCategory);
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            catalogFunctions.SearchJoke(lb_joke, tbSearch);
        }
    }
}
