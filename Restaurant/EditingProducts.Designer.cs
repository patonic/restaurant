namespace Restaurant
{
    partial class EditingProducts
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.recipesComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recipesCountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.recipesDataGridView = new System.Windows.Forms.DataGridView();
            this.id_component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.availableCheckBox = new System.Windows.Forms.CheckBox();
            this.componentBox = new System.Windows.Forms.GroupBox();
            this.categoryBox = new System.Windows.Forms.GroupBox();
            this.categoryDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.removeCategoryButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recipesDataGridView)).BeginInit();
            this.componentBox.SuspendLayout();
            this.categoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название товара";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(140, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Стоимость";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(393, 12);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(150, 22);
            this.priceTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 4;
            // 
            // recipesComboBox
            // 
            this.recipesComboBox.FormattingEnabled = true;
            this.recipesComboBox.Location = new System.Drawing.Point(104, 21);
            this.recipesComboBox.Name = "recipesComboBox";
            this.recipesComboBox.Size = new System.Drawing.Size(175, 24);
            this.recipesComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Компонент";
            // 
            // recipesCountTextBox
            // 
            this.recipesCountTextBox.Location = new System.Drawing.Point(104, 56);
            this.recipesCountTextBox.Name = "recipesCountTextBox";
            this.recipesCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.recipesCountTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество";
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.Location = new System.Drawing.Point(16, 94);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(157, 27);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Добавить компонент";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.AutoSize = true;
            this.delButton.Location = new System.Drawing.Point(189, 94);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(75, 27);
            this.delButton.TabIndex = 10;
            this.delButton.Text = "Удалить";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // recipesDataGridView
            // 
            this.recipesDataGridView.AllowUserToAddRows = false;
            this.recipesDataGridView.AllowUserToDeleteRows = false;
            this.recipesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recipesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.recipesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recipesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_component,
            this.name,
            this.quantity});
            this.recipesDataGridView.Location = new System.Drawing.Point(12, 127);
            this.recipesDataGridView.MultiSelect = false;
            this.recipesDataGridView.Name = "recipesDataGridView";
            this.recipesDataGridView.ReadOnly = true;
            this.recipesDataGridView.RowHeadersVisible = false;
            this.recipesDataGridView.RowTemplate.Height = 24;
            this.recipesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recipesDataGridView.Size = new System.Drawing.Size(363, 441);
            this.recipesDataGridView.TabIndex = 11;
            // 
            // id_component
            // 
            this.id_component.HeaderText = "Код компонента";
            this.id_component.Name = "id_component";
            this.id_component.ReadOnly = true;
            this.id_component.Visible = false;
            // 
            // name
            // 
            this.name.FillWeight = 101.5229F;
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.FillWeight = 98.47715F;
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.Location = new System.Drawing.Point(505, 634);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "Сохранить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Location = new System.Drawing.Point(598, 634);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 27);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // availableCheckBox
            // 
            this.availableCheckBox.AutoSize = true;
            this.availableCheckBox.Checked = true;
            this.availableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.availableCheckBox.Location = new System.Drawing.Point(558, 11);
            this.availableCheckBox.Name = "availableCheckBox";
            this.availableCheckBox.Size = new System.Drawing.Size(115, 21);
            this.availableCheckBox.TabIndex = 15;
            this.availableCheckBox.Text = "Доступность";
            this.availableCheckBox.UseVisualStyleBackColor = true;
            // 
            // componentBox
            // 
            this.componentBox.Controls.Add(this.recipesComboBox);
            this.componentBox.Controls.Add(this.label4);
            this.componentBox.Controls.Add(this.recipesCountTextBox);
            this.componentBox.Controls.Add(this.label5);
            this.componentBox.Controls.Add(this.recipesDataGridView);
            this.componentBox.Controls.Add(this.addButton);
            this.componentBox.Controls.Add(this.delButton);
            this.componentBox.Location = new System.Drawing.Point(12, 40);
            this.componentBox.Name = "componentBox";
            this.componentBox.Size = new System.Drawing.Size(387, 582);
            this.componentBox.TabIndex = 16;
            this.componentBox.TabStop = false;
            this.componentBox.Text = "Состав товара";
            // 
            // categoryBox
            // 
            this.categoryBox.Controls.Add(this.categoryDataGridView);
            this.categoryBox.Controls.Add(this.addCategoryButton);
            this.categoryBox.Controls.Add(this.categoryComboBox);
            this.categoryBox.Controls.Add(this.removeCategoryButton);
            this.categoryBox.Controls.Add(this.label6);
            this.categoryBox.Location = new System.Drawing.Point(405, 40);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(268, 582);
            this.categoryBox.TabIndex = 17;
            this.categoryBox.TabStop = false;
            this.categoryBox.Text = "Категории";
            // 
            // categoryDataGridView
            // 
            this.categoryDataGridView.AllowUserToAddRows = false;
            this.categoryDataGridView.AllowUserToDeleteRows = false;
            this.categoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoryDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.categoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.categoryDataGridView.Location = new System.Drawing.Point(10, 92);
            this.categoryDataGridView.MultiSelect = false;
            this.categoryDataGridView.Name = "categoryDataGridView";
            this.categoryDataGridView.ReadOnly = true;
            this.categoryDataGridView.RowHeadersVisible = false;
            this.categoryDataGridView.RowTemplate.Height = 24;
            this.categoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoryDataGridView.Size = new System.Drawing.Size(248, 476);
            this.categoryDataGridView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Код категории";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 101.5229F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.AutoSize = true;
            this.addCategoryButton.Location = new System.Drawing.Point(10, 59);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(157, 27);
            this.addCategoryButton.TabIndex = 12;
            this.addCategoryButton.Text = "Добавить категорию";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.AddCategoryButton_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(95, 21);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(163, 24);
            this.categoryComboBox.TabIndex = 12;
            // 
            // removeCategoryButton
            // 
            this.removeCategoryButton.AutoSize = true;
            this.removeCategoryButton.Location = new System.Drawing.Point(183, 59);
            this.removeCategoryButton.Name = "removeCategoryButton";
            this.removeCategoryButton.Size = new System.Drawing.Size(75, 27);
            this.removeCategoryButton.TabIndex = 13;
            this.removeCategoryButton.Text = "Удалить";
            this.removeCategoryButton.UseVisualStyleBackColor = true;
            this.removeCategoryButton.Click += new System.EventHandler(this.RemoveCategoryButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Категория";
            // 
            // EditingProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 673);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.componentBox);
            this.Controls.Add(this.availableCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditingProducts";
            this.Text = "EditingProducts";
            this.Load += new System.EventHandler(this.EditingProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recipesDataGridView)).EndInit();
            this.componentBox.ResumeLayout(false);
            this.componentBox.PerformLayout();
            this.categoryBox.ResumeLayout(false);
            this.categoryBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox recipesComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox recipesCountTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.DataGridView recipesDataGridView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox availableCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_component;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.GroupBox componentBox;
        private System.Windows.Forms.GroupBox categoryBox;
        private System.Windows.Forms.DataGridView categoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Button removeCategoryButton;
        private System.Windows.Forms.Label label6;
    }
}