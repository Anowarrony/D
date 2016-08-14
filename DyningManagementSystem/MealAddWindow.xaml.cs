using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DyningManagementSystem
{
   
    public partial class MealAddWindow : Window
    {
        public MealAddWindow()
        {
            InitializeComponent();
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
       
        readonly Regex _objDecimalRegex = new Regex(@"^\d*(.?)\d+$");
    
     

        private void BorderIdTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (BorderIdTextBox.Text != string.Empty)
            {
                IdLabel.Content = "";
            }
            if (BorderIdTextBox.Text == string.Empty)
            {

                IdLabel.Content = "* Required";
            }

        }

        private void DatePicker_OnCalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePicker.Text != string.Empty)
            {
                DateLabel.Content = "";
            }
            if (DatePicker.Text == string.Empty)
            {
                DateLabel.Content = "* Required!";
            }

        }

        private void MealTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (MealTextBox.Text != string.Empty)
            {


                MealLabel.Content = !_objDecimalRegex.IsMatch(MealTextBox.Text) ? "* Invalid" : "";
            }

            if (MealTextBox.Text == string.Empty)
            {
                MealLabel.Content = "* Required";

            }
        }

        private void PaymenTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (PaymenTextBox.Text != string.Empty)
            {


                PaymentLabel.Content = !_objDecimalRegex.IsMatch(PaymenTextBox.Text) ? "* Invalid" : "";
            }

            if (PaymenTextBox.Text == string.Empty)
            {
                PaymentLabel.Content = "";
            }

        }

        private void MealAddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (BorderIdTextBox.Text == string.Empty)
            {
                IdLabel.Content = "* Required!";
            }
            if (MealTextBox.Text == string.Empty)
            {
                MealLabel.Content = "* Required!";

            }

            if (DatePicker.Text == string.Empty)
            {
                DateLabel.Content = "* Required!";
            }
            if (DatePicker.Text != string.Empty)
            {
                DateLabel.Content = "";
            }
            if (BorderIdTextBox.Text != string.Empty)
            {
                IdLabel.Content = "";

            }
            if (MealTextBox.Text != string.Empty)
            {


                MealLabel.Content = !_objDecimalRegex.IsMatch(MealTextBox.Text) ? "* Invalid" : "";
            }

            if (PaymenTextBox.Text != string.Empty)
            {


                PaymentLabel.Content = !_objDecimalRegex.IsMatch(PaymenTextBox.Text) ? "* Invalid" : "";
            }


            if (BorderIdTextBox.Text == "" || MealTextBox.Text == "" || DatePicker.Text == "") return;
            if (!_objDecimalRegex.IsMatch(MealTextBox.Text)) return;
            if (PaymenTextBox.Text != "")
            {

                if (_objDecimalRegex.IsMatch(PaymenTextBox.Text))
                {



                    var checkIsBorderIdExist =
                        _db.Borders.Any(m => m.BorderId == BorderIdTextBox.Text);

                    if (checkIsBorderIdExist)
                    {

                        PaymentLabel.Content = "";
                         var objMeal = new Meal
                         {
                             BorderId = BorderIdTextBox.Text,
                             Meal1 = Convert.ToDouble(MealTextBox.Text),
                             Date = DatePicker.Text,
                             Payment = Convert.ToInt32(PaymenTextBox.Text)
                         };


                        _db.Meals.Add(objMeal);
                        _db.SaveChanges();
                        MessageBox.Show(" Meal Inserted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);


                    
                        PaymenTextBox.Text = "";
                  
                        objMeal.Payment = 0;
                    }

                    else
                    {
                        var re = MessageBox.Show("Sorry , Id =>  " + BorderIdTextBox.Text + " " + "Not Found!.It seems This Id is not Registered yet.Do You want to Register now?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                        if (re != MessageBoxResult.Yes) return;
                     

                        this.Hide();
                        var w = new BorderRegistrationWindow();
                        w.ShowDialog();
                        this.Close();
                    }


                }

                else
                {
                    PaymentLabel.Content = "* Invalid!";
                }

            }
            else
            {




                var checkIsBorderIdExist = _db.Borders.Any(m => m.BorderId.Equals(BorderIdTextBox.Text));

                if (checkIsBorderIdExist)
                {
                    var meal = new Meal()
                    {
                        BorderId = BorderIdTextBox.Text,
                        Date = DatePicker.Text,
                        Meal1 = Convert.ToDouble(MealTextBox.Text),
                        Payment = 0
                    };

                    PaymentLabel.Content = "";
                    _db.Meals.Add(meal);
                    _db.SaveChanges();

                    MealTextBox.Text = "";
                    PaymenTextBox.Text = "";
                    BorderIdTextBox.Text = "";
                    MessageBox.Show(" Meal Inserted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }


                else
                {

                    var re = MessageBox.Show("Sorry , Id =>  " + BorderIdTextBox.Text + " " + "Not Found!.It seems This Id is not Registered yet.Do You want to Register now?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                    if (re != MessageBoxResult.Yes) return;
                  
                    this.Hide();
                    var w = new BorderRegistrationWindow();
                    w.ShowDialog();
                    this.Close();
                }


            }

        }

        private void RedirectToRegisterPageButton_OnClick(object sender, RoutedEventArgs e)
        {

            Hide();
            var borderRegWindow = new BorderRegistrationWindow();
            borderRegWindow.ShowDialog();
           Close();
        }

        private void MealAddWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            IdLabel.Content = "";
            DateLabel.Content = "";
            PaymentLabel.Content = "";
            MealLabel.Content = "";
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
