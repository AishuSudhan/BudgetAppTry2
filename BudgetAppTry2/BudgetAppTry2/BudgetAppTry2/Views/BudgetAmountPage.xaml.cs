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
    public partial class BudgetAmountPage : ContentPage
    {
        public BudgetAmountPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var Budgetamt = (BudgetAppTry)BindingContext;
            if ( Budgetamt!= null && !string.IsNullOrEmpty(Budgetamt.FileName))
            {
                YourBudgetAmount.Text = File.ReadAllText(Budgetamt.FileName);
            }
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var budamount = (BudgetAppTry)BindingContext;
            if (budamount== null || string.IsNullOrEmpty(budamount.FileName))
            {
                budamount = new BudgetAppTry();
                budamount.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.notes.txt");
            }
            File.WriteAllText(budamount.FileName, YourBudgetAmount.Text);
            if (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                Shell.Current.CurrentItem = (Shell.Current as AppShell).MainPageContent;
            }
            
            
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var budamt = (BudgetAppTry)BindingContext;
            if (File.Exists(budamt.FileName))
            {
                File.Delete(budamt.FileName);
            }
            YourBudgetAmount.Text = string.Empty;
            Navigation.PopModalAsync();
        }
    }
}