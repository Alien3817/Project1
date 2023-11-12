using MaterialDesignThemes.Wpf;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Front_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private void inputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow(ViewModel);
            bool? result = inputWindow.ShowDialog();

            if (result == true)
            {
                // При закрытии InputWindow обновляем текст в inputTextBox
                inputTextBox2.Text = ViewModel.InputText;
            }
        }

        //БУРГЕР
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new ContextMenu();

            menu.Owner = this;
            menu.ShowDialog();

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // Менюшка, которая вылазит после нажатия на бургер
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Бургер + о программе
            MessageBox.Show("1 Общие сведения о программе – полное наименование, обозначение, ее возможные применения, а также программное обеспечение, необходимое для функционирования программы, и языки программирования, на которых она написана. Например:\r\nПрограмма \"Автоматизированное рабочее место разработчика САУ\" предназначена для… реализована на… Программа поддерживает…\r\nПрограмма написана на языке…с использованием компилятора…\r\n2 Функциональное назначение – назначение программы и общее описание функционирования программы, ее основные характеристики, сведения об ограничениях, накладываемых на область применения программы. Например:\r\nПрограмма предназначена для решения задач… Программа представляет собой ядро автоматизированного рабочего места…\r\nПользователь имеет возможность…, осуществить…, запустить…, проанализировать…, получить результаты анализа и обработки…, построить… и т.п.\r\n3 Описание логической структуры – используемые методы, алгоритмы программы, описание структуры и логики программы (c привязкой к тексту программы на исходном языке) и ее составных частей, их функций и связей между ними, а также связи программы с другими программами. Содержание этого раздела должно быть конкретным и опираться на текст программы.\r\nВыбор метода решения предполагает определение теоретической возможности решения задачи и нахождение формального правила его получения. Данный этап плохо формализуется, что связано с чрезвычайно широким многообразием задач и методов их решения.\r\nМетод решения может быть представлен:\r\n– в виде системы формул (безусловной или условной);\r\n– в виде словесного изложения последовательности действий;\r\n– в виде их комбинаций.");
        }


        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Проверка на двойное нажатие
            if (e.ClickCount == 3)
            {
                // Открыть окно InputWindow при условии отсутствия текста в textblock
                if (string.IsNullOrWhiteSpace(inputTextBox2.Text))
                {
                    InputWindow inputWindow = new InputWindow(ViewModel);
                    bool? result = inputWindow.ShowDialog();

                    if (result == true)
                    {
                        // Получить введенный текст и установить его в textblock
                        inputTextBox2.Text = inputWindow.InputText;
                    }
                }
            }
            // Проверка на одиночное нажатие
            else if (e.ClickCount == 2)
            {
                // Редактирование текста при наличии текста в textblock
                if (!string.IsNullOrWhiteSpace(inputTextBox2.Text))
                {
                    InputWindow inputWindow = new InputWindow(ViewModel);
                    inputWindow.InputText = inputTextBox2.Text; // Передать текущий текст в окно редактирования
                    bool? result = inputWindow.ShowDialog();

                    if (result == true)
                    {
                        // Получить отредактированный текст и установить его в textblock
                        inputTextBox2.Text = inputWindow.InputText;
                    }
                }
            }
        }


       
        

        // обрабатывает наведение на кнопку
        private void header_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.Red;
            else
            {
                border.Background = Brushes.DarkGray;
                border.Opacity = 0.7;
            }
        }

        // обрабатывает: мыша покидает кнопку
        private void header_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = Brushes.WhiteSmoke; //WhiteSmoke 5
        }

        // обрабатывает нажатие на кнопку
        private void header_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.WhiteSmoke;
            else
            {
                border.Background = Brushes.WhiteSmoke;
                border.Opacity = 1;
            }
        }

        // управение действием кнопок: закрыть, на весь экран, маленькое окно, свернуть на панель задач
        private void header_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                this.Close();
            else if ((border.Name == "maxmin"))
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Maximized;
            }
            else
                this.WindowState = WindowState.Minimized;
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ваш код обработки изменений в тексте
        }

        private void ListBox_Value_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_Key_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
