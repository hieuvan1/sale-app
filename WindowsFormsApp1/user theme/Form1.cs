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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace user_theme
{
    public partial class UserForm : Form
    {

        private SqlConnection connection;
        public UserForm()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=ADMIN-PC\\SQLEXPRESS01;Database=userdatabase;Integrated Security=true;");
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            FillData();
            GetCategories();
            try
            {
                connection.Open();
                MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvuser.Rows[e.RowIndex];

                int productId;

                if (int.TryParse(row.Cells["ProductID"].Value.ToString(), out productId))
                {

                }
                else
                {
                    MessageBox.Show(this, "Invalid Product ID format. Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void FillData()
        {
            string query = "SELECT * FROM dbo.product";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvuser.DataSource = tbl;
            connection.Close();
        }
        public void GetCategories()
        {
            string query = "select category_id,category_name from category";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);

        }

        private void order_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string usernameText = txtNameuser.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                txtEmailError.Text = "Email can't be blank";
                return;
            }
            if (string.IsNullOrEmpty(usernameText))
            {
                txtNAMEerror.Text = "Username can't be blank";
                return;
            }
            if (int.TryParse(usernameText, out int username))
            {
                MessageBox.Show("Invalid Username value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dgvuser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Do you want to order?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            string connectionString = "Server=ADMIN-PC\\SQLEXPRESS01;Database=userdatabase;User Id=your_username;Password=your_password;";
            string updateQuery = "UPDATE [order] SET Email = @Email WHERE Username = @Username";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            rowsAffected > 0 ? "Order updated successfully." : "No records were updated.",
                            rowsAffected > 0 ? "Success" : "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtEmail.Text = string.Empty;
            txtNameuser.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

           
        }

        private void txtNameuser_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
