using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{

    public partial class DepartmentAddViewWindow : Window
    {
        public DepartmentAddViewWindow()
        {
            InitializeComponent();
        }


        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private void DepartmentAddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DepartmentNameTextBox.Text == "")
            {
                ErrorImage.Visibility = Visibility.Visible;
                DepartmentNameErrorMessageLabel.Content = "Required";
            }
            if (DepartmentNameTextBox.Text != "")
            {
                ErrorImage.Visibility = Visibility.Hidden;
                DepartmentNameErrorMessageLabel.Content = "";
                try
                {
                    var checkIsDepartmentExist =
                        _db.Departments.Any(m => m.Department1.Equals(DepartmentNameTextBox.Text));
                    if (!checkIsDepartmentExist)
                    {
                        var department = new Department { Department1 = DepartmentNameTextBox.Text };
                        _db.Departments.Add(department);
                        _db.SaveChanges();
                        DepartmentDataGrid.ColumnWidth = 249;
                        DepartmentDataGrid.ItemsSource = _db.Departments.ToList();
                        DepartmentNameTextBox.Text = "";
                        MessageBox.Show("New Department has been added successfully.", "", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        ErrorImage.Visibility = Visibility.Visible;
                        DepartmentNameErrorMessageLabel.Content = "Department already exist";
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }



        private void DepartmentNameTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (DepartmentNameTextBox.Text == "")
            {
                ErrorImage.Visibility = Visibility.Visible;
                DepartmentNameErrorMessageLabel.Content = "Required";
            }
            else
            {
                ErrorImage.Visibility = Visibility.Hidden;
                DepartmentNameErrorMessageLabel.Content = "";
            }
        }





        private void DepartmentDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure to delete this department parmanently?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result != MessageBoxResult.Yes) return;
                var obj = (Department)DepartmentDataGrid.SelectedItems[0];


                var departmentDeleteId = obj.DeptId;
                var department = _db.Departments.Find(departmentDeleteId);

                _db.Entry(department).State = EntityState.Deleted;
                _db.SaveChanges();
                DepartmentDataGrid.ColumnWidth = 249;
                DepartmentDataGrid.ItemsSource = _db.Departments.ToList();
                MessageBox.Show("Department has been  Deleted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);



            }
            catch (Exception mss)
            {

                MessageBox.Show("Sorry,No Data to Delete", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

    


        private void DepartmentAddViewWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            ErrorImage.Visibility = Visibility.Hidden;
            //DepartmentDataGrid.Width = 420;
            //DepartmentDataGrid.ColumnWidth = 310;


            DepartmentDataGrid.ItemsSource = _db.Departments.ToList();
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
