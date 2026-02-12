using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly DataBase _dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            dataGridView1.DataSource = await _dataBase.GetAllAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                !decimal.TryParse(textBox3.Text, out decimal salary))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _dataBase.AddAsync(textBox1.Text, textBox2.Text, salary);
            await RefreshDataGridViewAsync();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox7.Text, out int idToUpdate) ||
                !decimal.TryParse(textBox6.Text, out decimal newSalary) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Заполните все поля корректно.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _dataBase.UpdateAsync(idToUpdate, textBox4.Text, textBox5.Text, newSalary);
            await RefreshDataGridViewAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox8.Text, out int idToDelete))
            {
                MessageBox.Show("Введите корректный ID для удаления.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _dataBase.DeleteAsync(idToDelete);
            await RefreshDataGridViewAsync();
            textBox8.Clear();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox9.Text, out int idToFind))
            {
                MessageBox.Show("Введите корректный ID для поиска.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.DataSource = await _dataBase.FindByIdAsync(idToFind);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await RefreshDataGridViewAsync();
        }

        private async Task RefreshDataGridViewAsync()
        {
            dataGridView1.DataSource = await _dataBase.GetAllAsync();
        }
    }
}