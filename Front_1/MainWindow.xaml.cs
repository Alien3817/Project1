using MaterialDesignThemes.Wpf;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;

namespace Front_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        private ObservableCollection<ResultItem> resultList;

        private Process _textProcessor;

        public void UpdateInputTextBox2(string newText)
        {
            inputTextBox2.Text = newText;
        }

        public void ProcessAndDisplay()
        {
            // Получите новый текст из inputTextBox2
            string inputText = inputTextBox2.Text;

            // Обработайте новый текст и обновите ListBox
            if (!string.IsNullOrEmpty(inputText))
            {
                Dictionary<char, string> encodingDictionary = Process.Main(inputText);
                List<ResultItem> resultList = encodingDictionary.Select(kv => new ResultItem { Letter = kv.Key, Code = kv.Value }).ToList();
                this.resultList = new ObservableCollection<ResultItem>(resultList);
                resultListBox.ItemsSource = this.resultList;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Создайте экземпляр MainViewModel и присвойте его DataContext
            ViewModel = new MainViewModel();
            DataContext = ViewModel;

            _textProcessor = new Process();  // Инициализация экземпляра Process
            ProcessAndDisplay(); // Вызовите метод обработки и отображения

            ChangeButton.Click += ChangeButton_Click;

            resultList = new ObservableCollection<ResultItem>();
            resultListBox.ItemsSource = resultList;
        }

        public class ResultItem
        {
            public char Letter { get; set; }
            public string Code { get; set; }
        }

        private void InputWindow_SendButtonClicked(object sender, string inputText)
        {
            // Обработка нового текста при нажатии кнопки отправки
            ViewModel.InputText = inputText;
            ProcessAndDisplay();
        }

        private void inputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                InputWindow inputWindow = new InputWindow(ViewModel);
                inputWindow.SendButtonClicked += InputWindow_SendButtonClicked;
                bool? result = inputWindow.ShowDialog();

                // Очистка коллекции
                resultList.Clear();

                // Добавление новых элементов
                if (!string.IsNullOrEmpty(ViewModel.InputText))
                {
                    // При закрытии InputWindow обновляем текст в inputTextBox
                    inputTextBox2.Text = ViewModel.InputText;

                    // Обрабатываем текст с использованием методов из класса Process
                    string inputText = ViewModel.InputText;
                    Dictionary<char, string> encodingDictionary = Process.Main(inputText);

                    // Преобразуем словарь в список элементов ResultItem
                    List<ResultItem> resultList = encodingDictionary.Select(kv => new ResultItem { Letter = kv.Key, Code = kv.Value }).ToList();

                    // Устанавливаем новую коллекцию как источник данных для resultListBox
                    resultListBox.ItemsSource = resultList;
                }
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

                        // Вызвать метод обработки после установки нового текста
                        ProcessAndDisplay();
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

                        // Вызвать метод обработки после установки нового текста
                        ProcessAndDisplay();
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка и установка начальной ширины, если она равна NaN
            if (double.IsNaN(SearchBorder.Width))
            {
                SearchBorder.Width = 50; // Замените 50 на ваше начальное значение
            }

            DoubleAnimation widthAnimation = new DoubleAnimation(250, TimeSpan.FromMilliseconds(200));
            SearchBorder.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);

            CornerRadius cornerRadius = new CornerRadius(30);
            SearchBorder.CornerRadius = cornerRadius;

            SearchTextBox.Visibility = Visibility.Visible;
            DoubleAnimation opacityAnimation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
            SearchTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            // Показать CloseButton с анимацией
            DoubleAnimation closeBtnOpacityAnimation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
            CloseButton.BeginAnimation(UIElement.OpacityProperty, closeBtnOpacityAnimation);
            CloseButton.Visibility = Visibility.Visible;
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

            // Проверка и установка начальной ширины, если она равна NaN
            if (double.IsNaN(ChangeBorder.Width))
            {
                ChangeBorder.Width = 60; // Замените 60 на ваше начальное значение
            }

            DoubleAnimation widthAnimation = new DoubleAnimation(1080, TimeSpan.FromMilliseconds(200));
            ChangeBorder.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);

            CornerRadius cornerRadius = new CornerRadius(30);
            ChangeBorder.CornerRadius = cornerRadius;

            RefreshIcon.Visibility = Visibility.Collapsed;
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            OutputTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            OutputTextBox.Visibility = Visibility.Visible;
            DoubleAnimation opacityAnimation2 = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
            OutputTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation2);

            // Показать CloseButton с анимацией
            DoubleAnimation closeBtnOpacityAnimation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
            CloseButton2.BeginAnimation(UIElement.OpacityProperty, closeBtnOpacityAnimation);
            CloseButton2.Visibility = Visibility.Visible;

            

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(50, TimeSpan.FromMilliseconds(200));
            SearchBorder.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);

            CornerRadius cornerRadius = new CornerRadius(50);
            SearchBorder.CornerRadius = cornerRadius;

            SearchTextBox.Visibility = Visibility.Collapsed;
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            SearchTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            // Скрыть CloseButton с анимацией
            DoubleAnimation closeBtnOpacityAnimation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            CloseButton.BeginAnimation(UIElement.OpacityProperty, closeBtnOpacityAnimation);
            CloseButton.Visibility = Visibility.Collapsed;
        }

        private void CloseButton_Click2(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(60, TimeSpan.FromMilliseconds(200));
            ChangeBorder.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);

            CornerRadius cornerRadius = new CornerRadius(50);
            ChangeBorder.CornerRadius = cornerRadius;

            OutputTextBox.Visibility = Visibility.Collapsed;
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            OutputTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            RefreshIcon.Visibility = Visibility.Visible;
            DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            OutputTextBox.BeginAnimation(UIElement.OpacityProperty, opacityAnimation2);

            // Скрыть CloseButton с анимацией
            DoubleAnimation closeBtnOpacityAnimation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200));
            CloseButton2.BeginAnimation(UIElement.OpacityProperty, closeBtnOpacityAnimation);
            CloseButton2.Visibility = Visibility.Collapsed;
        }

        private void inputTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
