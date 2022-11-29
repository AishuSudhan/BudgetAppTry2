using PracticeToDo.Models;
using System;
using System.IO;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticeToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Todo : ContentPage
    {
        public Todo()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var todo = (MyToDo)BindingContext;
            if (todo != null && !string.IsNullOrEmpty(todo.FileName))
            {
               
                ToDoText.Text = File.ReadAllText(todo.FileName);
            }
        }
        private async void add_Clicked(object sender, EventArgs e)
        {
            var todo = (MyToDo)BindingContext;
            if (todo == null || string.IsNullOrEmpty(todo.FileName))
            {
                todo = new MyToDo();
                todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                 $"{Path.GetRandomFileName()}.notes.txt");
            }

            File.WriteAllText(todo.FileName, ToDoText.Text);
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
            var todo = (MyToDo)BindingContext;
            if (File.Exists(todo.FileName))
            {
                File.Delete(todo.FileName);
            }
            ToDoText.Text = string.Empty;
            Navigation.PopModalAsync();
        }
    }
}