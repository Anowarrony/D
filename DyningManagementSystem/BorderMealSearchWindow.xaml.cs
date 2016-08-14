using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{
   
    public partial class BorderMealSearchWindow : Window
    {
        public BorderMealSearchWindow(string borderId)
        {
            InitializeComponent();
            IdLabel.Content = borderId;
        }
        public BorderMealSearchWindow()
        {
            InitializeComponent();
           
        }
        readonly DyningManagementDbContext _db = new DyningManagementDbContext();
        private string _borderId;
      
  
        List<int> _mealIdList = new List<int>();
        

        private void GetImage()
        {
            var id = SearchTextBox.Text;
            var y = _db.Borders.Where(m => m.BorderId == id).Select(m => m.Image);

            var u = y.ToArray();
            foreach (var ms in u.Select(b => new MemoryStream(b)))
            {
                MemberImage.Source = ToImage(ms.ToArray());
            }

        }


        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    






      

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var updateMeal = (Meal)TestDataGrid.SelectedItems[0];
                var upId = updateMeal.MealId;
                var date = updateMeal.Date;
                if (updateMeal.Meal1 != null)
                {
                    var meal = (double) updateMeal.Meal1;
                    if (updateMeal.Payment != null)
                    {
                        var payment = updateMeal.Payment.Value;
                        var borderId = updateMeal.BorderId;
                    


                        this.Hide();
                        var w = new BorderMealsUpdateWindow(upId, date, meal, payment, borderId);
                        w.ShowDialog();
                        this.Close();
                

                    }
                }
            

            }
            catch (Exception msx)
            {

                MessageBox.Show(msx.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }


       

     

        private void BorderMealInfoDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var countDeleteItem = _mealIdList.Count;
            if (countDeleteItem >= 1)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete " + countDeleteItem + " items parmanently?",
                    "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    foreach (var id in _mealIdList)
                    {
                        var meal = _db.Meals.Find(id);
                        _db.Entry(meal).State = EntityState.Deleted;
                        _db.SaveChanges();

                    }
                    var emptyDeleteList = new List<int>();
                    _mealIdList = emptyDeleteList;

                    TestDataGrid.ItemsSource = _db.Meals.Where(m => m.BorderId == _borderId).ToList();

                }
                else
                {
                    var emptyDeleteList = new List<int>();
                    _mealIdList = emptyDeleteList;

                    TestDataGrid.ItemsSource = _db.Meals.Where(m => m.BorderId == _borderId).ToList();

                }
            }
            else
            {
                MessageBox.Show("Please select rows to delete", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }


        private void TestDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void TestDataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var updateMeal = (Meal)TestDataGrid.SelectedItems[0];
                var upId = updateMeal.MealId;
                _borderId = updateMeal.BorderId;
                if (!_mealIdList.Contains(upId))
                {
                    _mealIdList.Add(upId);
                }
            }
            catch (Exception)
            {


            }


        }

        private void BorderMealSearchWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

       
            if (IdLabel.Content.ToString()=="")
            {

            }
            else
            {
                try
                {
                    var id = IdLabel.Content.ToString();



                    var totalPersonalMeal = _db.Meals.Where(x => x.BorderId == id).Sum(m => m.Meal1);
                    var sum = _db.Meals.Where(x => x.BorderId == id).Sum(m => m.Payment);
                    if (sum != null)
                    {
                        var paidAmount = sum.Value;

                        var i = _db.Bazars.Sum(x => x.Taka);
                        {
                            var totalBazarTaka = i;
                            var totalMeal = _db.Meals.Sum(x => x.Meal1);
                            var mealRate = totalBazarTaka / totalMeal;

                            var totalPersonalMealCoast = totalPersonalMeal * mealRate;
                            var personalCurrentbalance = paidAmount - totalPersonalMealCoast;

                            if (totalPersonalMeal != null)
                            {
                                if (totalPersonalMealCoast != null)
                                {
                                    var mealInfoList = new List<BorderMealInformation>
                                    {
                                        new BorderMealInformation()
                                        {
                                            TotalMeal = (double) totalPersonalMeal,
                                            TotaPaidAmount = paidAmount,
                                            Totalcoast = (double) totalPersonalMealCoast,
                                            CurrentBalance = (double) personalCurrentbalance,

                                        }
                                    };

                                    SearchTextBox.Text = id.ToString();


                                    GetImage();
                                    PersonalMealInfoDataGrid.ItemsSource = mealInfoList;
                                }
                            }
                        }
                    }


                    TestDataGrid.ItemsSource = _db.Meals.Where(m => m.BorderId == id).ToList();

                }

                catch (Exception)
                {

                }




            }
        }

        private void BorderDetailsButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                TestDataGrid.ItemsSource = "";

                MessageBox.Show("You must enter Id to search", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            else
            {



                var searchid = SearchTextBox.Text;

                var checkIsBorderIdExist = _db.Meals.Any(m => m.BorderId == searchid);


                if (checkIsBorderIdExist)
                {
                    TestDataGrid.ItemsSource = _db.Meals.Where(m => m.BorderId == searchid).ToList();
                }

                else
                {
                    var checkIsBorderIdExistInRegisterTable = _db.Borders.Any(m => m.BorderId == searchid);
                    if (checkIsBorderIdExistInRegisterTable)
                    {
                        TestDataGrid.ItemsSource = "";
                        MessageBox.Show("For your Entered ID => " + searchid + " " + " there is no meals record.", "", MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        TestDataGrid.ItemsSource = "";
                        MessageBox.Show("Your Entered ID => " + searchid + " " + "not found.It seems there is no border having this ID.If this border is new then register first", "", MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                    }
                
                }
            }
        }

        private void BorderSearchButton_OnClick(object sender, RoutedEventArgs e)
        {


            if (SearchTextBox.Text == "")
            {
                PersonalMealInfoDataGrid.ItemsSource = "";
                MessageBox.Show("You must enter Id to search", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }
            if (SearchTextBox.Text == "") return;

            var searchid = SearchTextBox.Text;
            var checkIsBorderIdExist = _db.Meals.Any(m => m.BorderId .Equals(searchid));

            if (checkIsBorderIdExist)
            {


                try
                {

                    var id = SearchTextBox.Text;
                    var totalPersonalMeal = _db.Meals.Where(x => x.BorderId == id).Sum(m => m.Meal1);
                    var sum = _db.Meals.Where(x => x.BorderId == id).Sum(m => m.Payment);
                    if (sum != null)
                    {
                        var paidAmount = sum.Value;

                        var i = _db.Bazars.Sum(x => x.Taka);
                        if (true)
                        {
                            var totalBazarTaka = i;
                            var totalMeal = _db.Meals.Sum(x => x.Meal1);
                            var mealRate = totalBazarTaka / totalMeal;

                            var totalPersonalMealCoast = totalPersonalMeal * mealRate;
                            var personalCurrentbalance = paidAmount - totalPersonalMealCoast;

                            if (totalPersonalMeal != null)
                            {
                                if (totalPersonalMealCoast != null)
                                {
                                    var mealInfoList = new List<BorderMealInformation>
                                        {
                                            new BorderMealInformation()
                                            {
                                                TotalMeal = (double) totalPersonalMeal,
                                                TotaPaidAmount = paidAmount,
                                                Totalcoast = (double) totalPersonalMealCoast,
                                                CurrentBalance = (double) personalCurrentbalance,

                                            }
                                        };

                                    MemberImage.Visibility = Visibility.Visible;
                                    GetImage();

                                    PersonalMealInfoDataGrid.ItemsSource = mealInfoList;
                                }
                            }
                        }
                    }
                }
                catch (Exception ec)
                {

                    MessageBox.Show(ec.Message);
                }
            }
            else
            {

                var checkBorderIsExistInBorderTable = _db.Borders.Any(m => m.BorderId == searchid);
                if (checkBorderIsExistInBorderTable)
                {
                    var mealInfoList = new List<BorderMealInformation>
                    {
                        new BorderMealInformation()
                        {
                            TotalMeal = 0,
                            TotaPaidAmount = 0,
                            Totalcoast = 0,
                            CurrentBalance = 0,

                        }
                    };



                    MemberImage.Visibility = Visibility.Visible;
                    GetImage();
                    PersonalMealInfoDataGrid.ItemsSource = mealInfoList;
                }
                else
                {
                    PersonalMealInfoDataGrid.ItemsSource = "";
                    MemberImage.Visibility = Visibility.Hidden;
                    MessageBox.Show("Your Entered ID => " + searchid + " " + "not found", "", MessageBoxButton.OK,
                         MessageBoxImage.Exclamation); 
                }
            
            }

       
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                var result =
                    MessageBox.Show("Are You Sure To Delete?This will Delete This record parmanently.", "",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes) return;
                var searchid = SearchTextBox.Text;
                var updateBazar = (Meal)TestDataGrid.SelectedItems[0];
                _db.Entry(updateBazar).State = EntityState.Deleted;
                _db.SaveChanges();

                TestDataGrid.ItemsSource = _db.Meals.Where(m => m.BorderId == searchid).ToList();
                MessageBox.Show("Record Deleted Successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("Nothing to Delete", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void WindowCloseIconImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var home = new HomeWindow();
            this.Close();
            home.Show();
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
