using BudgetAppTry2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetAppTry2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfExpenses : ContentPage
    {
        // private List<ExpenseCategoryIcon> categoryexpenses;
        private List<string> expensesname;


        public ListOfExpenses()
        {
            InitializeComponent();

            /* categoryexpenses = new List<ExpenseCategoryIcon>();
            categoryexpenses.Add(new ExpenseCategoryIcon("Entertainment",IconCategory.Entertainment));
            categoryexpenses.Add(new ExpenseCategoryIcon("Utility", IconCategory.Utility));
            categoryexpenses.Add(new ExpenseCategoryIcon("Tuition", IconCategory.Tuition));
            categoryexpenses.Add(new ExpenseCategoryIcon("Medical", IconCategory.Medical));
            categoryexpenses.Add(new ExpenseCategoryIcon("Insurance", IconCategory.Insurance));*/


            expensesname = new List<string>();
            expensesname.Add("Entertainment");
            expensesname.Add("Utility");
            expensesname.Add("Tuition");
            expensesname.Add("Medical");
            expensesname.Add("Insurance");
            /* {
                // ImageFile = "Resources/drawable/Entertainment.png",
                // Iconcategory = IconCategory.Entertainment,

         });
             categoryexpenses.Add(new ExpenseCategoryIcon
                 {
                 //ImageFile = "Resources/drawable/Medical.png",
                 Iconcategory = IconCategory.Medical
             });
             categoryexpenses.Add(new ExpenseCategoryIcon
             {
                // ImageFile = "Resources/drawable/Insurance.png",
                 Iconcategory = IconCategory.Insurance
             });
             categoryexpenses.Add(new ExpenseCategoryIcon
             {
                // ImageFile = "Resources/drawable/Tuition.png",
                 Iconcategory = IconCategory.Tuition
             });
             categoryexpenses.Add(new ExpenseCategoryIcon
             {
                 //ImageFile = "Resources/drawable/Utility.png",
                 Iconcategory = IconCategory.Utility,

             }) ;*/

            Selectedcategory.ItemsSource= expensesname;
            Itemchoose.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Selectedcategory));
            // Chooseimage.Source = ImageSource.FromResource("BudgetAppTry2.Views.Assets.Entertainment.png");

        }
        protected override void OnAppearing()
        {
            var Expenses = (ExpenseCategoryIcon)BindingContext;
            if (Expenses != null && !string.IsNullOrEmpty(Expenses.Filename))
            {
                Expenseslist.Text = File.ReadAllText(Expenses.Filename);
                //Itemchoose.Text = File.ReadAllText(Expenses.Filename);
                //Itemchoose.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Selectedcategory));

            }
        }
        private void deletedetails_Clicked(object sender, EventArgs e)
        {
            var Expenses = (ExpenseCategoryIcon)BindingContext;
            if (File.Exists(Expenses.Filename))
            {
                File.Delete(Expenses.Filename);
            }
            Expenseslist.Text = string.Empty;
            Navigation.PopModalAsync();
        }

        private async void savedetails_Clicked(object sender, EventArgs e)//working good.dont change it.
        {
            var Expenses = (ExpenseCategoryIcon)BindingContext;
            if (Expenses == null || string.IsNullOrEmpty(Expenses.Filename))
            {
                Expenses = new ExpenseCategoryIcon();
                Expenses.Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.budget.notes.txt");
            }
            var bothtexts = $"{Expenseslist.Text} {Itemchoose.Text}";
            File.WriteAllText(Expenses.Filename,bothtexts);
           // File.WriteAllText(Expenses.Filename,Expenseslist.Text);
            

            if (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                Shell.Current.CurrentItem = (Shell.Current as AppShell).MainPageContent;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}