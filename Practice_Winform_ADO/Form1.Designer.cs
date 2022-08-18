namespace Practice_Winform_ADO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.femaleButton = new System.Windows.Forms.RadioButton();
            this.maleButton = new System.Windows.Forms.RadioButton();
            this.dataProduct = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.customerNameBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.customer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 210);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 69;
            // 
            // femaleButton
            // 
            this.femaleButton.AutoSize = true;
            this.femaleButton.Location = new System.Drawing.Point(207, 142);
            this.femaleButton.Name = "femaleButton";
            this.femaleButton.Size = new System.Drawing.Size(63, 19);
            this.femaleButton.TabIndex = 68;
            this.femaleButton.TabStop = true;
            this.femaleButton.Text = "Female";
            this.femaleButton.UseVisualStyleBackColor = true;
            // 
            // maleButton
            // 
            this.maleButton.AutoSize = true;
            this.maleButton.Location = new System.Drawing.Point(133, 142);
            this.maleButton.Name = "maleButton";
            this.maleButton.Size = new System.Drawing.Size(51, 19);
            this.maleButton.TabIndex = 67;
            this.maleButton.TabStop = true;
            this.maleButton.Text = "Male";
            this.maleButton.UseVisualStyleBackColor = true;
            // 
            // dataProduct
            // 
            this.dataProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProduct.Location = new System.Drawing.Point(57, 350);
            this.dataProduct.Name = "dataProduct";
            this.dataProduct.RowTemplate.Height = 25;
            this.dataProduct.Size = new System.Drawing.Size(660, 240);
            this.dataProduct.TabIndex = 66;
            this.dataProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct_CellClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(544, 288);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 65;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(354, 288);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 64;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(165, 288);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 63;
            this.insertButton.Text = "INSERT";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(574, 141);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(143, 23);
            this.addressBox.TabIndex = 62;
            // 
            // customerNameBox
            // 
            this.customerNameBox.Location = new System.Drawing.Point(574, 88);
            this.customerNameBox.Name = "customerNameBox";
            this.customerNameBox.Size = new System.Drawing.Size(143, 23);
            this.customerNameBox.TabIndex = 61;
            this.customerNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customerNameBox_KeyDown);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(133, 88);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(143, 23);
            this.idBox.TabIndex = 60;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(463, 144);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(49, 15);
            this.label.TabIndex = 59;
            this.label.Text = "Address";
            // 
            // customer
            // 
            this.customer.AutoSize = true;
            this.customer.Location = new System.Drawing.Point(463, 91);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(91, 15);
            this.customer.TabIndex = 58;
            this.customer.Text = "CustomerName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Date of Birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 55;
            this.label2.Text = "CustomerID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(246, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 28);
            this.label1.TabIndex = 54;
            this.label1.Text = "CUSTOMER MANAGEMENT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 635);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.femaleButton);
            this.Controls.Add(this.maleButton);
            this.Controls.Add(this.dataProduct);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.customerNameBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton femaleButton;
        private System.Windows.Forms.RadioButton maleButton;
        private System.Windows.Forms.DataGridView dataProduct;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox customerNameBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label customer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
