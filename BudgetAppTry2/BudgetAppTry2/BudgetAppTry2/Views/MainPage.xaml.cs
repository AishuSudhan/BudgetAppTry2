using BudgetAppTry2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetAppTry2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

         
        }


        protected override void OnAppearing()
        {
            Userbudgetamount.IsVisible = true;
            ChangeBudget.IsVisible = true;
            var setamount = new BudgetAppTry();
            
            var files = Directory.EnumerateFiles(Environment.GetFolderPath
               (Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");

            foreach (var file in files)
            {
                setamount = new BudgetAppTry

                {
                    FileName = file,
                    BudgetAmount = File.ReadAllText(file),
                    // Date = File.GetCreationTime(file)
                };
                Userbudgetamount.Text = setamount.BudgetAmount;

                Userbudgetamount.IsVisible = true;
            }    

            //ExpenseCategoryItem is for list of expense details
            var budgets = new List<ExpenseCategoryIcon>();
            
                var budgetfiles = Directory.EnumerateFiles(
                     Environment.GetFolderPath
                     (Environment.SpecialFolder.LocalApplicationData),
                    "*.budget.amountnotes.txt");

            foreach (var budgetfile in budgetfiles)
            {
                var budget = new ExpenseCategoryIcon
                {
                    Filename = budgetfile,
                    Text = File.ReadAllText(budgetfile),
                    Date = File.GetCreationTime(budgetfile)

                };
                budgets.Add(budget);
            }
                Amtset.ItemsSource = budgets.OrderByDescending(t => t.Date);

           
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BudgetAmountPage());
            
              
        }

        private void Amtset_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushModalAsync(new ListOfExpenses
            {
                BindingContext = (ExpenseCategoryIcon)e.SelectedItem
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Notification","your budget amount is already set","ok");
           
           
        }

        private void ChangeBudget_Clicked(object sender, EventArgs e)
        {
            Userbudgetamount.Text = string.Empty;
            Userbudgetamount.IsVisible = false;
            ChangeBudget.IsVisible = false;
        }

        /* if (budgetfiles.Count() > 0)
            {
                BudgetButton.IsVisible = false;
            }
            else
            {
                BudgetButton.IsVisible = true;
            }*/


    }

}



