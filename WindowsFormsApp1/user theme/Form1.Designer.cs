namespace user_theme
{
    partial class UserForm
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
            this.dgvuser = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmailError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameuser = new System.Windows.Forms.TextBox();
            this.txtNAMEerror = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvuser
            // 
            this.dgvuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvuser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_id,
            this.Product_name,
            this.Quantity,
            this.category_id});
            this.dgvuser.Location = new System.Drawing.Point(1, 301);
            this.dgvuser.Name = "dgvuser";
            this.dgvuser.RowHeadersWidth = 51;
            this.dgvuser.RowTemplate.Height = 24;
            this.dgvuser.Size = new System.Drawing.Size(680, 201);
            this.dgvuser.TabIndex = 0;
            this.dgvuser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // order
            // 
            this.order.Location = new System.Drawing.Point(90, 60);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(75, 23);
            this.order.TabIndex = 1;
            this.order.Text = "order";
            this.order.UseVisualStyleBackColor = true;
            this.order.Click += new System.EventHandler(this.order_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(547, 61);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(247, 22);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Text = "email";
            // 
            // txtEmailError
            // 
            this.txtEmailError.AutoSize = true;
            this.txtEmailError.Location = new System.Drawing.Point(637, 86);
            this.txtEmailError.Name = "txtEmailError";
            this.txtEmailError.Size = new System.Drawing.Size(10, 16);
            this.txtEmailError.TabIndex = 5;
            this.txtEmailError.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "name";
            // 
            // txtNameuser
            // 
            this.txtNameuser.Location = new System.Drawing.Point(547, 164);
            this.txtNameuser.Name = "txtNameuser";
            this.txtNameuser.Size = new System.Drawing.Size(247, 22);
            this.txtNameuser.TabIndex = 7;
            this.txtNameuser.Text = "username";
            this.txtNameuser.TextChanged += new System.EventHandler(this.txtNameuser_TextChanged);
            // 
            // txtNAMEerror
            // 
            this.txtNAMEerror.AutoSize = true;
            this.txtNAMEerror.Location = new System.Drawing.Point(637, 218);
            this.txtNAMEerror.Name = "txtNAMEerror";
            this.txtNAMEerror.Size = new System.Drawing.Size(10, 16);
            this.txtNAMEerror.TabIndex = 8;
            this.txtNAMEerror.Text = " ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Product_id
            // 
            this.Product_id.DataPropertyName = "Product_id";
            this.Product_id.HeaderText = "Product_id";
            this.Product_id.MinimumWidth = 6;
            this.Product_id.Name = "Product_id";
            this.Product_id.Width = 125;
            // 
            // Product_name
            // 
            this.Product_name.DataPropertyName = "Product_name";
            this.Product_name.HeaderText = "Product_name";
            this.Product_name.MinimumWidth = 6;
            this.Product_name.Name = "Product_name";
            this.Product_name.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // category_id
            // 
            this.category_id.DataPropertyName = "category_id";
            this.category_id.HeaderText = "category_id";
            this.category_id.MinimumWidth = 6;
            this.category_id.Name = "category_id";
            this.category_id.Width = 125;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 541);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNAMEerror);
            this.Controls.Add(this.txtNameuser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmailError);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.order);
            this.Controls.Add(this.dgvuser);
            this.Name = "UserForm";
            this.Text = "user";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvuser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvuser;
        private System.Windows.Forms.Button order;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label txtEmailError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameuser;
        private System.Windows.Forms.Label txtNAMEerror;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
    }
}

