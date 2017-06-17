
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleServices.Services;
using SampleServices.Models;

namespace SampleServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditData : ContentPage
    {
        private TodoItemServices todoServices;

        public EditData()
        {
            InitializeComponent();
            todoServices = new TodoItemServices();
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var editTodo = (TodoItem)BindingContext;
                await todoServices.UpdateData(editTodo);
                await DisplayAlert("Keterangan", "Edit data berhasil !", "OK");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var deleteTodo = (TodoItem)BindingContext;
                await todoServices.DeleteData(deleteTodo.ID);
                await DisplayAlert("Keterangan", "Delete data berhasil !", "OK");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void btnBinding_Clicked(object sender, EventArgs e)
        {
            var data = (TodoItem)BindingContext;
            data.Name = "Diubah dari kode";
        }
    }
}