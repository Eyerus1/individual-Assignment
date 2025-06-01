using Librarye;
using System;
using System.Configuration; 
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;


namespace Library 
{
    public partial class MainForm : Form
    {
        private string connectionString;

        public MainForm()
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
                  
                    this.tabControlMain.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading database configuration: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabControlMain.Enabled = false; // Disable if config fails to load
            }

            this.Load += MainForm_Load;
            this.tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
        }

        /// <summary>
        /// Handles the loading of the main form.
        /// Loads initial data into the DataGridViews.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadBorrowers();
            LoadIssuedBooks(); 
            LoadOverdueBooks(); 
        }

        /// <summary>
        /// Handles tab selection changes to refresh data if needed.
        /// </summary>
        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageBooks)
            {
                LoadBooks();
            }
            else if (tabControlMain.SelectedTab == tabPageBorrowers)
            {
                LoadBorrowers();
                LoadIssuedBooks(); 
            }
            else if (tabControlMain.SelectedTab == tabPageIssuedBooks)
            {
                LoadIssuedBooks();
            }
            else if (tabControlMain.SelectedTab == tabPageOverdueBooks)
            {
                LoadOverdueBooks();
            }
        }

        /// <summary>
        /// Loads book data from the database into the dgvBooks DataGridView.
        /// Includes optional parameters for filtering by author and year range.
        /// </summary>
        private void LoadBooks(string filterAuthor = null, int? filterYearMin = null, int? filterYearMax = null)
        {
            if (string.IsNullOrEmpty(connectionString)) return; 

            string query = "SELECT BookID, Title, Author, Year, AvailableCopies FROM Books";
            string whereClause = "";
            SqlCommand command = null;
            if (!string.IsNullOrWhiteSpace(filterAuthor))
            {
                whereClause += " WHERE Author LIKE @Author";
            }
            if (filterYearMin.HasValue && filterYearMax.HasValue)
            {
                if (string.IsNullOrWhiteSpace(whereClause))
                    whereClause += " WHERE ";
                else
                    whereClause += " AND ";
                whereClause += " Year BETWEEN @YearMin AND @YearMax";
            }
            query += whereClause;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    command = new SqlCommand(query, connection);
                    if (!string.IsNullOrWhiteSpace(filterAuthor))
                    {
                        command.Parameters.AddWithValue("@Author", "%" + filterAuthor + "%");
                    }
                    if (filterYearMin.HasValue && filterYearMax.HasValue)
                    {
                        command.Parameters.AddWithValue("@YearMin", filterYearMin.Value);
                        command.Parameters.AddWithValue("@YearMax", filterYearMax.Value);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dtBooks = new DataTable();
                    connection.Open();
                    adapter.Fill(dtBooks);
                    dgvBooks.DataSource = dtBooks;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads borrower data from the database into the dgvBorrowers DataGridView.
        /// </summary>
        private void LoadBorrowers()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            string query = "SELECT BorrowerID, Name, Email, Phone FROM Borrowers";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtBorrowers = new DataTable();
                    connection.Open();
                    adapter.Fill(dtBorrowers);
                    dgvBorrowers.DataSource = dtBorrowers;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading borrowers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading borrowers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads currently issued book records from the database.
        /// </summary>
        private void LoadIssuedBooks()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            string query = @"
                SELECT
                    ib.IssueID,
                    b.Title AS BookTitle,
                    br.Name AS BorrowerName,
                    ib.IssueDate,
                    ib.DueDate,
                    ib.ReturnDate,
                    ib.BookID -- Keep BookID for return operation
                FROM IssuedBooks ib
                JOIN Books b ON ib.BookID = b.BookID
                JOIN Borrowers br ON ib.BorrowerID = br.BorrowerID
                WHERE ib.ReturnDate IS NULL"; // Only show currently issued books
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtIssuedBooks = new DataTable();
                    connection.Open();
                    adapter.Fill(dtIssuedBooks);
                    dgvIssuedBooks.DataSource = dtIssuedBooks; // Assuming you have a dgvIssuedBooks
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading issued books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading issued books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads overdue book records from the database.
        /// </summary>
        private void LoadOverdueBooks()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            string query = @"
                SELECT
                    ib.IssueID,
                    b.Title AS BookTitle,
                    br.Name AS BorrowerName,
                    ib.IssueDate,
                    ib.DueDate
                FROM IssuedBooks ib
                JOIN Books b ON ib.BookID = b.BookID
                JOIN Borrowers br ON ib.BorrowerID = br.BorrowerID
                WHERE ib.DueDate < GETDATE() AND ib.ReturnDate IS NULL"; // Overdue and not yet returned
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtOverdueBooks = new DataTable();
                    connection.Open();
                    adapter.Fill(dtOverdueBooks);
                    dgvOverdueBooks.DataSource = dtOverdueBooks; // Assuming a dgv for overdue books
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading overdue books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading overdue books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- Book Management Event Handlers ---

        /// <summary>
        /// Handles the click event for the "Add Book" button.
        /// Opens the BookDetailsForm in add mode.
        /// </summary>
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BookDetailsForm bookForm = new BookDetailsForm(); // No BookID passed for add mode
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks(); // Refresh the books list after a new book is added
            }
        }

        /// <summary>
        /// Handles the click event for the "Edit Book" button.
        /// Opens the BookDetailsForm in edit mode with selected book's data.
        /// </summary>
        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null)
            {
                int bookId = Convert.ToInt32(dgvBooks.CurrentRow.Cells["BookID"].Value);
                BookDetailsForm bookForm = new BookDetailsForm(bookId); // Pass BookID to load existing data
                if (bookForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the click event for the "Delete Book" button.
        /// Prompts for confirmation and deletes the selected book.
        /// </summary>
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null)
            {
                int bookId = Convert.ToInt32(dgvBooks.CurrentRow.Cells["BookID"].Value);
                string title = dgvBooks.CurrentRow.Cells["Title"].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete '{title}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Books WHERE BookID = @BookID";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BookID", bookId);
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadBooks(); 
                                }
                                else
                                {
                                    MessageBox.Show("Book not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the click event for the "Apply Filter" button for books.
        /// Reloads books with the specified author and year range filters.
        /// </summary>
        private void btnFilterBooks_Click(object sender, EventArgs e)
        {
            string authorFilter = txtFilterAuthor.Text.Trim();
            int? minYear = null;
            int? maxYear = null;
            if (!string.IsNullOrWhiteSpace(txtFilterMinYear.Text))
            {
                if (int.TryParse(txtFilterMinYear.Text, out int parsedMinYear))
                {
                    minYear = parsedMinYear;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for Min Year.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtFilterMaxYear.Text))
            {
                if (int.TryParse(txtFilterMaxYear.Text, out int parsedMaxYear))
                {
                    maxYear = parsedMaxYear;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for Max Year.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (minYear.HasValue && maxYear.HasValue && minYear > maxYear)
            {
                MessageBox.Show("Min Year cannot be greater than Max Year.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadBooks(authorFilter, minYear, maxYear);
        }
        /// <summary>
        /// Handles the click event for the "Add Borrower" button.
        /// Opens the BorrowerDetailsForm in add mode.
        /// </summary>
        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            BorrowerDetailsForm borrowerForm = new BorrowerDetailsForm(); 
            if (borrowerForm.ShowDialog() == DialogResult.OK)
            {
                LoadBorrowers(); 
            }
        }

        /// <summary>
        /// Handles the click event for the "Edit Borrower" button.
        /// Opens the BorrowerDetailsForm in edit mode with selected borrower's data.
        /// </summary>
        private void btnEditBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.CurrentRow != null)
            {
                int borrowerId = Convert.ToInt32(dgvBorrowers.CurrentRow.Cells["BorrowerID"].Value);
                BorrowerDetailsForm borrowerForm = new BorrowerDetailsForm(borrowerId); 
                if (borrowerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBorrowers(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a borrower to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the click event for the "Delete Borrower" button.
        /// Prompts for confirmation and deletes the selected borrower.
        /// </summary>
        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.CurrentRow != null)
            {
                int borrowerId = Convert.ToInt32(dgvBorrowers.CurrentRow.Cells["BorrowerID"].Value);
                string name = dgvBorrowers.CurrentRow.Cells["Name"].ToString();
                string checkIssuedBooksQuery = "SELECT COUNT(*) FROM IssuedBooks WHERE BorrowerID = @BorrowerID AND ReturnDate IS NULL";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(checkIssuedBooksQuery, connection))
                        {
                            command.Parameters.AddWithValue("@BorrowerID", borrowerId);
                            connection.Open();
                            int outstandingBooks = (int)command.ExecuteScalar();

                            if (outstandingBooks > 0)
                            {
                                MessageBox.Show("This borrower has outstanding books and cannot be deleted.", "Deletion Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; 
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error checking outstanding books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete '{name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Borrowers WHERE BorrowerID = @BorrowerID";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BorrowerID", borrowerId);
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Borrower deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadBorrowers(); 
                                }
                                else
                                {
                                    MessageBox.Show("Borrower not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting borrower: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a borrower to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the click event for the "Issue Book" button.
        /// Opens the IssueBookForm to select a book and issue it to the selected borrower.
        /// </summary>
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.CurrentRow == null)
            {
                MessageBox.Show("Please select a borrower first.", "No Borrower Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int borrowerId = Convert.ToInt32(dgvBorrowers.CurrentRow.Cells["BorrowerID"].Value);
            string borrowerName = dgvBorrowers.CurrentRow.Cells["Name"].ToString();
            IssueBookForm issueForm = new IssueBookForm(borrowerId, borrowerName);
            if (issueForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks(); 
                LoadIssuedBooks(); 
            }
        }

        /// <summary>
        /// Handles the click event for the "Return Book" button.
        /// Marks the selected issued book as returned and increments available copies.
        /// </summary>
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvIssuedBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select an issued book to return.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int issueId = Convert.ToInt32(dgvIssuedBooks.CurrentRow.Cells["IssueID"].Value);
            int bookId = Convert.ToInt32(dgvIssuedBooks.CurrentRow.Cells["BookID"].Value);
            string bookTitle = dgvIssuedBooks.CurrentRow.Cells["BookTitle"].ToString();

            if (MessageBox.Show($"Are you sure you want to return '{bookTitle}'?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction(); // Start transaction for atomicity
                    try
                    {
                        string updateBookQuery = "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = @BookID";
                        using (SqlCommand updateBookCommand = new SqlCommand(updateBookQuery, connection, transaction))
                        {
                            updateBookCommand.Parameters.AddWithValue("@BookID", bookId);
                            updateBookCommand.ExecuteNonQuery();
                        }
                        string updateIssueQuery = "UPDATE IssuedBooks SET ReturnDate = GETDATE() WHERE IssueID = @IssueID";
                        using (SqlCommand updateIssueCommand = new SqlCommand(updateIssueQuery, connection, transaction))
                        {
                            updateIssueCommand.Parameters.AddWithValue("@IssueID", issueId);
                            updateIssueCommand.ExecuteNonQuery();
                        }

                        transaction.Commit(); 
                        MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadIssuedBooks(); 
                        LoadBooks(); 
                        LoadOverdueBooks(); 
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback(); 
                        MessageBox.Show("Database error returning book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); 
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}