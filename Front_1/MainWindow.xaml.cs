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
using System.Windows.Media.Animation;

namespace Front_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        private bool isFlipped = false;

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

                resultListBox.ItemsSource = resultList;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            // Создайте экземпляр MainViewModel и присвойте его DataContext
            ViewModel = new MainViewModel();
            DataContext = ViewModel;

            ProcessAndDisplay(); // Вызовите метод обработки и отображения

            ChangeButton.Click += ChangeButton_Click;

        }

        public class ResultItem
        {
            public char Letter { get; set; }
            public string Code { get; set; }
        }

        private void inputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                InputWindow inputWindow = new InputWindow(ViewModel);
                bool? result = inputWindow.ShowDialog();

                if (result == true)
                {
                    // При закрытии InputWindow обновляем текст в inputTextBox
                    inputTextBox2.Text = ViewModel.InputText;

                    // Добавляем текст в ListBox и обрабатываем его
                    string inputText = ViewModel.InputText;
                    resultListBox.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

                    if (!string.IsNullOrEmpty(inputText))
                    {
                        // Обрабатываем текст с использованием методов из класса Process
                        Dictionary<char, string> encodingDictionary = Process.Main(inputText);

                        // Преобразуем словарь в список элементов ResultItem
                        List<ResultItem> resultList = encodingDictionary.Select(kv => new ResultItem { Letter = kv.Key, Code = kv.Value }).ToList();

                        // Добавляем элементы в ListBox
                        resultListBox.ItemsSource = resultList;
                    }
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
            // Определите анимацию переворота
            RotateTransform rotateTransform = new RotateTransform();
            AnimatedBorder.RenderTransform = rotateTransform;
            DoubleAnimation rotationAnimation = new DoubleAnimation();
            rotationAnimation.To = isFlipped ? 0 : 180; // Переворачиваем на 180 градусов, если не перевернуто, иначе возвращаем обратно
            rotationAnimation.Duration = TimeSpan.FromSeconds(1);

            // Определите анимацию изменения текста в TextBox
            string newText = isFlipped ? "Initial Content" : "Changed Content";
            TextBlock contentText = AnimatedBorder.FindName("ContentText") as TextBlock;
            if (contentText != null)
            {
                contentText.Text = newText;
            }

            // Определите анимацию изменения прозрачности
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.To = isFlipped ? 1 : 0.5; // Изменяем прозрачность, чтобы подчеркнуть анимацию
            opacityAnimation.Duration = TimeSpan.FromSeconds(1);

            // Совместите анимации
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(rotationAnimation);
            storyboard.Children.Add(opacityAnimation);
            Storyboard.SetTarget(rotationAnimation, rotateTransform);
            Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(RotateTransform.AngleProperty));
            Storyboard.SetTarget(opacityAnimation, AnimatedBorder);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(Border.OpacityProperty));

            // Запуск анимации
            storyboard.Begin();

            // Инвертируйте флаг
            isFlipped = !isFlipped;
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
    }
}
