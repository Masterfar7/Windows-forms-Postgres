using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class ConnectionDataBase
    {
        string connection = "Host=localhost;Username=postgres;Password=1;Database=company";

        public void InitializationOfDataBase()
        {
            try
            {
                NpgsqlConnection sqlConnection = new NpgsqlConnection(sql);
                sqlConnection.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
