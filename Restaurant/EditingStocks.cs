using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant
{
    public partial class EditingStocks : Form
    {
        private SqlConnection sqlConnection;
        private int id;

        public EditingStocks(SqlConnection connection, int idTransf = -1)
        {
            InitializeComponent();

            sqlConnection = connection;
            id = idTransf;
            if (id == -1)
            {
                this.Text = "Добавление ресурса";
                submitButton.Text = "Сохранить";
            }
            else
            {
                this.Text = "Редактирование ресурса";
                submitButton.Text = "Сохранить";
            }
        }

        private async void EditingStocks_Load(object sender, EventArgs e)
        {
            if (id != -1)
            {
                SqlCommand loadStock = new SqlCommand("SELECT * FROM [stocks] WHERE id_stocks=@id", sqlConnection);
                loadStock.Parameters.AddWithValue("id", id);

                try
                {
                    SqlDataReader sqlReader = await loadStock.ExecuteReaderAsync();
                    await sqlReader.ReadAsync();

                    nameTextBox.Text = Convert.ToString(sqlReader["name"]);
                    countTextBox.Text = Convert.ToString(sqlReader["count"]);
                    minCountTextBox.Text = Convert.ToString(sqlReader["threshold"]);

                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                SqlCommand addStock = new SqlCommand("INSERT INTO [stocks] (name, count, threshold) VALUES (@name, @count, @threshold)", sqlConnection);
                addStock.Parameters.AddWithValue("name", nameTextBox.Text);
                addStock.Parameters.AddWithValue("count", countTextBox.Text);
                addStock.Parameters.AddWithValue("threshold", minCountTextBox.Text);

                try
                {
                    await addStock.ExecuteNonQueryAsync();
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                SqlCommand updateStock = new SqlCommand("UPDATE [stocks] SET name=@name, count=@count, threshold=@threshold WHERE id_stocks=@id", sqlConnection);
                updateStock.Parameters.AddWithValue("name", nameTextBox.Text);
                updateStock.Parameters.AddWithValue("count", countTextBox.Text);
                updateStock.Parameters.AddWithValue("threshold", minCountTextBox.Text);
                updateStock.Parameters.AddWithValue("id", id);

                try
                {
                    await updateStock.ExecuteNonQueryAsync();
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
