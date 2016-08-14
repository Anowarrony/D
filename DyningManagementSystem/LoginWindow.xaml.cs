
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{
 
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
   
        private void SetLoginTime()
        {
            var obj = _db.Logins.Single(x => x.name == UsernameTextBox.Text);
            obj.LoginTime = DateTime.Now;
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();

        }

        private void UsernameTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {

            UserNameLabel.Content = "";

            if (UsernameTextBox.Text == string.Empty)
            {

                UserNameLabel.Content = "* Required ";

            }
        }

        private void PasswordTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            UserPasswordLabel.Content = "";

            if (PasswordTextBox.Password == string.Empty)
            {

                UserPasswordLabel.Content = "* Required ";

            }

        }
        private void LoginWindow_OnLoaded(object sender, RoutedEventArgs e)
        {            
            UserNameLabel.Content = "";
            UserPasswordLabel.Content = "";
            LoginWindowCloseIconImgBox.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
        }

    
        private void LoginWindowCloseIconImgBox_OnMouseEnter(object sender, MouseEventArgs e)
        {
            LoginWindowCloseIconImgBox.Source = new BitmapImage(new Uri("/Images/CloseIconb.png", UriKind.Relative));
        }

        private void LoginWindowCloseIconImgBox_OnMouseLeave(object sender, MouseEventArgs e)
        {
            LoginWindowCloseIconImgBox.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
        }

        private void LoginWindowCloseIconImgBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == string.Empty)
            {
                UserNameLabel.Content = "* Required!";
            }

            if (PasswordTextBox.Password == string.Empty)
            {
                UserPasswordLabel.Content = "* Required!";
            }
            if (UsernameTextBox.Text != string.Empty)
            {

                UserNameLabel.Content = "";
            }
            if (PasswordTextBox.Password != string.Empty)
            {
                UserPasswordLabel.Content = "";
            }

            if (UsernameTextBox.Text == string.Empty || PasswordTextBox.Password == string.Empty) return;
            var objAllogin = new Login
            {
                name = UsernameTextBox.Text,
                password = PasswordTextBox.Password
            };

            var u =
                _db.Logins.SingleOrDefault(user => user.name.Equals(objAllogin.name) && user.password.Equals(objAllogin.password));
            if (u != null)
            {
                SetLoginTime();           
                var w = new HomeWindow();
                w.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Login failed.Invalid Username and Password combination", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
        
      
        }

        private void LoginButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
        }
    }
}
