using PracticeToDo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PracticeToDo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}