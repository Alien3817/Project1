using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Front
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;


            //cOLOR
            this.BackColor = ColorTranslator.FromHtml("#E7E9EF");

            //button2

            //button1

        }




        public virtual System.Drawing.Color BackColor { get; set; }

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
            MessageBox.Show("1 Общие сведения о программе – полное наименование, обозначение, ее возможные применения, а также программное обеспечение, необходимое для функционирования программы, и языки программирования, на которых она написана. Например:\r\nПрограмма \"Автоматизированное рабочее место разработчика САУ\" предназначена для… реализована на… Программа поддерживает…\r\nПрограмма написана на языке…с использованием компилятора…\r\n2 Функциональное назначение – назначение программы и общее описание функционирования программы, ее основные характеристики, сведения об ограничениях, накладываемых на область применения программы. Например:\r\nПрограмма предназначена для решения задач… Программа представляет собой ядро автоматизированного рабочего места…\r\nПользователь имеет возможность…, осуществить…, запустить…, проанализировать…, получить результаты анализа и обработки…, построить… и т.п.\r\n3 Описание логической структуры – используемые методы, алгоритмы программы, описание структуры и логики программы (c привязкой к тексту программы на исходном языке) и ее составных частей, их функций и связей между ними, а также связи программы с другими программами. Содержание этого раздела должно быть конкретным и опираться на текст программы.\r\nВыбор метода решения предполагает определение теоретической возможности решения задачи и нахождение формального правила его получения. Данный этап плохо формализуется, что связано с чрезвычайно широким многообразием задач и методов их решения.\r\nМетод решения может быть представлен:\r\n– в виде системы формул (безусловной или условной);\r\n– в виде словесного изложения последовательности действий;\r\n– в виде их комбинаций.");
        }

        private void командаПректаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Бургер + Команда Проекта
            MessageBox.Show("Администратор - Шохоева Валерия\r\nАрхитектор - Волчков Игорь\r\n\r\nКоманда аналитиков:\r\nВолчков Игорь\r\nЛю Хао\r\n\r\nКоманда Backend-разработчиков:\r\nСоловей Алексей\r\nКостин Иван\r\nПорошин Дмитрий \r\n?\r\n?\r\n?\r\n\r\nКоманда Frontend-разработчиков:\r\nЧеботарев Сергей\r\nПинчуков Александр \r\n\r\nКоманда дизайнеров:\r\nБикова Валерия\r\nГабышева Ангелина\r\n\r\nКоманда тестировщиков:\r\nШетько Глеб\r\n?\r\n?\r\n\r\nКоманда диза\r\n\r\n\r\n\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            GraphicsPath GetRoundPath(RectangleF Rect, int radius)
            {
                float r2 = radius / 2f;
                GraphicsPath GraphPath = new GraphicsPath();

                GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
                GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
                GraphPath.AddArc(Rect.X + Rect.Width - radius,
                                    Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

                GraphPath.CloseFigure();
                return GraphPath;
            }

             
            void OnPaint(PaintEventArgs s)
            {
            base.OnPaint(s);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = GetRoundPath(Rect, 50);

            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.Lime, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                s.Graphics.DrawPath(pen, GraphPath);
            }
            }



        // Текстовая кнопка
        // Создаёт дочернюю форму
        Form2 settingsForm = new Form2();
            // Вызывает дочернюю форму поверх родительской, так что бы нельзя было пользоваться родительской. Код родительской приостонавливается до тех пор, пока не будет закрыта дочерняя
            settingsForm.ShowDialog();
            // * После закрытия дочерней формы код родительской продолжается и текст занесёный в отделный класс в дочерней форме теперь доступен и в родительской
            // Даём клавише название текстом, который мы написали в дочерней форме
            button2.Text = InputText.Text;
            // Вспомогательный словарь для реализации поиска
            Dictionary<char, int> iterative_dictionary = new Dictionary<char, int>();
            // номер итерации для вспомагательного словаря
            int i = 0;
            // цикл foreach выполняется до окончания коллекции (словаря). В качестве словаря используется функция вызывающая код бека
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
                if (Iterative_dictionary.It_dic.TryGetValue(find[0], out index))
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
            // Dictionary<char, string> plug = new Dictionary<char, string>();
         /*   OurText = OurText.Replace("\r", "");*/
            Dictionary<char, string> plug = Process.Main(OurText);

            /*    plug.Add('\n', "0000");*/
            /*            plug.Add("Б", "0001");
                        plug.Add("В", "0010");
                        plug.Add("Г", "0100");
                        plug.Add("Д", "1000");
                        plug.Add("Е", "0011");
                        plug.Add("Ж", "0101");
                        plug.Add("З", "1001");
                        plug.Add("И", "0111");
                        plug.Add("К", "1011");
                        plug.Add("Л", "1111");
                        plug.Add("М", "00000");
                        plug.Add("Н", "00001");*/
            return plug;
        }
    }

        


}
