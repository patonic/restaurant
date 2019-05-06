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
    public partial class EditingProducts : Form
    {
        private SqlConnection sqlConnection;
        private int id;

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

        public EditingProducts(SqlConnection connection, int idTransf = -1)
        {
            InitializeComponent();

            sqlConnection = connection;
            id = idTransf;
            if (id == -1)
            {
                this.Text = "Добавление товара";
            }
            else
            {
                this.Text = "Редактирование товара";
            }
        }

        private async void EditingProducts_Load(object sender, EventArgs e)
        {
            if (id > -1)
            {
                SqlCommand loadProducts = new SqlCommand("SELECT name, price, available FROM [menu] WHERE id_menu=@id", sqlConnection);
                loadProducts.Parameters.AddWithValue("id", id);

                try
                {
                    SqlDataReader sqlReader = await loadProducts.ExecuteReaderAsync();
                    await sqlReader.ReadAsync();

                    nameTextBox.Text = Convert.ToString(sqlReader["name"]);
                    priceTextBox.Text = Convert.ToString(sqlReader["price"]);
                    availableCheckBox.Checked = Convert.ToBoolean(sqlReader["available"]);

                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();

                    SqlCommand loadRecipesGreed = new SqlCommand("SELECT stocks.id_stocks, stocks.name, recipes.quantity  FROM stocks, recipes  WHERE recipes.id_stocks = stocks.id_stocks AND recipes.id_menu = @id", sqlConnection);
                    loadRecipesGreed.Parameters.AddWithValue("id", id);

                    sqlReader = await loadRecipesGreed.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        int rowNumber = recipesDataGridView.Rows.Add();
                        recipesDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_stocks"]);
                        recipesDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                        recipesDataGridView.Rows[rowNumber].Cells[2].Value = Convert.ToDouble(sqlReader["quantity"]);
                    }

                   if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();

                    SqlCommand loadCategoryGreed = new SqlCommand("SELECT categories.name, categories.id_category FROM [categories], [category_list] WHERE category_list.id_category = categories.id_category AND category_list.id_menu = @id_menu", sqlConnection);
                    loadCategoryGreed.Parameters.AddWithValue("id_menu", id);

                    sqlReader = await loadCategoryGreed.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        int rowNumber = categoryDataGridView.Rows.Add();
                        categoryDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader[0]);
                        categoryDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToString(sqlReader[1]);
                    }

                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SqlCommand loadRecipesList = new SqlCommand("SELECT id_stocks, name FROM [stocks]", sqlConnection);
            try
            {
                SqlDataReader sqlReader = await loadRecipesList.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    recipesComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(sqlReader["id_stocks"]), Convert.ToString(sqlReader["name"])));
                }

                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SqlCommand loadCategoryList = new SqlCommand("SELECT id_category, name FROM [categories]", sqlConnection);
            try
            {
                SqlDataReader sqlReader = await loadCategoryList.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    categoryComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(sqlReader["id_category"]), Convert.ToString(sqlReader["name"])));
                }

                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string error = "";
            float count;
            
            ComboboxValue combo = (ComboboxValue)recipesComboBox.SelectedItem;

            if (combo == null)
                error = "Не выбран компонент\n";
            if (!float.TryParse(recipesCountTextBox.Text, out count))
                error += "Введиите количество компонента\n";

            if (error == "")
            {
                int rowNumber = recipesDataGridView.Rows.Add();
                recipesDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(combo.Id);
                recipesDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(combo.Name);
                recipesDataGridView.Rows[rowNumber].Cells[2].Value = Convert.ToDouble(count);
            }
            else {
                MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (recipesDataGridView.SelectedRows.Count == 1)
            {
                recipesDataGridView.Rows.Remove(recipesDataGridView.SelectedRows[0]);
            }
            else {
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            string error = "";
            if (nameTextBox.Text == "")
                error += "Имя не может быть пустым\n";
            if (priceTextBox.Text == "")
                error += "Стоимоть не может быть пустой";
            if (error != "") {
                MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == -1)
            {
                string query = "INSERT INTO [menu] (name, price, available, ordinem) VALUES (@name, @price, @available, IDENT_CURRENT('menu'))";

                if (recipesDataGridView.RowCount > 0)
                    query = query + "; INSERT INTO [recipes] (id_menu, id_stocks, quantity) VALUES";
                for (int i = 0; i < recipesDataGridView.RowCount; i++)
                {
                    query = query + " (IDENT_CURRENT('menu'), @id_menu" + i + ", @quantity" + i + ")";
                    if (i < recipesDataGridView.RowCount - 1)
                        query = query + ",";
                }

                if (categoryDataGridView.RowCount > 0)
                    query = query + "; INSERT INTO [category_list] (id_menu, id_category) VALUES";
                for (int i = 0; i < categoryDataGridView.RowCount; i++)
                {
                    query = query + " (IDENT_CURRENT('menu'), @id_menuC" + i + ")";
                    if (i < categoryDataGridView.RowCount - 1)
                        query = query + ",";
                }

                SqlCommand addProduct = new SqlCommand(query, sqlConnection);
                addProduct.Parameters.AddWithValue("name", nameTextBox.Text);
                addProduct.Parameters.AddWithValue("price", priceTextBox.Text);
                addProduct.Parameters.AddWithValue("available", availableCheckBox.Checked);

                for (int i = 0; i < recipesDataGridView.RowCount; i++)
                {
                    addProduct.Parameters.AddWithValue("id_menu" + i, recipesDataGridView.Rows[i].Cells[0].Value);
                    addProduct.Parameters.AddWithValue("quantity" + i, recipesDataGridView.Rows[i].Cells[2].Value);
                }

                for (int i = 0; i < categoryDataGridView.RowCount; i++)
                {
                    addProduct.Parameters.AddWithValue("id_menuC" + i, categoryDataGridView.Rows[i].Cells[0].Value);
                }

                try
                {
                    await addProduct.ExecuteNonQueryAsync();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                string query = "UPDATE [menu] SET name=@name, price=@price, available=@available WHERE id_menu=@id_menu; DELETE FROM [recipes] WHERE id_menu=@id_menu; DELETE FROM [category_list] WHERE id_menu=@id_menu";

                if (recipesDataGridView.RowCount > 0)
                    query = query + "; INSERT INTO [recipes] (id_menu, id_stocks, quantity) VALUES";
                for (int i = 0; i < recipesDataGridView.RowCount; i++)
                {
                    query = query + " (@id_menu, @id_menu" + i + ", @quantity" + i + ")";
                    if (i < recipesDataGridView.RowCount - 1)
                        query = query + ",";
                }

                if (categoryDataGridView.RowCount > 0)
                    query = query + "; INSERT INTO [category_list] (id_menu, id_category) VALUES";
                for (int i = 0; i < categoryDataGridView.RowCount; i++)
                {
                    query = query + " (@id_menu, @id_menuC" + i + ")";
                    if (i < categoryDataGridView.RowCount - 1)
                        query = query + ",";
                }

                SqlCommand updateProduct = new SqlCommand(query, sqlConnection);
                updateProduct.Parameters.AddWithValue("name", nameTextBox.Text);
                updateProduct.Parameters.AddWithValue("price", Convert.ToDouble(priceTextBox.Text));
                updateProduct.Parameters.AddWithValue("available", availableCheckBox.Checked);
                updateProduct.Parameters.AddWithValue("id_menu", id);

                for (int i = 0; i < recipesDataGridView.RowCount; i++)
                {
                    updateProduct.Parameters.AddWithValue("id_menu" + i, recipesDataGridView.Rows[i].Cells[0].Value);
                    updateProduct.Parameters.AddWithValue("quantity" + i, recipesDataGridView.Rows[i].Cells[2].Value);
                }

                for (int i = 0; i < categoryDataGridView.RowCount; i++)
                {
                    updateProduct.Parameters.AddWithValue("id_menuC" + i, categoryDataGridView.Rows[i].Cells[0].Value);
                }

                try
                {
                    await updateProduct.ExecuteNonQueryAsync();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            string error = "";

            ComboboxValue combo = (ComboboxValue)categoryComboBox.SelectedItem;

            if (combo == null)
                error = "Не выбрана категория";

            if (error == "")
            {
                int rowNumber = categoryDataGridView.Rows.Add();
                categoryDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(combo.Id);
                categoryDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(combo.Name);
            }
            else
            {
                MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveCategoryButton_Click(object sender, EventArgs e)
        {
            if (categoryDataGridView.SelectedRows.Count == 1)
            {
                categoryDataGridView.Rows.Remove(categoryDataGridView.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Выберите строку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
