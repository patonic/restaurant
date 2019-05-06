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

        private void MenuFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            int id = Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value);
            int listIndex = -1;

            for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[0].Value) == id)
                    listIndex = i;

            if (listIndex == -1)
            {
                listIndex = listOrderDataGridView.Rows.Add();
                listOrderDataGridView.Rows[listIndex].Cells[0].Value = menuDataGridView.Rows[e.RowIndex].Cells[0].Value;
                listOrderDataGridView.Rows[listIndex].Cells[1].Value = menuDataGridView.Rows[e.RowIndex].Cells[1].Value;
                listOrderDataGridView.Rows[listIndex].Cells[3].Value = 1;
            }
            else {
                listOrderDataGridView.Rows[listIndex].Cells[3].Value = Convert.ToInt32(listOrderDataGridView.Rows[listIndex].Cells[3].Value) + 1;
            }
        }
    }
}
