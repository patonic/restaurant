﻿using System;
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

        public ClosingOrder(SqlConnection connection, int id)
        {
            InitializeComponent();

            sqlConnection = connection;
            idOrder = id;
        }

        private void ClosingOrder_Load(object sender, EventArgs e)
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

        private void CashTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cashTextBox.TextLength > 0)
                deliveryLabel.Text = Convert.ToString(Convert.ToDouble(cashTextBox.Text) - sum) + " руб.";
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            SqlCommand delOrder = new SqlCommand("DELETE FROM [orders] WHERE id_orders=@id; DELETE FROM [order_list] WHERE id_orders=@id", sqlConnection);
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
            SqlCommand delOrder = new SqlCommand("UPDATE [orders] SET closed='1', sum=@sum", sqlConnection);
            try
            {
                delOrder.ExecuteNonQuery();
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
