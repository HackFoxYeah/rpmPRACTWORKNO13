using System;
using System.Linq.Expressions;
using System.Windows;
using Пример_таблицы_WPF;

namespace practWorkNo13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        float[,] data;

        private void BtnDoATask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SupClass.DoATask(data, tbResults);
            }
            catch (Exception exception)
            {
                MessageBoxResult error = MessageBox.Show("Упс, таблица-то не создана!\n" + exception.Message, "Ошибочка возникла!", MessageBoxButton.OKCancel);

                if (error == MessageBoxResult.OK)
                {
                    return;
                }
                else if (error == MessageBoxResult.Cancel)
                {
                    MessageBox.Show("Закрытие программы...", "Закрываю типо");
                    Close();
                }
            }            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint columns = uint.Parse(tbCA.Text),
                        rows = uint.Parse(tbSA.Text),
                         max = uint.Parse(tbMaxValue.Text),
                         min = uint.Parse(tbMinValue.Text);

                Random rnd = new();

                data = new float[rows, columns];

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        data[i, j] = rnd.Next((int)min, (int)max + 1);
                    }
                }

                dataGrid.ItemsSource = VisualArray.ToDataTable(data).DefaultView;
            }
            catch (Exception exception)
            {
                MessageBoxResult error = MessageBox.Show("Упс, вы ввели чот не то\n" + exception.Message, "Ошибочка возникла!", MessageBoxButton.OKCancel);

                if (error == MessageBoxResult.OK)
                {
                    return;
                }
                else if (error == MessageBoxResult.Cancel)
                {
                    MessageBox.Show("Закрытие программы...", "Закрываю типо");
                    Close();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
