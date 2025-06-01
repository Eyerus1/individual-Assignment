using System;
using System.Configuration; // Required for ConfigurationManager
using System.Data.SqlClient; // Required for SQL database operations
using System.Windows.Forms; // Potentially for MessageBox if you want to show errors directly from helper

namespace Library // Make sure this matches your project's namespace
{
    public static class DatabaseHelper
    {
        // Property to get the connection string from App.config
        private static string GetConnectionString()
        {
            // Ensure "LibraryDBConnection" matches the name in your App.config
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'LibraryDBConnection' not found or is empty in App.config.");
            }
            return connectionString;
        }

        /// <summary>
        /// Authenticates a user against the Users table in the database.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if the user is authenticated, false otherwise.</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            string connectionString = GetConnectionString(); // Get the connection string

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    // Console.WriteLine("Database connection opened successfully from DatabaseHelper!"); // Optional: for debugging

                    // Use parameterized query to prevent SQL Injection
                    string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        // IMPORTANT: For real-world applications, never store or compare plain text passwords.
                        // Always hash and salt passwords before storing them, and then hash the user's
                        // input password for comparison.
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count == 1; // Returns true if a matching user is found
                    }
                }
                catch (SqlException ex)
                {
                    // Log the exception (e.g., to a file or Console) and show a user-friendly message
                    Console.WriteLine($"SQL Error in AuthenticateUser: {ex.Message}");
                    MessageBox.Show($"Database error during login: {ex.Message}\nPlease contact support.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (InvalidOperationException ex)
                {
                    // Handle cases where the connection string is missing/empty
                    Console.WriteLine($"Configuration Error: {ex.Message}");
                    MessageBox.Show($"Application configuration error: {ex.Message}\nMake sure App.config is set up correctly.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    // Catch any other unexpected errors
                    Console.WriteLine($"An unexpected error occurred in AuthenticateUser: {ex.Message}");
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // You can add more database-related methods here, e.g., for
        // registering new users, managing books, etc.
        // public static void AddNewBook(string title, string author) { ... }
    }
}
