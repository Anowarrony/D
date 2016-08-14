using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace DyningManagementSystem
{
   
    public partial class BorderMealsUpdateWindow : Window
    {
        public BorderMealsUpdateWindow(int upId, string date, double meal, int payment, string borderId)
        {
            InitializeComponent();
            UpMealDatePicker.Text = date;
            UpMealMealTextBox.Text = meal.ToString(CultureInfo.InvariantCulture);
            UpMealPayment.Text = payment.ToString(CultureInfo.InvariantCulture);
            MealupIdLabel.Content = upId;
            PidLabel.Content = borderId;
            
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           
        }

        private void UpMealButton_Click(object sender, RoutedEventArgs e)
        {
        
            try
            {
                if (UpMealDatePicker.Text!=""&& UpMealMealTextBox.Text!=""&&UpMealPayment.Text!="")
                {
                    var meals = new Meal();
                    var updateId = Convert.ToInt32(MealupIdLabel.Content);
                    meals = _db.Meals.Single(m => m.MealId.Equals(updateId));
                    meals.Date = UpMealDatePicker.Text;
                    meals.Meal1 = Convert.ToDouble(UpMealMealTextBox.Text);
                    meals.Payment = Convert.ToInt32(UpMealPayment.Text);
                    _db.Entry(meals).State = EntityState.Modified;
                    _db.SaveChanges();
                    MessageBox.Show("Record updated Successfully.", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {

                    MessageBox.Show("Failed to update!.Please make sure that all fields are filled", "", MessageBoxButton.OK, MessageBoxImage.Error);
            
                }
           
            }
            catch (Exception esException)
            {

                MessageBox.Show(esException.Message, "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {

            var id = PidLabel.Content.ToString();

            this.Hide();
            var home = new BorderMealSearchWindow(id);
            home.ShowDialog();
            this.Close();
        }
    }
}
