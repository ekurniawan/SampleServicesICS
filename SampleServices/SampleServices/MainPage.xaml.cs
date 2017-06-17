using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SampleServices.Models;
using SampleServices.Services;
using System.Collections.ObjectModel;

namespace SampleServices
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            TodoItemServices todoServices = new TodoItemServices();
            TodoItemList todoItemList = new TodoItemList();
            todoItemList.ListTodoItem =  
                new ObservableCollection<TodoItem>(await todoServices.GetAll());
            lvTodo.ItemsSource = todoItemList.ListTodoItem;
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahData());
        }

        private async void lvTodo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (TodoItem)e.Item;
            EditData editPage = new EditData();
            editPage.BindingContext = item;
            await Navigation.PushModalAsync(editPage);
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            var data = (ObservableCollection<TodoItem>)lvTodo.ItemsSource;
            data.RemoveAt(0);
            //await DisplayAlert("Keterangan", data[1].Name, "OK");
        }
    }
}
