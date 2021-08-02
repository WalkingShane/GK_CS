using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Руслан Островский

namespace UgadaiChislo
{

    //Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
    //Компьютер говорит, больше или меньше загаданное число введенного.
    //    a) Для ввода данных от человека используется элемент TextBox;
    //    б) ** Реализовать отдельную форму c TextBox для ввода числа.
    //Старайтесь разбивать программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию.Все программы сделать в одном решении.
    //В свойствах проектах в качестве запускаемого проекта укажите “Текущий выбор”.
    public partial class Form1 : Form
    {
        Random random = new Random();
        int number, numbTry;
        public void StartNewGame()
        {
            number = random.Next(1, 101);
            lblAdvice.Visible = false;

            MessageBox.Show("Число от 1 до 100 загадано. Время угадывать!", "Новая игра", MessageBoxButtons.OK);
            lblTryCount.Text = "0";
        }
        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            lblTryCount.Text = (int.Parse(lblTryCount.Text) + 1).ToString();
            lblAdvice.Visible = true;
            if (int.TryParse(tbNumber.Text, out numbTry))
            {
                if (numbTry == number)
                {
                    lblAdvice.Text = "В яблочко!";
                    var result = MessageBox.Show($"Вы отгадали число за {lblTryCount.Text} попыток! Желаете повторить?", "Победа", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        this.Close();
                    else StartNewGame();
                }
                else if (numbTry < number)
                    lblAdvice.Text = "Маловато";
                else lblAdvice.Text = "Многовато";
            }
            else MessageBox.Show("В поле необходимо вводить только числа!", "Неправильный ввод", MessageBoxButtons.OK);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
