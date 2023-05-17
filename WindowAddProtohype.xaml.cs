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
using WpfExam.Classes;

namespace WpfExam
{
    /// <summary>
    /// Логика взаимодействия для WindowAddProtohype.xaml
    /// </summary>
    public partial class WindowAddProtohype : Window
    {
        int mode;
        public WindowAddProtohype()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddProtohype(ClassLibary pharm) 
        {
            InitializeComponent();
            TxbName.Text = pharm.Fio;
            TxbCount.Text = pharm.Nambers.ToString();
            TxbPrice.Text = pharm.Performance1.ToString();
            TxbMonth.Text = pharm.Performance2.ToString();
            TxbMonth1.Text = pharm.Performance3.ToString();
            TxbMonth2.Text = pharm.Performance4.ToString();
            TxbMonth3.Text = pharm.Performance5.ToString();
            mode = 1;
            Addtomain.Content = "Сохранить";
        }

        private void Addtomain_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TxbCount.Text) < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TxbCount.Clear();
                TxbCount.Focus();
                return;
            }
            if (mode == 0)
            {//добавление данных
                try
                {
                    ClassLibary pharmacy = new ClassLibary()
                    {
                        Fio = TxbName.Text,
                        Nambers = int.Parse(TxbCount.Text),
                        Performance1 = TxbPrice.Text,
                        Performance2 = TxbMonth.Text,
                        Performance3 = TxbMonth.Text,
                        Performance4 = TxbMonth.Text,
                        Performance5 = TxbMonth.Text

                    };

                    ConnectHelper.performances.Add(pharmacy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            //редактирование
            else
            {
                try
                {
                    for (int i = 0; i < ConnectHelper.performances.Count; i++)
                    {
                        if (ConnectHelper.performances[i].Fio == TxbName.Text)
                        {
                            ConnectHelper.performances[i].Nambers = int.Parse(TxbPrice.Text);
                            ConnectHelper.performances[i].Performance1 = TxbPrice.Text;
                            ConnectHelper.performances[i].Performance2 = TxbPrice.Text;
                            ConnectHelper.performances[i].Performance3 = TxbPrice.Text;
                            ConnectHelper.performances[i].Performance4 = TxbPrice.Text;
                            ConnectHelper.performances[i].Performance5 = TxbPrice.Text;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }
            ConnectHelper.SaveListToFile(ConnectHelper.fileName);
            this.Close();
        }
    }
}
