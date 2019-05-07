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
using System.Configuration;

namespace Restaurant
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        int oldOrderId = -1;
        bool loading = true;

        class ComboboxValue
        {
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboboxValue(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["RestourantDB"].ConnectionString;
            sqlConnection = new SqlConnection(conectionString);

            await sqlConnection.OpenAsync();

            menuFilterComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(-1), Convert.ToString("Все")));
            menuFilterComboBox.SelectedIndex = 0;
            loadCategoryComboBox();
        }

        private void оToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramm form = new AboutProgramm();
            form.ShowDialog();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories form = new Categories(sqlConnection);
            form.Show();
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products form = new Products(sqlConnection);
            form.Show();
        }

        private void СкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock form = new Stock(sqlConnection);
            form.Show();
        }

        private async void loadMenuList() {

            menuDataGridView.Rows.Clear();

            SqlDataReader sqlReader = null;

            string query = "";

            if (menuFilterTextBox.TextLength != 0 && menuFilterComboBox.SelectedIndex == 0) {
                query = "SELECT * FROM [menu] WHERE UPPER(name) like UPPER(@name)+'%' ORDER BY ordinem";
            } 
            if (menuFilterTextBox.TextLength == 0 && menuFilterComboBox.SelectedIndex != 0)
            {
                query = "SELECT menu.* FROM [menu], [category_list] WHERE category_list.id_category=@categoryID AND category_list.id_menu=menu.id_menu ORDER BY ordinem";
            } 
            if (menuFilterTextBox.TextLength != 0 && menuFilterComboBox.SelectedIndex != 0)
            {
                query = "SELECT menu.* FROM [menu], [category_list] WHERE category_list.id_category=@categoryID AND category_list.id_menu=menu.id_menu AND UPPER(name) like UPPER(@name)+'%' ORDER BY ordinem";
            }
            if (menuFilterTextBox.TextLength == 0 && menuFilterComboBox.SelectedIndex == 0)
            {
                query = "SELECT * FROM [menu] ORDER BY ordinem";
            }

            SqlCommand loadCategoryList = new SqlCommand(query, sqlConnection);

            if (menuFilterTextBox.TextLength != 0)
                loadCategoryList.Parameters.AddWithValue("name", menuFilterTextBox.Text);
            if (menuFilterComboBox.SelectedIndex != 0)
            {
                ComboboxValue combo = (ComboboxValue)menuFilterComboBox.SelectedItem;
                loadCategoryList.Parameters.AddWithValue("categoryID", combo.Id);
            }

            try
            {
                sqlReader = await loadCategoryList.ExecuteReaderAsync();

                menuDataGridView.Rows.Clear();

                while (await sqlReader.ReadAsync())
                {
                    int rowNumber = menuDataGridView.Rows.Add();
                    menuDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_menu"]);
                    menuDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                }
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

        private async void loadCategoryComboBox() {
            SqlDataReader sqlReader = null;

            SqlCommand loadCategoryList = new SqlCommand("SELECT * FROM [categories] ORDER BY ordinem", sqlConnection);

            try
            {
                sqlReader = await loadCategoryList.ExecuteReaderAsync();

                for (int i = menuFilterComboBox.Items.Count-1; i > 1; i--)
                    menuFilterComboBox.Items.RemoveAt(i);

                while (await sqlReader.ReadAsync())
                {
                    menuFilterComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(sqlReader["id_category"]), Convert.ToString(sqlReader["name"])));
                }
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

        private void MenuFilterComboBox_DropDown(object sender, EventArgs e)
        {
            loadCategoryComboBox();
        }

        private void MenuFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            loadMenuList();
        }

        private void MenuFilterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadMenuList();
        }

        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            loadMenuList();
            menuTimer.Stop();
        }

        private void MenuDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            delayUpdateOrderTimer.Stop();

            if (orderDataGridView.SelectedCells.Count > 0) {
                int id = Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value);
                int listIndex = -1;

                for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                    if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[6].Value) == id)
                        listIndex = i;

                if (listIndex == -1)
                {
                    listIndex = listOrderDataGridView.Rows.Add();
                    listOrderDataGridView.Rows[listIndex].Cells[1].Value = menuDataGridView.Rows[e.RowIndex].Cells[1].Value;
                    listOrderDataGridView.Rows[listIndex].Cells[3].Value = 1;
                    listOrderDataGridView.Rows[listIndex].Cells[2] = new DataGridViewButtonCell();
                    listOrderDataGridView.Rows[listIndex].Cells[2].Value = "-";
                    listOrderDataGridView.Rows[listIndex].Cells[4] = new DataGridViewButtonCell();
                    listOrderDataGridView.Rows[listIndex].Cells[4].Value = "+";
                    listOrderDataGridView.Rows[listIndex].Cells[5].Value = 0;
                    listOrderDataGridView.Rows[listIndex].Cells[6].Value = Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value);

                    SqlDataReader sqlReader = null;
                    SqlCommand addOrderList = new SqlCommand("INSERT INTO [order_list] (id_orders, id_menu, count) VALUES(@id_orders, @id_menu, 1); SELECT IDENT_CURRENT('order_list') AS 'id'", sqlConnection);
                    addOrderList.Parameters.AddWithValue("id_orders", Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value));
                    addOrderList.Parameters.AddWithValue("id_menu", Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value));

                    try
                    {
                        sqlReader = addOrderList.ExecuteReader();
                        sqlReader.Read();

                        listOrderDataGridView.Rows[listIndex].Cells[0].Value = Convert.ToInt32(sqlReader["id"]);
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
                else
                {
                    listOrderDataGridView.Rows[listIndex].Cells[3].Value = Convert.ToInt32(listOrderDataGridView.Rows[listIndex].Cells[3].Value) + 1;
                    listOrderDataGridView.Rows[listIndex].Cells[5].Value = 1;
                }
            } else
                MessageBox.Show("Перед добавлением позиции выберите заказ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            delayUpdateOrderTimer.Start();
        }

        private async void AddOrderButton_Click(object sender, EventArgs e)
        {
            SqlCommand createOrder = new SqlCommand("INSERT INTO [orders] (time, closed, name) VALUES(GETDATE(), '0', IDENT_CURRENT('orders'))", sqlConnection);

            try
            {
                await createOrder.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadOrderGrid();
            orderDataGridView.CurrentCell = orderDataGridView.Rows[orderDataGridView.RowCount - 1].Cells[1];
            orderDataGridView.BeginEdit(true);
        }

        private  void loadOrderGrid() {
            SqlDataReader sqlReader = null;
            SqlCommand getOrderGrid = new SqlCommand("SELECT * FROM orders WHERE closed='0'", sqlConnection);

            try
            {
                sqlReader =  getOrderGrid.ExecuteReader();

                orderDataGridView.Rows.Clear();

                while ( sqlReader.Read())
                {
                    int rowNumber = orderDataGridView.Rows.Add();
                    orderDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_orders"]);
                    orderDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                }
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

        private void OrdersTimer_Tick(object sender, EventArgs e)
        {
            ordersTimer.Stop();
            loadOrderGrid();
            orderDataGridView.ClearSelection();
            loading = false;
        }

        private void OrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand updateNameOrder = new SqlCommand("UPDATE [orders] SET name=@name WHERE id_orders=@id", sqlConnection);

            updateNameOrder.Parameters.AddWithValue("name", Convert.ToString(orderDataGridView.Rows[e.RowIndex].Cells[1].Value));
            updateNameOrder.Parameters.AddWithValue("id", Convert.ToInt32(orderDataGridView.Rows[e.RowIndex].Cells[0].Value));

            try
            {
                updateNameOrder.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (oldOrderId != -1) {
                    delayUpdateOrderTimer.Stop();
                    updateListOrder();
                }  

                oldOrderId = Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value);

                SqlDataReader sqlReader = null;

                SqlCommand getOrderList = new SqlCommand("SELECT menu.name, order_list.count, order_list.id_menu, order_list.id_order_list FROM [order_list], [menu] WHERE order_list.id_orders=@id AND menu.id_menu=order_list.id_menu", sqlConnection);

                getOrderList.Parameters.AddWithValue("id", Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value));

                try
                {
                    sqlReader = getOrderList.ExecuteReader();

                    listOrderDataGridView.Rows.Clear();

                    while (sqlReader.Read())
                    {
                        int rowNumber = listOrderDataGridView.Rows.Add();
                        listOrderDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_order_list"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[3].Value = Convert.ToInt32(sqlReader["count"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[2] = new DataGridViewButtonCell();
                        listOrderDataGridView.Rows[rowNumber].Cells[2].Value = "-";
                        listOrderDataGridView.Rows[rowNumber].Cells[4] = new DataGridViewButtonCell();
                        listOrderDataGridView.Rows[rowNumber].Cells[4].Value = "+";
                        listOrderDataGridView.Rows[rowNumber].Cells[5].Value = 0;
                        listOrderDataGridView.Rows[rowNumber].Cells[6].Value = Convert.ToInt32(sqlReader["id_menu"]);
                    }
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

        private void DelayUpdateOrderTimer_Tick(object sender, EventArgs e)
        {
            delayUpdateOrderTimer.Stop();
            updateListOrder();
        }

        private void ListOrderDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            delayUpdateOrderTimer.Stop();
            listOrderDataGridView.Rows[e.RowIndex].Cells[5].Value = 1;
        }

        private void ListOrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            delayUpdateOrderTimer.Stop();

            if (e.ColumnIndex == 2)
            {
                listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value = Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value) - 1;
                listOrderDataGridView.Rows[e.RowIndex].Cells[5].Value = 1;
            }
            else if (e.ColumnIndex == 4) {
                listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value = Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value) + 1;
                listOrderDataGridView.Rows[e.RowIndex].Cells[5].Value = 1;
            }

            if (Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value) < 1) {
                SqlCommand delOrderList = new SqlCommand("DELETE FROM [order_list] WHERE id_order_list=@id", sqlConnection);
                delOrderList.Parameters.AddWithValue("id", Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[0].Value));
                try
                {
                    delOrderList.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listOrderDataGridView.Rows.RemoveAt(e.RowIndex);
            }
                

            delayUpdateOrderTimer.Start();
        }

        private void ListOrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[3].Value) < 1) {
                SqlCommand delOrderList = new SqlCommand("DELETE FROM [order_list] WHERE id_order_list=@id", sqlConnection);
                delOrderList.Parameters.AddWithValue("id", Convert.ToInt32(listOrderDataGridView.Rows[e.RowIndex].Cells[0].Value));
                try
                {
                    delOrderList.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listOrderDataGridView.Rows.RemoveAt(e.RowIndex);
            }
                
            delayUpdateOrderTimer.Start();
        }

        private void updateListOrder() {
            string query = "";
            for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[5].Value) == 1)
                    query += "UPDATE [order_list] SET count=@count" + Convert.ToString(i) + " WHERE id_order_list=@id" + Convert.ToString(i) + ";";

            if (query != "")
            {
                SqlCommand updateOrderList = new SqlCommand(query, sqlConnection);
                for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                    if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[5].Value) == 1)
                    {
                        updateOrderList.Parameters.AddWithValue("@count" + Convert.ToString(i), Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[3].Value));
                        updateOrderList.Parameters.AddWithValue("@id" + Convert.ToString(i), Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[0].Value));
                    }

                try
                {
                    updateOrderList.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloseOrderButton_Click(object sender, EventArgs e)
        {

        }
    }
}
