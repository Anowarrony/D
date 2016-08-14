
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{
  
    public partial class MealInformationWindow : Window
    {
        public MealInformationWindow()
        {
            InitializeComponent();
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private void MealInformationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var items = new List<MealInformation>();
                var bazar = new Bazar();
                var sum = _db.Bazars.Sum(x => x.Taka);
                {
                    var totalBazarTaka = sum;

                    var totalMeal = _db.Meals.Sum(x => x.Meal1);
                    var i = _db.Meals.Sum(x => x.Payment);
                    if (i != null)
                    {
                        var totalTakaGivenBAll = i.Value;
                        var mealRate = totalBazarTaka / totalMeal;
                        var cashInHand = totalTakaGivenBAll - totalBazarTaka;
                        if (totalMeal != null)
                            items.Add(new MealInformation() { TotalTaka = totalTakaGivenBAll, TotalMeal = (double)totalMeal, TotalBazar = totalBazarTaka, MealRate = (double)mealRate, CashInHand = cashInHand });
                    }
                }

                MealInfoListView.ItemsSource = items;
            }
            catch (Exception)
            {
                
             
            }
            


       
        }

  

        private void WindowCloseIconImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new HomeWindow();
            w.ShowDialog();
            this.Close();
        }

        private void WindowCloseIconImage_OnMouseLeave(object sender, MouseEventArgs e)
        {

            WindowCloseIconImage.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
        }

        private void WindowCloseIconImage_OnMouseEnter(object sender, MouseEventArgs e)
        {
            WindowCloseIconImage.Source = new BitmapImage(new Uri("/Images/CloseIconb.png", UriKind.Relative));
        }
    }
}
