using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loggin
{
    public partial class loginform : Form
    {
        private SqlConnection connection;
        private const string ConnectionString = "Server=ADMIN-PC\\SQLEXPRESS01; Database=userdatabase; Integrated Security=true;";

        public loginform()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=ADMIN-PC\\SQLEXPRESS01;Database=userdatabase;Integrated Security=true;");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful with Admin rights!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form viewProduct = new Form();
                viewProduct.Show();

                this.Close();
            }
            else if (username == "user" && password == "password")
            {
                MessageBox.Show("Login successful with User rights!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form userForm = new Form();
                userForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (Application.OpenForms[0] == this)
                {
                    Application.Exit();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}