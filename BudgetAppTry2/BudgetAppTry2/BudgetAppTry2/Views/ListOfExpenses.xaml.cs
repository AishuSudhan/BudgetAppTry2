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

        private List<string> expensesname;


        public ListOfExpenses()
        {
            InitializeComponent();

            //this is the code for the list that shows on picker dropdown.

            expensesname = new List<string>();
            expensesname.Add("Entertainment");
            expensesname.Add("Utility");
            expensesname.Add("Tuition");
            expensesname.Add("Medical");
            expensesname.Add("Insurance");
            Selectedcategory.ItemsSource= expensesname;//this is how i bind the selected dropdown item show in picker.
            Itemchoose.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: Selectedcategory));
            //itemchoose is the label name i am using that to diplay the selected item on picker.that is extra. 
            //but i am using that label to do string concatination along with editors text to show both editor text and category selected inpicker
            // to display in the mainpage listview.
        }
        protected override void OnAppearing()
        {
            var Expenses = (ExpenseCategoryIcon)BindingContext;
            if (Expenses != null && !string.IsNullOrEmpty(Expenses.Filename))
            {
                Expenseslist.Text = File.ReadAllText(Expenses.Filename);

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

        private async void savedetails_Clicked(object sender, EventArgs e)
        {
            var Expenses = (ExpenseCategoryIcon)BindingContext;
            if (Expenses == null || string.IsNullOrEmpty(Expenses.Filename))
            {
                Expenses = new ExpenseCategoryIcon();
                //using two different filenames to store data one file is for budgetamount and second one is for expense details.
                //differenciate them by adding different name after "." eg ".amountnotes"
                Expenses.Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.budget.amountnotes.txt");
            }
            var bothtexts = $"{Expenseslist.Text} {Itemchoose.Text}";
            File.WriteAllText(Expenses.Filename,bothtexts);
           
            

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