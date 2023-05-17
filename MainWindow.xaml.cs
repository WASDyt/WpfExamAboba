using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfExam.Classes;

namespace WpfExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Combine.ItemsSource = ConnectHelper.namberses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAddProtohype windowAdd = new WindowAddProtohype();
            windowAdd.ShowDialog();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
         DtgListPreparate.ItemsSource = null;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                // получаем выбранный файл
                ConnectHelper.fileName = openFileDialog.FileName;
                ConnectHelper.ReadListFromFile(ConnectHelper.fileName);
                //ConnectHelper.ReadListFromFile(@"ListPreparates.txt");
            }
            else
                return;
            DtgListPreparate.ItemsSource = ConnectHelper.performances.ToList();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((bool)saveFileDialog.ShowDialog())
            {
                string file = saveFileDialog.FileName;
                ConnectHelper.SaveListToFile(file);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
               MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                int ind = DtgListPreparate.SelectedIndex;
                ConnectHelper.performances.RemoveAt(ind);
                DtgListPreparate.ItemsSource = ConnectHelper.performances.ToList();
                ConnectHelper.SaveListToFile(ConnectHelper.fileName);
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {//поиск по ФИО
            DtgListPreparate.ItemsSource = ConnectHelper.performances.Where(x => x.Fio.Contains(TxtSearch.Text)).ToList();
        }


        private void Combine_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int namber = ConnectHelper.namberses[Combine.SelectedIndex];
            if (Combine.SelectedIndex != 0)
                DtgListPreparate.ItemsSource = ConnectHelper.performances.Where(x => x.Nambers == namber).ToList();
            else
                DtgListPreparate.ItemsSource = ConnectHelper.namberses;
        }
    }
}
