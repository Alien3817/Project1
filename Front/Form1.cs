using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Front
{
    public partial class Form1 : Form
    {
        private Language currentLanguage = Language.RU;
        private Dictionary<String, Dictionary<Language, String>> textData = new Dictionary<String, Dictionary<Language, String>>()
        {
            {"aboutProgramm", new Dictionary<Language, String>()
                {
                    {Language.RU,  "Данная программа предназначена для кодировки текста методом Шеннона" +
                    " - Фано.\r\nКодирование Шеннона-Фано — это технология сжатия данных без потерь," +
                    " основанная на теории информации, предложенная Клодом Шенноном и Робертом Фано" +
                    " в 1949 году.\r\nВот как это работает:\r\nВычисляется частота встречаемости" +
                    " символов: Сначала необходимо проанализировать кодируемый набор символов и" +
                    " посчитать частоту встречаемости каждого символа в кодируемом тексте.\r\nСортировка:" +
                    " Сортировка набора символов от большего к меньшему в зависимости от частоты" +
                    " появления символов.\r\nРазделение: разделить отсортированный набор символов" +
                    " на два подмножества так, чтобы сумма частот символов в двух подмножествах" +
                    " была как можно ближе.\r\nКодирование: Для левого подмножества и правого" +
                    " подмножества добавляется к ним двоичный код соответственно, добавив 0 и 1" +
                    " на основе исходного кода. Затем рекурсивно выполняется шаги 3 и 4 для обоих" +
                    " подмножеств, пока каждое подмножество не будет содержать только один символ." +
                    "\r\nСоздаётся таблица кодирования: записывается каждый символ и соответствующую" +
                    " ему кодировку в таблицу кодирования.\r\nВы можете проверить работоспособность" +
                    " программы, нажав на поле \"введите текст...\". Вводите текст, программа" +
                    " предоставляет вам кодировки для каждого символа, чтобы редактировать текст," +
                    " нажмите кнопку \"карандаш\""},
                    {Language.ENG, "Здесь будет английское aboutProgramm" },
                    {Language.CHINA, "Здесь будет китайское aboutProgramm" }
                }
                
            },
            {"projectTeam", new Dictionary<Language, String>()
                {
                    {Language.RU,  "Администратор - Шохоева Валерия\r\nАрхитектор - Волчков Игорь\r\n\r\n" +
                    "Команда аналитиков:\r\nВолчков Игорь\r\nЛю Хао\r\n\r\nКоманда" +
                    " Backend-разработчиков:\r\nСоловей Алексей\r\nКостин Иван\r\nПорошин Дмитрий" +
                    " \r\nЧичеров Дмитрий\r\nЗорин Вячеслав\r\nВепринцев Владислав\r\n\r\nКоманда " +
                    "Frontend-разработчиков:\r\nЧеботарев Сергей\r\nПинчуков Александр \r\n\r\nКоманда" +
                    " дизайнеров:\r\nБикова Валерия\r\nГабышева Ангелина\r\n\r\nКоманда тестировщиков:" +
                    "\r\nШетько Глеб\r\nВедешин Максим\r\nКурзенев Дмитрий\r\n"},
                    {Language.ENG, "Здесь будет английское aboutProgramm" },
                    {Language.CHINA, "Здесь будет китайское aboutProgramm" }
                }
            },
            {"alphabet",  new Dictionary<Language, String>()
                {
                    {Language.RU, "Алфавит"},
                    {Language.ENG, "Alphabet" }
                }
            }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void updateTextForm()
        {
            label1.Text = textData["alphabet"][currentLanguage];
            // остальные лэйблы и формы...
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Бургер
            contextMenuStrip1.Show(button1, 0, 22);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Итоговая таблица
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Хз что это
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // Менюшка, которая вылазит после нажатия на бургер
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // label "Алфавит"
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // label "Двоичный код"
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Текстовая строка для поиска
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Бургер + о программе
            MessageBox.Show(textData["aboutProgramm"][currentLanguage]);
/*            MessageBox.Show("Данная программа предназначена для кодировки текста методом Шеннона" +
                " - Фано.\r\nКодирование Шеннона-Фано — это технология сжатия данных без потерь," +
                " основанная на теории информации, предложенная Клодом Шенноном и Робертом Фано" +
                " в 1949 году.\r\nВот как это работает:\r\nВычисляется частота встречаемости" +
                " символов: Сначала необходимо проанализировать кодируемый набор символов и" +
                " посчитать частоту встречаемости каждого символа в кодируемом тексте.\r\nСортировка:" +
                " Сортировка набора символов от большего к меньшему в зависимости от частоты" +
                " появления символов.\r\nРазделение: разделить отсортированный набор символов" +
                " на два подмножества так, чтобы сумма частот символов в двух подмножествах" +
                " была как можно ближе.\r\nКодирование: Для левого подмножества и правого" +
                " подмножества добавляется к ним двоичный код соответственно, добавив 0 и 1" +
                " на основе исходного кода. Затем рекурсивно выполняется шаги 3 и 4 для обоих" +
                " подмножеств, пока каждое подмножество не будет содержать только один символ." +
                "\r\nСоздаётся таблица кодирования: записывается каждый символ и соответствующую" +
                " ему кодировку в таблицу кодирования.\r\nВы можете проверить работоспособность" +
                " программы, нажав на поле \"введите текст...\". Вводите текст, программа" +
                " предоставляет вам кодировки для каждого символа, чтобы редактировать текст," +
                " нажмите кнопку \"карандаш\"");*/
        }

        private void командаПректаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Бургер + Команда Проекта
            MessageBox.Show("Администратор - Шохоева Валерия\r\nАрхитектор - Волчков Игорь\r\n\r\n" +
                "Команда аналитиков:\r\nВолчков Игорь\r\nЛю Хао\r\n\r\nКоманда" +
                " Backend-разработчиков:\r\nСоловей Алексей\r\nКостин Иван\r\nПорошин Дмитрий" +
                " \r\nЧичеров Дмитрий\r\nЗорин Вячеслав\r\nВепринцев Владислав\r\n\r\nКоманда " +
                "Frontend-разработчиков:\r\nЧеботарев Сергей\r\nПинчуков Александр \r\n\r\nКоманда" +
                " дизайнеров:\r\nБикова Валерия\r\nГабышева Ангелина\r\n\r\nКоманда тестировщиков:" +
                "\r\nШетько Глеб\r\nВедешин Максим\r\nКурзенев Дмитрий\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Текстовая кнопка
            // Создаёт дочернюю форму
            Form2 settingsForm = new Form2();
            // Вызывает дочернюю форму поверх родительской, так что бы нельзя было пользоваться родительской. Код родительской приостонавливается до тех пор, пока не будет закрыта дочерняя
            settingsForm.ShowDialog();
            // * После закрытия дочерней формы код родительской продолжается и текст занесёный в отделный класс в дочерней форме теперь доступен и в родительской
            // Даём клавише название текстом, который мы написали в дочерней форме
            // Вспомогательный словарь для реализации поиска
            Dictionary<char, int> iterative_dictionary = new Dictionary<char, int>();
            // номер итерации для вспомагательного словаря
            // цикл foreach выполняется до окончания коллекции (словаря). В качестве словаря используется функция вызывающая код бека
            if (InputText.Text.Length > 0)
            {
                button2.Text = "";
                textBox2.Text = InputText.Text;
                button2.Visible = false;
                button4.Visible = true;
                int i = 0;
                foreach (var kvp in Backend(InputText.Text))
                {
                    // в listBox добавляются значения словаря
                    listBox1.Items.Add("\t" + kvp.Key + "\t\t" + kvp.Value);
                    // Добавляем в спомогательный словарь букву-ключ и индекс-значение
                    iterative_dictionary.Add(kvp.Key, i);
                    // Индекс++
                    i += 1;
                }
                // Записываем вспомагалтельный словарь в класс, для использования его в других частях программы
                Iterative_dictionary.It_dic = iterative_dictionary;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // Редактирование кнопки
            Form2 settingsForm = new Form2();
            settingsForm.ShowDialog();
            listBox1.Items.Clear();
            textBox2.Text = InputText.Text;
            Dictionary<char, int> iterative_dictionary = new Dictionary<char, int>();
            int i = 0;
            if (InputText.Text.Length > 0)
            {
                foreach (var kvp in Backend(InputText.Text))
                {
                    listBox1.Items.Add("\t" + kvp.Key + "\t\t" + kvp.Value);
                    iterative_dictionary.Add(kvp.Key, i);
                    i += 1;
                }
                Iterative_dictionary.It_dic = iterative_dictionary;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Кнопка поиска
            // Записывает в find символ (string), который необходимо найти
            string find = textBox1.Text;
            // Проверка длинны
            if (find.Length == 1)
            {
                int index;
                // Метод описанный ниже пытается найти символ во вспомагательном словаре, если находит, то записывает в index номер ключа и возвращаает true, иначе возвращает false
                char symbol = find[0];
                if (Iterative_dictionary.It_dic.TryGetValue(symbol, out index))
                    // Выбирает строчку в нашей таблице с номером index
                    listBox1.SelectedIndex = index;
                else
                {
                    MessageBox.Show("Не найдено");
                }
            }
            else
            {
                MessageBox.Show("Впишите 1 символ");
            }
        }

        private Dictionary<char, string> Backend(string OurText)
        {
            // Код бека
            Dictionary<char, string> plug = Process.Main(OurText);
            return plug;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentLanguage == Language.RU)
            {
                currentLanguage = Language.ENG;
            } else
            {
                currentLanguage= Language.RU;
            }
            updateTextForm();
        }
    }
}
