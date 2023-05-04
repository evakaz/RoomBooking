using System.Data.SqlClient;
using System.Windows;
using app;


namespace app
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=vhk-12r.database.windows.net;Database=Hamburger;User Id=user2;Password=7GkpG5Us;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            string query = "SELECT * FROM dbo.Users WHERE Username = @Username AND Password = @Password;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        this.Close();
                        BookRoomWindow window = new BookRoomWindow();
                        window.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
