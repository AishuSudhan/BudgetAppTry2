using BudgetAppTry2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BudgetAppTry2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public ShellContent MainPageContent;
        public AppShell()
        {
            InitializeComponent();
            MainPageContent = Home;

        }
    }
}
