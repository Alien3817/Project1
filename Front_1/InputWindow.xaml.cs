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

namespace Front_1
{
    /// <summary>
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public System.Windows.Controls.ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

        public delegate void TextChangedEventHandler(string newText);

        public event EventHandler<string> SendButtonClicked;

        public string EnteredText { get; set; }
        public string InputText { get; internal set; }

        public MainViewModel ViewModel { get; set; }

        public InputWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
            Closed += InputWindow_Closed;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            InputText = inputTextBox1.Text;
            DialogResult = true;
            UpdateTextAndProcess(); // Добавьте этот вызов
            SendButtonClicked?.Invoke(this, InputText); // Оповещение о нажатии кнопки отправки
            Close();
        }

        private void UpdateTextAndProcess()
        {
            // Обновите текст в inputTextBox2
            (Owner as MainWindow)?.UpdateInputTextBox2(InputText);

            // Запустите обработку нового текста и обновите ListBox
            (Owner as MainWindow)?.ProcessAndDisplay();
        }

        private void InputWindow_Closed(object sender, System.EventArgs e)
        {
            // Сохраняем текст, если окно закрыто не через кнопку Send
            if (!DialogResult.HasValue || !DialogResult.Value)
            {
                ViewModel.InputText = inputTextBox1.Text; 
            }
        }
        


        // обрабатывает наведение на кнопку
        private void header_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;

            Color newColor = Color.FromRgb(0xFA, 0x2D, 0x2D);
            SolidColorBrush brush = new SolidColorBrush(newColor);

            if (border.Name == "close") 
                border.Background = brush;
            else
            {
                border.Background = Brushes.LightSeaGreen;
                border.Opacity = 0.7;
            }
        }


        // обрабатывает: мыша покидает кнопку
        private void header_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            // Создаем объект Color с цветом E7E9EF
            Color newColor = Color.FromRgb(0xE7, 0xE9, 0xEF);
            // Создаем новый SolidColorBrush с использованием нового цвета
            SolidColorBrush brush = new SolidColorBrush(newColor);
            // Устанавливаем новый цвет фона
            border.Background = brush;
        }


        // обрабатывает нажатие на кнопку
        private void header_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;

            Color newColor = Color.FromRgb(0xFA, 0x2D, 0x2D);
            SolidColorBrush brush = new SolidColorBrush(newColor);

            if (border.Name == "close")
            border.Background = brush;
            else
            {
                border.Background = Brushes.LightSeaGreen;
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

        private void TextBox1_Changed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

  
}
