using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DyningManagementSystem
{  
    
 
    public partial class BazarAddWindow : Window
    {
        public BazarAddWindow(int item = 0)
        {
           
            InitializeComponent();
            if (item != 0)
            {
                ItemTextBox.Text = item.ToString(CultureInfo.InvariantCulture);

            }
           
        }
        public BazarAddWindow(string operation )
        {

            InitializeComponent();
            _redirectedOperation = operation;

        }

        private string _redirectedOperation;
        public static int NTotalRow;    //total rows for next button
        public static int PTotalRow;    //total rows for previous button
        public static int NSkippedRows; //the steps for skkiping rows for next button
        public static int PSkippedRows; //the steps for skkiping rows for previous button
        public static int Total;
        private int _row;
        private int _item;
     
        readonly DyningManagementDbContext _db=new DyningManagementDbContext();
        private void BazarAddDatePicker_OnCalendarClosed(object sender, RoutedEventArgs e)
        {

            if (BazarAddDatePicker.Text != string.Empty)
            {
                DateLabel.Content = "";
            }
        }
        private void LoadBazarGrid()
        {
            LabelPageNo_Copy.Visibility = Visibility.Hidden;
            ItemTextBox.Visibility = Visibility.Hidden;
            PreviousButton.IsEnabled = false;
            var u = _db.Bazars.ToList();
            NTotalRow = u.Count();
            PTotalRow = u.Count();
            Total = u.Count();
            if (NTotalRow <= _row)
            {
                BazarDataGrid.ItemsSource = u;
            }
            else if (NTotalRow > _row)
            {
                NSkippedRows = _row;
                BazarDataGrid.ItemsSource = _db.Bazars.ToList().Take(NSkippedRows);
                NTotalRow = NTotalRow - NSkippedRows;
                NextButton.IsEnabled = true;
            }



        }

        private void BazarAddNameTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {

            NameLabel.Content = BazarAddNameTextBox.Text != string.Empty ? "" : "* Required!";
        }

        private void BazarAddTakaTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            var objRegex = new Regex(@"^\d+$");
            if (BazarAddTakaTextBox.Text == string.Empty)
            {
                TakaLabel.Content = "* Required!";
            }
            if (BazarAddTakaTextBox.Text != string.Empty)
            {
                TakaLabel.Content = !objRegex.IsMatch(BazarAddTakaTextBox.Text) ? "* Invalid!" : "";
            }

        }

        private void BazarAddButton_OnClick(object sender, RoutedEventArgs e)
        {

            var objRegex = new Regex(@"^\d+$");
            var ex = new Regex(@"^[a-zA-Z'.\s]{1,40}$");
            if (BazarAddDatePicker.Text == string.Empty)
            {
                DateLabel.Content = "* Required!";
            }
            if (BazarAddDatePicker.Text != string.Empty)
            {
                DateLabel.Content = "";
            }
            if (BazarAddNameTextBox.Text == string.Empty)
            {
                NameLabel.Content = "* Required!";
            }
            if (BazarAddNameTextBox.Text != string.Empty)
            {
                NameLabel.Content = !ex.IsMatch(BazarAddNameTextBox.Text) ? "* Invalid!" : "";
            }

            if (BazarAddTakaTextBox.Text == string.Empty)
            {
                TakaLabel.Content = "* Required!";
            }
            if (BazarAddTakaTextBox.Text != string.Empty)
            {
                TakaLabel.Content = !objRegex.IsMatch(BazarAddTakaTextBox.Text) ? "* Invalid!" : "";
            }
            if (BazarAddDatePicker.Text == string.Empty || BazarAddNameTextBox.Text == string.Empty ||
                BazarAddTakaTextBox.Text == string.Empty) return;
            if (!objRegex.IsMatch(BazarAddTakaTextBox.Text) || !ex.IsMatch(BazarAddNameTextBox.Text)) return;
            try
            {
                var bazar = new Bazar
                {
                    Date = BazarAddDatePicker.Text,
                    Taka = Convert.ToInt32(BazarAddTakaTextBox.Text),
                    Name = BazarAddNameTextBox.Text
                };


                _db.Bazars.Add(bazar);
                _db.SaveChanges();
                LoadBazarGrid();
                MessageBox.Show("Bazar Added Successfully.", "", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void BazarAddWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DateLabel.Content = "";
            NameLabel.Content = "";
            TakaLabel.Content = "";
            BazarDataGrid.Visibility = Visibility.Hidden;
            if (_redirectedOperation == "AddBazar")
            {          
                this.Height = 400;        
                FirstPageButton.Visibility = Visibility.Hidden;
                NextButton.Visibility = Visibility.Hidden;
                PreviousButton.Visibility = Visibility.Hidden;
                LastPageButton.Visibility = Visibility.Hidden;
                CustomRowComboBox.Visibility = Visibility.Hidden; 
            }
            if (_redirectedOperation == "BazarDetails" || _redirectedOperation == "Update")
            {
                this.Height = 560;
                BazarAddTakaTextBox.Visibility = Visibility.Hidden;
                BazarAddNameTextBox.Visibility = Visibility.Hidden;
                BazarAddDatePicker.Visibility = Visibility.Hidden;

                BazarAddGrid.Visibility = Visibility.Hidden;
                BazarDataGrid.Visibility = Visibility.Visible;

                FirstPageButton.Visibility = Visibility.Visible;
                NextButton.Visibility = Visibility.Visible;
                PreviousButton.Visibility = Visibility.Visible;
                LastPageButton.Visibility = Visibility.Visible;
                CustomRowComboBox.Visibility = Visibility.Visible; 
            }
            _row = ItemTextBox.Text != "" ? Convert.ToInt32(ItemTextBox.Text) : 3;

            CustomRowComboBox.SelectedValuePath = _item.ToString(CultureInfo.InvariantCulture);
            LoadBazarGrid(); BazarAddGrid.Visibility = Visibility.Visible;
        }

        private void BazarDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void FirstPageButton_OnClick(object sender, RoutedEventArgs e)
        {

            LoadBazarGrid();
        }

        private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
        {


            if (((Total - PTotalRow) - _row == 0) || Total - PTotalRow == 0)
            {
                BazarDataGrid.ItemsSource = _db.Bazars.ToList().Take(_row);
                NTotalRow += _row;

                NSkippedRows -= _row;

                if (NSkippedRows == 0)
                {
                    NSkippedRows = _row;
                }

            
                PTotalRow += _row;
                PreviousButton.IsEnabled = false;
                NextButton.IsEnabled = true;
            }
            else if (Total - PTotalRow > _row)
            {



                BazarDataGrid.ItemsSource = _db.Bazars.ToList().Skip(Total - PTotalRow - _row).Take(_row);

                NextButton.IsEnabled = true;
                PTotalRow += _row;
                NTotalRow = NTotalRow + _row;
                NSkippedRows -= _row;

            }
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (NTotalRow <= _row)
            {


                BazarDataGrid.ItemsSource = _db.Bazars.ToList().Skip(NSkippedRows).Take(NTotalRow);


                PTotalRow -= _row;

                NSkippedRows += _row;
                NTotalRow -= _row;

                NextButton.IsEnabled = false;
                PreviousButton.IsEnabled = true;


            }
            else if (NTotalRow > _row)
            {


                BazarDataGrid.ItemsSource = _db.Bazars.ToList().Skip(NSkippedRows).Take(_row);


                PTotalRow -= _row;

                NTotalRow = NTotalRow - _row;
                NSkippedRows += _row;
                PreviousButton.IsEnabled = true;

            }
        }

        private void LastPageButton_OnClick(object sender, RoutedEventArgs e)
        {

            var skipeItems = Total /
                           _row;

            BazarDataGrid.ItemsSource = Total % _row == 0 ? _db.Bazars.Take(_row).OrderByDescending(m => m.Id).ToList() : _db.Bazars.ToList().Skip(skipeItems * _row);

            NextButton.IsEnabled = false;
            if (Total > _row)
            {
                PreviousButton.IsEnabled = true;
            }
        }

       
        private void CustomRowComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            _row = Convert.ToInt32(CustomRowComboBox.Text);
            _item = _row;
            LoadBazarGrid();
        }

        private void DelteButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to delete?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;
                var selectedId = (Bazar)BazarDataGrid.SelectedItems[0];
                _db.Entry(selectedId).State = EntityState.Deleted;
                _db.SaveChanges();


                MessageBox.Show("Current Record Deleted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadBazarGrid();
            }
            catch (Exception mss)
            {

                MessageBox.Show("Sorry,No Data to Delete", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

       

        private void BazarEditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var updateBazar = (Bazar)BazarDataGrid.SelectedItems[0];
                var id = updateBazar.Id;
                var date = updateBazar.Date;
                if (false) return;
                var taka = updateBazar.Taka;
                var name = updateBazar.Name;
      



                this.Hide();
                var w = new BazarUpdateWindow(id, date, taka, name, _row);
                w.ShowDialog();
                this.Close();
            }
            catch (Exception mss)
            {

                MessageBox.Show("Sorry,No Data to Update", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

      

     

        private void WindowColseIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
            var w = new HomeWindow();
            w.ShowDialog();
            Close();
        }

        private void WindowColseIcon_OnMouseLeave(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
       
        }

        private void WindowColseIcon_OnMouseEnter(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source = new BitmapImage(new Uri("/Images/CloseIconb.png", UriKind.Relative));
       
        }
    }
}
