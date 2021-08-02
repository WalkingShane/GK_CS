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
namespace WF_Udvoitel
{
//      а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//      б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
//      Игрок должен получить это число за минимальное количество ходов.
//      в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int> Stack.
//  Вся логика игры должна быть реализована в классе с удвоителем.
    public partial class Form1 : Form
    {
        int number;
        Random random = new Random();
        private void StartNewGame()
        {
            number = random.Next(10, 101);

            lblNumber.Text = "1";
            lblCommandsCount.Text = "0";
            lblGoal.Text = number.ToString();

            MessageBox.Show($"Попробуйте получить число {number} с помощью двух команд.", "Игра началась!", MessageBoxButtons.OK);

            lblNumber.Visible = true;
            lblCommandsCount.Visible = true;
            lblGoal.Visible = true;
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            btnStart.Text = "Играть";

            lblGoalText.Text = "Цель";
            lblNumber.Text = "0";
            lblNumber.Visible = false;
            lblCommandsCount.Text = "0";
            lblCommandsCount.Visible = false;
            lblGoal.Visible = false;
            this.Text = "Удвоитель";
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCommandsCount_TextChanged(object sender, EventArgs e)
        {
            if (lblNumber.Text == lblGoal.Text)
            {
                if (MessageBox.Show($"Вы получили заданное число за {lblCommandsCount.Text} ходов.\nЕще раз?", "Победа!", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                {
                    Close();
                }
                else StartNewGame();
            }
        }
    }
}
