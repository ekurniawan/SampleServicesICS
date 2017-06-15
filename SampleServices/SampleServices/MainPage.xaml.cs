using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SampleServices.Models;
using SampleServices.Services;

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
            todoItemList.ListTodoItem = await todoServices.GetAll();
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
    }
}
