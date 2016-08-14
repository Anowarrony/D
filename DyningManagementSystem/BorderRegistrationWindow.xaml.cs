using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace DyningManagementSystem
{
  
    public partial class BorderRegistrationWindow : Window
    {
        public BorderRegistrationWindow()
        {
            InitializeComponent();
        }

        readonly DyningManagementDbContext _db = new DyningManagementDbContext();

        readonly Regex _ex = new Regex(@"^[a-zA-Z'.\s]{1,40}$");



     
        readonly OpenFileDialog _op = new OpenFileDialog();
        private void RegIdTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            ReIdLabel.Content = RegIdTextBox.Text == string.Empty ? "* Required" : "";
        }

        private void RegNameTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {

            if (RegNameTextBox.Text != string.Empty)
            {
                if (_ex.IsMatch(RegNameTextBox.Text))
                {
                    RegNameLabel.Content = "";
                }
                if (!_ex.IsMatch(RegNameTextBox.Text))
                {
                    RegNameLabel.Content = "* Invalid";
                }

            }
            if (RegNameTextBox.Text == string.Empty)
            {

                RegNameLabel.Content = "* Required";
            }
        }


        private void RegDeptComboBox_OnDropDownClosed(object sender, EventArgs e)
        {

            try
            {
                RegDeptLabel.Content = RegDeptComboBox.Text != string.Empty ? "" : "* Required";
       
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RegSessionComboBox_OnDropDownClosed(object sender, EventArgs e)
        {

            try
            {
                RegSessionLabel.Content = RegSessionComboBox.Text != string.Empty ? "" : "* Required";
        
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RegFloorComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            try
            {
                RegFloorLabel.Content = RegFloorComboBox.Text != string.Empty ? "" : "* Required";
                RegRoomNoComboBox.Items.Clear();

                var selectedValue = RegFloorComboBox.SelectedItem.ToString();
                var v = _db.Floors.SingleOrDefault(m => m.Floor1.Equals(selectedValue));
                if (v == null) return;
                var getFloorId = v.FloorId;
                var getRoomList = _db.Rooms.Where(m => m.FloorId.Equals(getFloorId)).Select(m => m.Room1);
                foreach (var i in getRoomList)
                {
                    RegRoomNoComboBox.Items.Add(i);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void RegRoomNoComboBox_OnDropDownClosed(object sender, EventArgs e)
        {

            try
            {
                RegRoomLabel.Content = RegRoomNoComboBox.Text != string.Empty ? "" : "* Required";
        
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RegFloorComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void RegSessionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
        {





            if (RegIdTextBox.Text == string.Empty)
            {
                ReIdLabel.Content = "* Required !!";
            }



            if (RegNameTextBox.Text == string.Empty)
            {
                RegNameLabel.Content = "* Required !!";
            }
            if (RegDeptComboBox.Text == string.Empty)
            {
                RegDeptLabel.Content = "* Required !!";
            }
            if (RegSessionComboBox.Text == string.Empty)
            {
                RegSessionLabel.Content = "* Required !!";
            }
            if (RegRoomNoComboBox.Text == string.Empty)
            {
                RegRoomLabel.Content = "* Required !!";
            }
            if (RegFloorComboBox.Text == string.Empty)
            {
                RegFloorLabel.Content = "* Required !!";
            }
            if (_op.FileName == "")
            {
                RegImageLabel.Content = "* Required !!";
            }


            if (RegIdTextBox.Text != string.Empty)
            {

                ReIdLabel.Content = "";


            }
            if (RegNameTextBox.Text != string.Empty)
            {
                if (_ex.IsMatch(RegNameTextBox.Text))
                {
                    RegNameLabel.Content = "";
                }
                if (!_ex.IsMatch(RegNameTextBox.Text))
                {
                    RegNameLabel.Content = "* Invalid";
                }


            }
            if (RegDeptComboBox.Text != string.Empty)
            {
                RegDeptLabel.Content = "";
            }
            if (RegSessionComboBox.Text != string.Empty)
            {
                RegSessionLabel.Content = "";
            }
            if (RegRoomNoComboBox.Text != string.Empty)
            {
                RegRoomLabel.Content = "";
            }
            if (RegFloorComboBox.Text != string.Empty)
            {
                RegFloorLabel.Content = "";
            }
            if (_op.FileName != "")
            {
                RegImageLabel.Content = "";

            }

            if (RegIdTextBox.Text == string.Empty || RegNameTextBox.Text == string.Empty ||
                RegDeptComboBox.Text == string.Empty || RegSessionComboBox.Text == string.Empty ||
                RegRoomNoComboBox.Text == string.Empty || RegFloorComboBox.Text == string.Empty || _op.FileName == "")
                return;
            if (!_ex.IsMatch(RegNameTextBox.Text)) return;
            var registerMember = new Border
            {
                BorderId = RegIdTextBox.Text,
                Name = RegNameTextBox.Text,
                Department = RegDeptComboBox.Text,
                Room = Convert.ToInt32(RegRoomNoComboBox.Text),
                Session = RegSessionComboBox.Text
            };
            var checkIsBorderIdExist= _db.Borders.Any(id => id.BorderId.Equals(RegIdTextBox.Text));
            if (!checkIsBorderIdExist)
            {

                try
                {
                    var stream = new FileStream(_op.FileName, FileMode.Open, FileAccess.Read);
                    var reader = new StreamReader(stream);
                    var imgData = new Byte[stream.Length - 1];
                    stream.Read(imgData, 0, (int)stream.Length - 1);


                    registerMember.Image = imgData;
                    _db.Borders.Add(registerMember);
                    _db.SaveChanges();

                    MessageBox.Show("Congratues! new Border named=> " + " " + RegNameTextBox.Text + " has created successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    RegNameTextBox.Text = "";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Sorry,ID => " + "  " + RegIdTextBox.Text + "  " + "already Exist.Please enter a different Id.", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void RegImagUploadButton_OnClick(object sender, RoutedEventArgs e)
        {

            _op.Title = "Select a picture";
            _op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (_op.ShowDialog() == true)
            {



                BorderImage.Source = new BitmapImage(new Uri(_op.FileName));


            }
        }

        private void BorderRegistrationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            var t = _db.Floors.Select(m => m.Floor1);
            var d = _db.Departments.Select(m => m.Department1);

            foreach (var uu in t)
            {
                RegFloorComboBox.Items.Add(uu);
            }


            foreach (var uu in d)
            {
                RegDeptComboBox.Items.Add(uu);
            }

            foreach (var uu in _db.Sessions.Select(m => m.Session1))
            {
                RegSessionComboBox.Items.Add(uu);
            }

            try
            {

                ReIdLabel.Content = "";
                RegNameLabel.Content = "";
                RegDeptLabel.Content = "";
                RegSessionLabel.Content = "";
                RegFloorLabel.Content = "";
                RegRoomLabel.Content = "";
                RegImageLabel.Content = "";
            }
            catch (Exception)
            {


            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
         

        }

        private void WindowCloseIconImage_OnMouseEnter(object sender, MouseEventArgs e)
        {
            WindowCloseIconImage.Source = new BitmapImage(new Uri("/Images/CloseIconb.png", UriKind.Relative));
        }

        private void WindowCloseIconImage_OnMouseLeave(object sender, MouseEventArgs e)
        {
            WindowCloseIconImage.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
        }

        private void WindowCloseIconImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new HomeWindow();
            w.ShowDialog();
            this.Close();
        }
    }
}
