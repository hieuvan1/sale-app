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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


namespace WindowsFormsApp1
{
    public partial class ViewProduct : Form
    { SqlConnection connection;
        public ViewProduct()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=ADMIN-PC\\SQLEXPRESS01;Database=product_management;Integrated Security=true;");

        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = this.dgvProduct.Rows[e.RowIndex];

                int productId;

                if (int.TryParse(row.Cells["ProductID"].Value.ToString(), out productId))
                {
                    txtID.Text = productId.ToString();
                    txtName.Text = row.Cells["ProductName"].Value.ToString();
                    txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                    cbCategory.SelectedValue = row.Cells["CategoryID"].Value.ToString();
                }
                else
                {
                    MessageBox.Show(this, "Invalid Product ID format. Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            ClearInputs();

            dgvProduct.ClearSelection();

            lblIDError.Text = string.Empty;
            lblNameError.Text = string.Empty;
            lblQuantityError.Text = string.Empty;

            txtName.Text = "";
            txtID.Text = "";
            txtQuantity.Text = "";
            cbCategory.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int error = 0;
            string id = txtID.Text;
            if (id.Equals(""))
            {
                error++;
                lblIDError.Text = "ID can't be blank";
            }
            else
            {
                lblIDError.Text = "";
            }

            string name = txtName.Text;
            if (name.Equals(""))
            {
                error++;
                lblNameError.Text = "Name can't be blank";
            }
            else
            {
                lblNameError.Text = "";
            }

            string quantity = txtQuantity.Text;
            if (quantity.Equals(""))
            {
                error++;
                lblQuantityError.Text = "Quantity can't be blank";
            }
            else
            {
                lblQuantityError.Text = "";
            }

            if (error == 0)
            {
                try
                {
                    string query = "SELECT * FROM product WHERE product_id = @id";
                    connection.Open();
                    SqlCommand cmdCheck = new SqlCommand(query, connection);
                    cmdCheck.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(id);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    if (reader.Read())
                    {
                        error++;
                        MessageBox.Show(this, " This ID already exists, please choose another.", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                        reader.Close();
                        connection.Close();
                    }
                   
                    else
                    {
                        reader.Close();
                        connection.Close();

                        string catid = cbCategory.SelectedValue.ToString();
                        string insert = "INSERT INTO product VALUES (@id, @name, @quantity, @catid)";
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(insert, connection);
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(id);
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = int.Parse(quantity);
                        cmd.Parameters.Add("@catid", SqlDbType.Int).Value = int.Parse(catid);
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        FillData();
                        MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }



                }

                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                
            }
            
        }
        public void FillData()
        {
            string query = "SELECT * FROM dbo.product";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvProduct.DataSource = tbl;
            connection.Close();
        }
        public void GetCategories()
        {
            string query = "select category_id,category_name from category";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);
            cbCategory.DataSource = table;
            cbCategory.DisplayMember = "category_name";
            cbCategory.ValueMember = "category_id";
        }
        private void ClearInputs()
        {
            txtID.Text = string.Empty;
            txtID.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            cbCategory.SelectedIndex = -1;
            lblIDError.Text = string.Empty;
            lblNameError.Text = string.Empty;
            lblQuantityError.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "UPDATE product SET product_name = @name, quantity = @quantity WHERE product_id = @productid";

                connection.Open();

                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = Convert.ToInt32(txtQuantity.Text);
                cmd.Parameters.Add("@productid", SqlDbType.Int).Value = Convert.ToInt32(txtID.Text);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    FillData(); 
                    MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Update failed", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvProduct.SelectedRows[0].Index;
                int productId = Convert.ToInt32(dgvProduct.Rows[selectedRowIndex].Cells["Product_id"].Value);

                if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        string delete = "DELETE FROM product WHERE product_id = @productid";

                        SqlCommand cmd = new SqlCommand(delete, connection);
                        cmd.Parameters.Add("@productid", SqlDbType.Int).Value = productId;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            FillData(); 
                            MessageBox.Show(this, "Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Delete failed. Product not found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
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

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataIntoDataGridView();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var value = dgvOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                MessageBox.Show($"You clicked on: {value.ToString()}");
            }
        }
          private void LoadDataIntoDataGridView()
    {
        string query = "SELECT * FROM dbo.product";

        using (SqlConnection connection = new SqlConnection("Server=ADMIN-PC\\SQLEXPRESS01;Database=product_management;Integrated Security=true;"))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();

                dataAdapter.Fill(dataTable);

                dgvOrder.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
    }
   
}
