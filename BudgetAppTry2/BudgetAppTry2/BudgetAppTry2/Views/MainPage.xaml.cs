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

            var setamount = new BudgetAppTry();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var file in files)
            {
                var budamt = new BudgetAppTry
                {
                    FileName = file,
                    BudgetAmount = File.ReadAllText(file),
                    Date = File.GetCreationTime(file)
                };
               
            }
            // bgt.Itemsource = setamount;
            var budgets = new List<ExpenseCategoryIcon>();
            var budgetfiles = Directory.EnumerateFiles(
                 Environment.GetFolderPath
                 (Environment.SpecialFolder.LocalApplicationData),
                "*.budget.notes.txt");
            
            foreach (var budgetfile in budgetfiles)
            {
                var budget = new ExpenseCategoryIcon
                {
                    Text = File.ReadAllText(budgetfile),
                    Filename=budgetfile,
                    Date=File.GetCreationTime(budgetfile),
                    
                };
                budgets.Add(budget);
            }
           Amtset.ItemsSource = budgets.OrderByDescending(t=>t.Date);
          
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
            }).Wait();
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



