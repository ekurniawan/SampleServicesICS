
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
            var editData = new TodoItem
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Notes = txtNotes.Text,
                Done = swDone.IsToggled
            };

            try
            {
                await todoServices.UpdateData(editData);
                await DisplayAlert("Keterangan", "Edit data berhasil !", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}