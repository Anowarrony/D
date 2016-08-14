using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{
 
    public partial class SessionAddViewWindow : Window
    {
        public SessionAddViewWindow()
        {
            InitializeComponent();
        }

        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private void SessionTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (SessionTextBox.Text)
            {
                case "":
                    ErrorImage.Visibility = Visibility.Visible;
                    SessionErrorMessageLabel.Content = "Required";
                    break;
                default:
                    ErrorImage.Visibility = Visibility.Hidden;
                    SessionErrorMessageLabel.Content = "";
                    break;
            }
        }

        private void SessionAddButton_OnClick(object sender, RoutedEventArgs e)
        {
            switch (SessionTextBox.Text)
            {
                case "":
                    ErrorImage.Visibility = Visibility.Visible;
                    SessionErrorMessageLabel.Content = "Required";
                    break;
            }
            if (SessionTextBox.Text != "")
            {
                ErrorImage.Visibility = Visibility.Hidden;
                SessionErrorMessageLabel.Content = "";


                try
                {
                    var checkIsSessionExist =
                        _db.Sessions.Any(m => m.Session1.Equals(SessionTextBox.Text));
                    if (!checkIsSessionExist)
                    {
                        var session = new Session { Session1 = SessionTextBox.Text };
                        _db.Sessions.Add(session);
                        _db.SaveChanges();
                        SessionDataGrid.ColumnWidth = 249;
                        SessionDataGrid.ItemsSource = _db.Sessions.ToList();
                        SessionTextBox.Text = "";
                        MessageBox.Show("New Department has been added successfully.", "", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        ErrorImage.Visibility = Visibility.Visible;
                        SessionErrorMessageLabel.Content = "Session already exist";
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void SessionDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to delete this session parmanently?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;
                var obj = (Session)SessionDataGrid.SelectedItems[0];


                var sessionDeleteId = obj.SessionId;

                var session = _db.Sessions.Find(sessionDeleteId);

                _db.Entry(session).State = EntityState.Deleted;
                _db.SaveChanges();
                SessionDataGrid.ColumnWidth = 249;
                SessionDataGrid.ItemsSource = _db.Sessions.ToList();
                MessageBox.Show("Session has been  Deleted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);



            }
            catch (Exception mss)
            {

                MessageBox.Show("Sorry,No Data to Delete", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

  


        private void SessionAddViewWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ErrorImage.Visibility = Visibility.Hidden;
            //SessionDataGrid.Width = 420;
            //SessionDataGrid.ColumnWidth = 310;


            SessionDataGrid.ItemsSource = _db.Sessions.ToList();
        }

        private void WindowColseIcon_OnMouseLeave(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
        }

        private void WindowColseIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new HomeWindow();
            w.ShowDialog();
            this.Close();
        }

        private void WindowColseIcon_OnMouseEnter(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source = new BitmapImage(new Uri("/Images/CloseIconb.png", UriKind.Relative));
        }
    }
}
