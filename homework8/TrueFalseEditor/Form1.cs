using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor
{
    public partial class Form1 : Form
    {

        TrueFalse database;
        string Caption { get { return this.Text; } set { this.Text = value; } }
        public Form1()
        {
            InitializeComponent();
            CreateNewDataBase();
        }
        private void CreateNewDataBase()
        {
            Caption = "new*";
            database = new TrueFalse();
            database.Add("Земля круглая?", true);
            database.Changed = true;
            nudNumber.Minimum = 1;
            nudNumber.Maximum = 1;
            nudNumber.Value = 1;
        }
        private void ChangePanelColor(bool answer)
        {
            if (answer)
                this.panel1.BackColor = Color.Green;
            else
                this.panel1.BackColor = Color.Red;
        }
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            CreateNewDataBase();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.Load();
                string[] folders = database.FileName.Split('\\', '.');
                Caption = folders[folders.Length - 2];
                database.Changed = false;
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            if (database[(int)nudNumber.Value - 1].TrueFalse)
            {
                rbYes.Checked = true;
            }
            else
            {
                rbNo.Checked = true;
            }
        }
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database.Changed)
                if (database.FileName == null)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.DefaultExt = ".xml";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        database.FileName = saveFile.FileName;
                        database.Save();
                        string[] folders = database.FileName.Split('\\', '.');
                        Caption = folders[folders.Length - 2];
                        database.Changed = false;
                    }
                }
                else
                {
                    database.Save();
                    string[] folders = database.FileName.Split('\\', '.');
                    Caption = folders[folders.Length - 2];
                    database.Changed = false;
                }
                
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".xml";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFile.FileName;
                database.Save();
                string[] folders = database.FileName.Split('\\', '.');
                Caption = folders[folders.Length - 2];
                database.Changed = false;
            }
        }


        private void btnAdd_Click_3(object sender, EventArgs e)
        {
            database.Add("#" + (database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            
            database.Changed = true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database.Count > 1)
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum--;
                if (!database.Changed) Caption += "*";
                database.Changed = true;
            }
            else MessageBox.Show("Последнюю запись удалить нельзя.", "Удаление последней записи", MessageBoxButtons.OK);
        }
        private void btnSaveQuestion_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            if (rbYes.Checked)
            {
                database[(int)nudNumber.Value - 1].TrueFalse = true;
            }
            else
            {
                database[(int)nudNumber.Value - 1].TrueFalse = false;
            }
            if (!database.Changed) Caption += "*";
            database.Changed = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            if (rbYes.Checked)
            {
                database[(int)nudNumber.Value - 1].TrueFalse = true;
            }
            else
            {
                database[(int)nudNumber.Value - 1].TrueFalse = false;
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_2(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработано Русланом Островским\nВ рамках курса GeekBrains \"Основы языка C#\"", "О программе", MessageBoxButtons.OK);
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelColor(true);
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelColor(false);
        }
    }
}
