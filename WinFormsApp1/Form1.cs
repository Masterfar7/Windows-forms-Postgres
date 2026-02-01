using System.Data;
using System.Windows.Forms;
using Npgsql;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string sql = "Host=localhost;Username=postgres;Password=1;Database=company";
        ConnectionDataBase connBD = new ConnectionDataBase();
        public Form1()
        {
            InitializeComponent();

            SqlConnectionReader();
        }
        private void SqlConnectionReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM employees";
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }
            command.Dispose();
            sqlConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("INSERT INTO employees(id,name,position,salary) VALUES ('6','{0}', '{1}', '{2}')", textBox1.Text, textBox2.Text, textBox3.Text);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }
            command.Dispose();
            sqlConnection.Close();
            SqlConnectionReader();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("UPDATE employees SET name = '{0}',position = '{1}',salary = '{2}' WHERE id = '{3}'", textBox4.Text, textBox5.Text, textBox6.Text, Convert.ToInt32(textBox7.Text));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }
            command.Dispose();
            sqlConnection.Close();
            SqlConnectionReader();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("DELETE FROM employees WHERE id = '{0}'",Convert.ToInt32(textBox8.Text));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }
            command.Dispose();
            sqlConnection.Close();
            SqlConnectionReader();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = String.Format("SELECT * FROM employees WHERE id = '{0}'",Convert.ToInt32(textBox9.Text));
            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }
            command.Dispose();
            sqlConnection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnectionReader();
        }
    }
}
