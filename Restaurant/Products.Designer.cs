﻿namespace Restaurant
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.listProducts = new System.Windows.Forms.DataGridView();
            this.ordinem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addProducts = new System.Windows.Forms.ToolStripButton();
            this.renameProducts = new System.Windows.Forms.ToolStripButton();
            this.deleteProducts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateProductsList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.productsUpper = new System.Windows.Forms.ToolStripButton();
            this.productsDowner = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.listProducts)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listProducts
            // 
            this.listProducts.AllowUserToAddRows = false;
            this.listProducts.AllowUserToDeleteRows = false;
            this.listProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordinem,
            this.name,
            this.price,
            this.category,
            this.recipes,
            this.id});
            this.listProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listProducts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listProducts.Location = new System.Drawing.Point(0, 30);
            this.listProducts.MultiSelect = false;
            this.listProducts.Name = "listProducts";
            this.listProducts.ReadOnly = true;
            this.listProducts.RowHeadersVisible = false;
            this.listProducts.RowTemplate.Height = 24;
            this.listProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listProducts.Size = new System.Drawing.Size(567, 427);
            this.listProducts.TabIndex = 3;
            // 
            // ordinem
            // 
            this.ordinem.HeaderText = "№";
            this.ordinem.Name = "ordinem";
            this.ordinem.ReadOnly = true;
            this.ordinem.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 101;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.price.HeaderText = "Цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 72;
            // 
            // category
            // 
            this.category.HeaderText = "Категории";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // recipes
            // 
            this.recipes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.recipes.HeaderText = "Состав";
            this.recipes.Name = "recipes";
            this.recipes.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProducts,
            this.renameProducts,
            this.deleteProducts,
            this.toolStripSeparator1,
            this.updateProductsList,
            this.toolStripSeparator2,
            this.productsUpper,
            this.productsDowner});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(567, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addProducts
            // 
            this.addProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addProducts.Image = ((System.Drawing.Image)(resources.GetObject("addProducts.Image")));
            this.addProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProducts.Name = "addProducts";
            this.addProducts.Size = new System.Drawing.Size(80, 27);
            this.addProducts.Text = "&Добавить";
            this.addProducts.Click += new System.EventHandler(this.addProducts_Click);
            // 
            // renameProducts
            // 
            this.renameProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renameProducts.Image = ((System.Drawing.Image)(resources.GetObject("renameProducts.Image")));
            this.renameProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameProducts.Name = "renameProducts";
            this.renameProducts.Size = new System.Drawing.Size(115, 27);
            this.renameProducts.Text = "&Редактировать";
            this.renameProducts.Click += new System.EventHandler(this.renameProducts_Click);
            // 
            // deleteProducts
            // 
            this.deleteProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteProducts.Image = ((System.Drawing.Image)(resources.GetObject("deleteProducts.Image")));
            this.deleteProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteProducts.Name = "deleteProducts";
            this.deleteProducts.Size = new System.Drawing.Size(69, 27);
            this.deleteProducts.Text = "&Удалить";
            this.deleteProducts.Click += new System.EventHandler(this.DeleteProducts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // updateProductsList
            // 
            this.updateProductsList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateProductsList.Image = ((System.Drawing.Image)(resources.GetObject("updateProductsList.Image")));
            this.updateProductsList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateProductsList.Name = "updateProductsList";
            this.updateProductsList.Size = new System.Drawing.Size(82, 27);
            this.updateProductsList.Text = "&Обновить";
            this.updateProductsList.Click += new System.EventHandler(this.updateProductsList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // productsUpper
            // 
            this.productsUpper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.productsUpper.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productsUpper.Image = ((System.Drawing.Image)(resources.GetObject("productsUpper.Image")));
            this.productsUpper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.productsUpper.Name = "productsUpper";
            this.productsUpper.Size = new System.Drawing.Size(23, 27);
            this.productsUpper.Text = "&↑";
            this.productsUpper.Click += new System.EventHandler(this.ProductsUpper_Click);
            // 
            // productsDowner
            // 
            this.productsDowner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.productsDowner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.productsDowner.Image = ((System.Drawing.Image)(resources.GetObject("productsDowner.Image")));
            this.productsDowner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.productsDowner.Name = "productsDowner";
            this.productsDowner.Size = new System.Drawing.Size(23, 27);
            this.productsDowner.Text = "&↓";
            this.productsDowner.Click += new System.EventHandler(this.ProductsDowner_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 457);
            this.Controls.Add(this.listProducts);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Products";
            this.Text = "Товары";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listProducts)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listProducts;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addProducts;
        private System.Windows.Forms.ToolStripButton renameProducts;
        private System.Windows.Forms.ToolStripButton deleteProducts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton updateProductsList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton productsUpper;
        private System.Windows.Forms.ToolStripButton productsDowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordinem;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}