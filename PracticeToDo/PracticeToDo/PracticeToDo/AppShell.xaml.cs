using PracticeToDo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace PracticeToDo
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
