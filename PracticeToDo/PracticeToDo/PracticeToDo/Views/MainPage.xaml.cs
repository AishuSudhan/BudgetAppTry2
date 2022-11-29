using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeToDo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticeToDo.Views
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
            var todos = new List<MyToDo>();
           var files= Directory.EnumerateFiles(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
                "*.notes.txt");
            foreach(var file in files)
            {
                var todo = new MyToDo
                   {
                Text = File.ReadAllText(file),
                Date=File.GetCreationTime(file),
                FileName=file
                };
                todos.Add(todo);
            }
            ParcticeToDoListView.ItemsSource=todos.OrderByDescending(t=>t.Date);
        }

        private async void ParcticeToDoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new Todo
            {
                BindingContext = (MyToDo)e.SelectedItem
            });
        }
    }
}