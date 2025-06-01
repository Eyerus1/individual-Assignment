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
using System.Configuration; 

namespace Library 
{
    public partial class LoginForm : Form
    {
        private string connectionString;

        public LoginForm()
        {
            InitializeComponent();
            try
            {
                if (ConfigurationManager.ConnectionStrings["LibraryDBConnection"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnection"].ConnectionString;
                }
                else
                {
                    MessageBox.Show("Database connection string 'LibraryDBConnection' not found in App.config.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading database configuration: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                lblError.Text = "Application not configured for database connection.";
                return;
            }
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide(); 
                            MainForm mainForm = new MainForm();
                            mainForm.ShowDialog(); 
                            this.Close(); 
                        }
                        else
                        {
                            lblError.Text = "Invalid username or password.";
                        }
                    }
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show("Database error: " + ex.Message + "\n\nCheck your connection string and database setup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
