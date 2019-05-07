namespace Restaurant
{
    partial class ClosingOrder
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
            this.sumLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cashTextBox = new System.Windows.Forms.TextBox();
            this.deliveryLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма заказа составляет:";
            // 
            // sumLabel
            // 
            this.sumLabel.AutoSize = true;
            this.sumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumLabel.Location = new System.Drawing.Point(7, 31);
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Size = new System.Drawing.Size(77, 25);
            this.sumLabel.TabIndex = 1;
            this.sumLabel.Text = "0 руб.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Наличными";
            // 
            // cashTextBox
            // 
            this.cashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashTextBox.Location = new System.Drawing.Point(12, 81);
            this.cashTextBox.Name = "cashTextBox";
            this.cashTextBox.Size = new System.Drawing.Size(143, 20);
            this.cashTextBox.TabIndex = 0;
            this.cashTextBox.TextChanged += new System.EventHandler(this.CashTextBox_TextChanged);
            // 
            // deliveryLabel
            // 
            this.deliveryLabel.AutoSize = true;
            this.deliveryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryLabel.Location = new System.Drawing.Point(7, 136);
            this.deliveryLabel.Name = "deliveryLabel";
            this.deliveryLabel.Size = new System.Drawing.Size(77, 25);
            this.deliveryLabel.TabIndex = 5;
            this.deliveryLabel.Text = "0 руб.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Сдача:";
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(12, 178);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(75, 34);
            this.delButton.TabIndex = 2;
            this.delButton.Text = "Удалить заказ";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(195, 178);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(124, 34);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Подтвердить заказ";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ClosingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 224);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.deliveryLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cashTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sumLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClosingOrder";
            this.Text = "Закрытие заказа";
            this.Load += new System.EventHandler(this.ClosingOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cashTextBox;
        private System.Windows.Forms.Label deliveryLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button submitButton;
    }
}