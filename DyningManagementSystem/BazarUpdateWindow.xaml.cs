using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace DyningManagementSystem
{
  
    public partial class BazarUpdateWindow : Window
    {
        public BazarUpdateWindow(int updateId, string date, int taka, string name, int item = 0)
        {
            InitializeComponent();
            InitializeComponent();
            ItemLabel.Content = item;
            IdLabel.Content = updateId;
            DateTextBox.Text = date;
            NameTextBox.Text = name;
            TakaTextBox.Text = taka.ToString(CultureInfo.InvariantCulture);
            ItemLabel.Visibility = Visibility.Hidden;
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private void DateTextBox_OnCalendarClosed(object sender, RoutedEventArgs e)
        {
            DateErrorLabel.Content = DateTextBox.Text=="" ? "* Required!" : "";
        }

        private void NameTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            NameErrorLabel.Content = NameTextBox.Text=="" ? "* Required!" : "";
        }

        private void TakaTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {

            var objRegex = new Regex(@"^\d+$");
            if (TakaTextBox.Text == string.Empty)
            {
                TakaErrorLabel.Content = "* Required!";
            }
            if (TakaTextBox.Text != string.Empty)
            {
                TakaErrorLabel.Content = !objRegex.IsMatch(TakaTextBox.Text) ? "* Invalid!" : "";
            }
        }

        private void BazarUpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DateTextBox.Text == "" || NameTextBox.Text == "" || TakaTextBox.Text == "") return;
            var bazar = new Bazar();

            var id = Convert.ToInt32(IdLabel.Content);
            bazar = _db.Bazars.Single(m => m.Id.Equals(id));
            bazar.Date = DateTextBox.Text;
            bazar.Name = NameTextBox.Text;
            bazar.Taka = Convert.ToInt32(TakaTextBox.Text);
            _db.Entry(bazar).State = EntityState.Modified;
            _db.SaveChanges();
            MessageBox.Show("Bazar Updated Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
          
            this.Hide();
           // var w = new BazarAddWindow(Convert.ToInt32(ItemLabel.Content));
            var w = new BazarAddWindow("Update");
            w.ShowDialog();
            this.Close();
        }
    }
}
