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
    public partial class ClosingOrder : Form
    {
        private SqlConnection sqlConnection;
        int idOrder;
        double sum = 0;
        bool emptyOrder;

        public ClosingOrder(SqlConnection connection, int id, bool empty = false)
        {
            InitializeComponent();

            sqlConnection = connection;
            idOrder = id;
            emptyOrder = empty;
        }

        private void ClosingOrder_Load(object sender, EventArgs e)
        {
            if (!emptyOrder)
            {
                SqlDataReader sqlReader = null;

                SqlCommand getSum = new SqlCommand("SELECT SUM(menu.price * order_list.count + 0) AS 'sum' FROM [order_list], [menu] WHERE order_list.id_orders=@id AND order_list.id_menu=menu.id_menu", sqlConnection);
                getSum.Parameters.AddWithValue("id", idOrder);

                try
                {
                    sqlReader = getSum.ExecuteReader();

                    if (sqlReader.Read())
                        sum = Convert.ToDouble(sqlReader["sum"]);

                    sumLabel.Text = Convert.ToString(sum) + " руб.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();
                }
            }
        }

        private void CashTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cashTextBox.TextLength > 0)
                deliveryLabel.Text = Convert.ToString(Convert.ToDouble(cashTextBox.Text) - sum) + " руб.";
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            SqlCommand delOrder = new SqlCommand("DELETE FROM [orders] WHERE id_orders=@id; DELETE FROM [order_list] WHERE id_orders=@id", sqlConnection);
            delOrder.Parameters.AddWithValue("id", idOrder);
            try
            {
                delOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                Close();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlCommand submitOrder = new SqlCommand("UPDATE [orders] SET closed='1', sum=@sum WHERE id_orders=@id; " +
                                                    "UPDATE [stocks] SET stocks.count=(stocks.count - recipes.quantity * order_list.count) FROM [order_list], [recipes] " +
                                                    "WHERE order_list.id_orders=@id AND recipes.id_menu=order_list.id_menu AND stocks.id_stocks=recipes.id_stocks", sqlConnection);
            submitOrder.Parameters.AddWithValue("sum", sum);
            submitOrder.Parameters.AddWithValue("id", idOrder);
            try
            {
                submitOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
