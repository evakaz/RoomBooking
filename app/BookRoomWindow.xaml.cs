using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows;

namespace app
{
    public partial class BookRoomWindow : INotifyPropertyChanged
    {
        private ObservableCollection<Room> _availableRooms;

        public ObservableCollection<Room> AvailableRooms
        {
            get { return _availableRooms; }
            set
            {
                _availableRooms = value;
                OnPropertyChanged(nameof(AvailableRooms));
            }
        }

        public BookRoomWindow()
        {
            InitializeComponent();
            string connectionString = "Server=vhk-12r.database.windows.net;Database=Hamburger;User Id=user2;Password=7GkpG5Us;";
            string queryString = "SELECT number FROM dbo.ruumid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ObservableCollection<Room> rooms = new ObservableCollection<Room>();
                while (reader.Read())
                {
                    Room room = new Room
                    {
                        Number = reader.GetInt32(0)
                    };
                    rooms.Add(room);
                }
                AvailableRooms = rooms;
            }
        }

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Room
    {
        public int Number { get; set; }
    }
}
