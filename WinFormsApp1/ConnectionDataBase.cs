using System;
using System.Data;
using Npgsql;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class DataBase
    {
        private readonly string connectionString =
            "Host=localhost;Username=postgres;Password=1;Database=company";

        public async Task<DataTable> GetAllAsync()
        {
            using var conn = new NpgsqlConnection(connectionString);
            using var cmd = new NpgsqlCommand("SELECT * FROM employees", conn);

            await conn.OpenAsync();                    
            using var reader = await cmd.ExecuteReaderAsync(); 

            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public async Task AddAsync(string name, string position, decimal salary)
        {
            using var conn = new NpgsqlConnection(connectionString);
            using var cmd = new NpgsqlCommand(
                "INSERT INTO employees(name, position, salary) VALUES (@n, @p, @s)", conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@p", position);
            cmd.Parameters.AddWithValue("@s", salary);

            await conn.OpenAsync();                    
            await cmd.ExecuteNonQueryAsync();          
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = new NpgsqlConnection(connectionString);
            using var cmd = new NpgsqlCommand(
                "DELETE FROM employees WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await conn.OpenAsync();                    
            await cmd.ExecuteNonQueryAsync();           
        }

        public async Task<DataTable> FindByIdAsync(int id)
        {
            using var conn = new NpgsqlConnection(connectionString);
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM employees WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await conn.OpenAsync();                  
            using var reader = await cmd.ExecuteReaderAsync(); 

            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public async Task UpdateAsync(int id, string newName, string newPosition, decimal newSalary)
        {
            using var conn = new NpgsqlConnection(connectionString);
            using var cmd = new NpgsqlCommand(
                "UPDATE employees SET name = @name, position = @position, salary = @salary WHERE id = @id", conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", newName);
            cmd.Parameters.AddWithValue("@position", newPosition);
            cmd.Parameters.AddWithValue("@salary", newSalary);

            await conn.OpenAsync();                    // ←
            await cmd.ExecuteNonQueryAsync();           // ←
        }
    }
}