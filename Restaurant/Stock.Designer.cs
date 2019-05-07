﻿namespace Restaurant
{
    partial class Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addStocks = new System.Windows.Forms.ToolStripButton();
            this.editStocks = new System.Windows.Forms.ToolStripButton();
            this.deleteStocks = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateStocksList = new System.Windows.Forms.ToolStripButton();
            this.listStoks = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reserved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listStoks)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStocks,
            this.editStocks,
            this.deleteStocks,
            this.toolStripSeparator1,
            this.updateStocksList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addStocks
            // 
            this.addStocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addStocks.Image = ((System.Drawing.Image)(resources.GetObject("addStocks.Image")));
            this.addStocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addStocks.Name = "addStocks";
            this.addStocks.Size = new System.Drawing.Size(80, 24);
            this.addStocks.Text = "&Добавить";
            this.addStocks.Click += new System.EventHandler(this.AddStocks_Click);
            // 
            // editStocks
            // 
            this.editStocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editStocks.Image = ((System.Drawing.Image)(resources.GetObject("editStocks.Image")));
            this.editStocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editStocks.Name = "editStocks";
            this.editStocks.Size = new System.Drawing.Size(115, 24);
            this.editStocks.Text = "&Редактировать";
            this.editStocks.Click += new System.EventHandler(this.EditStocks_Click);
            // 
            // deleteStocks
            // 
            this.deleteStocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteStocks.Image = ((System.Drawing.Image)(resources.GetObject("deleteStocks.Image")));
            this.deleteStocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteStocks.Name = "deleteStocks";
            this.deleteStocks.Size = new System.Drawing.Size(69, 24);
            this.deleteStocks.Text = "&Удалить";
            this.deleteStocks.Click += new System.EventHandler(this.DeleteStocks_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // updateStocksList
            // 
            this.updateStocksList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateStocksList.Image = ((System.Drawing.Image)(resources.GetObject("updateStocksList.Image")));
            this.updateStocksList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateStocksList.Name = "updateStocksList";
            this.updateStocksList.Size = new System.Drawing.Size(82, 24);
            this.updateStocksList.Text = "&Обновить";
            this.updateStocksList.Click += new System.EventHandler(this.UpdateStocksList_Click);
            // 
            // listStoks
            // 
            this.listStoks.AllowUserToAddRows = false;
            this.listStoks.AllowUserToDeleteRows = false;
            this.listStoks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listStoks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listStoks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Count,
            this.reserved,
            this.id});
            this.listStoks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStoks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listStoks.Location = new System.Drawing.Point(0, 27);
            this.listStoks.MultiSelect = false;
            this.listStoks.Name = "listStoks";
            this.listStoks.ReadOnly = true;
            this.listStoks.RowHeadersVisible = false;
            this.listStoks.RowTemplate.Height = 24;
            this.listStoks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listStoks.Size = new System.Drawing.Size(800, 423);
            this.listStoks.TabIndex = 4;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 101;
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 115;
            // 
            // reserved
            // 
            this.reserved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.reserved.HeaderText = "Зарезервировано";
            this.reserved.Name = "reserved";
            this.reserved.ReadOnly = true;
            this.reserved.Width = 155;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listStoks);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Stock";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.Stock_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listStoks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addStocks;
        private System.Windows.Forms.ToolStripButton editStocks;
        private System.Windows.Forms.ToolStripButton deleteStocks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton updateStocksList;
        private System.Windows.Forms.DataGridView listStoks;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn reserved;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}