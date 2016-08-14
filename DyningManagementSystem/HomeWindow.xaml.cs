
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace DyningManagementSystem
{
 
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

    


 
   

    




        private void DepartmentMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

     

            this.Hide();
            var w = new DepartmentAddViewWindow();
            w.ShowDialog();
            this.Close();
        }

        private void SessionMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        
            this.Hide();
            var w = new SessionAddViewWindow();
            w.ShowDialog();
            this.Close();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();

        }

     

        private void ViewBazarMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

       
            this.Hide();
            var w = new BazarAddWindow();
            w.ShowDialog();
            this.Close();
        }

  

      
        private void BorderAddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
     

        }


        private void BorderMealAddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
          

            this.Hide();
            var w = new MealAddWindow();
            w.ShowDialog();
            this.Close();
        }

        private void BorderRegistrationWindow_OnClick(object sender, RoutedEventArgs e)
        {
         
            this.Hide();
            var w = new BorderRegistrationWindow();
            w.ShowDialog();
            this.Close();
        }

        private void MealInfoMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

         
            this.Hide();
            var w = new MealInformationWindow();
            w.ShowDialog();
            this.Close();
        }

        private void BorderMealsSearchMenuItem_OnClick(object sender, RoutedEventArgs e)
        {


            this.Hide();
            var w = new BorderMealSearchWindow("");
            w.ShowDialog();
            this.Close();
        }

        private void BazarAddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var b = new BazarAddWindow();
            b.ShowDialog();
            this.Close();
        }


    

        private void BorderAddIconImage_OnMouseLeave(object sender, MouseEventArgs e)
        {
       
        }

        private void BorderAddIconImage_OnMouseEnter(object sender, MouseEventArgs e)
        {
           
        }


        private void BorderAddIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new BorderRegistrationWindow();
            w.ShowDialog();
            this.Close();
        }

        private void MealAddIconBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new MealAddWindow();
            w.ShowDialog();
            this.Close();
        }

        private void DepartmentAddIconBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
            var w = new DepartmentAddViewWindow();
            w.ShowDialog();
            this.Close();
        }


  

        private void SessionAddIconBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            this.Hide();
            var w = new SessionAddViewWindow();
            w.ShowDialog();
            this.Close();
        }

        private void BazarAddIconBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var b = new BazarAddWindow("AddBazar");
            b.ShowDialog();
            this.Close();
        }

        private void BazarDetailsIconBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new BazarAddWindow("BazarDetails");
            w.ShowDialog();
            this.Close();
        }

        private void MealsDetailsIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new MealInformationWindow();
            w.ShowDialog();
            this.Close();
        }

        private void WindowColseIcon_OnMouseEnter(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source=new BitmapImage(new Uri("/Images/CloseIconb.png",UriKind.Relative));
        }

        private void WindowColseIcon_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           Close();
        }

        private void WindowColseIcon_OnMouseLeave(object sender, MouseEventArgs e)
        {
            WindowColseIcon.Source = new BitmapImage(new Uri("/Images/CloseIcona.png", UriKind.Relative));
       
        }

        private void BorderMealsSearchBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var w = new BorderMealSearchWindow();
            w.ShowDialog();
            this.Close();
        }
    }
}
